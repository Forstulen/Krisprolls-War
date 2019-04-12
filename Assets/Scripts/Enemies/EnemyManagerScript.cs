using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    [System.Serializable]
    public struct EnemyStruct {
        public EnemyType    EnemyType;
        public GameObject   EnemyPrefab;
    }

    public class EnemyManagerScript : SingletonScript<EnemyManagerScript>
    {
        //Events
        public delegate void OnEnemyEvent(Enemy e);
        public event OnEnemyEvent EnemySpawning;
        public event OnEnemyEvent EnemySurviving;
        public event OnEnemyEvent EnemyKilling;

        [SerializeField]
        private float _offset = 0.2f;

        [SerializeField]
        private EnemyStruct[] EnemyCollection;
        private GameObject _parentGameObject;

        private PooledObjectScript[] _pooledEnemiesCollections;

        private const int CAPACITY = 10;

        public void Start()
        {
            _parentGameObject = new GameObject("Enemies");
            _pooledEnemiesCollections = new PooledObjectScript[EnemyCollection.Length];

            for (int i = 0; i < EnemyCollection.Length; ++i)
            {
                PooledObjectScript script = new PooledObjectScript(EnemyCollection[i].EnemyPrefab, _parentGameObject.transform, CAPACITY, true);

                _pooledEnemiesCollections[i] = script;
            }
        }

        private void SpawnEnemy(GameObject obj) {
            if (EnemySpawning != null)
            {
                Enemy e = obj.GetComponent<Enemy>();
                EnemySpawning(e);
            }
        }

        private void KillEnemy(GameObject obj)
        {
            if (EnemyKilling != null)
            {
                Enemy e = obj.GetComponent<Enemy>();

                EnemyKilling(e);
            }
            UnregisterEnemy(obj);
        }

        private void EscapeEnemy(GameObject obj)
        {
            if (EnemySurviving != null)
            {
                Enemy e = obj.GetComponent<Enemy>();

                EnemySurviving(e);

                e.Deactivate();
            }
            UnregisterEnemy(obj);

        }

        private void RegisterEnemy(GameObject enemy) {
            FollowingWaypointScript script = enemy.GetComponent<FollowingWaypointScript>();

            script.StartFollowing += SpawnEnemy;
            script.StopFollowing += KillEnemy;
            script.FinishFollowing += EscapeEnemy;

        }

        private void UnregisterEnemy(GameObject enemy)
        {
            FollowingWaypointScript script = enemy.GetComponent<FollowingWaypointScript>();

            script.StartFollowing -= SpawnEnemy;
            script.StopFollowing -= KillEnemy;
            script.FinishFollowing -= EscapeEnemy;

        }

        public GameObject   CreateEnemy(EnemyType type) {
            for (int i = 0; i < EnemyCollection.Length; ++i) {
                if (EnemyCollection[i].EnemyType == type)
                {
                    GameObject go = _pooledEnemiesCollections[i].GetPooledObject();

                    go.transform.SetParent(_parentGameObject.transform, false);
                    go.SetActive(true);

                    RegisterEnemy(go);

                    return go;
                }
            }
            return null;
        }

        public GameObject CreateEnemy(EnemyType type, FollowingPath path, float reduceCoeff)
        {
            for (int i = 0; i < EnemyCollection.Length; ++i)
            {
                if (EnemyCollection[i].EnemyType == type)
                {
                    GameObject go = _pooledEnemiesCollections[i].GetPooledObject();
                    Enemy enemy = go.GetComponent<Enemy>();

                    enemy.FollowingPath = path;
                    enemy.ApplyPermanentSpeedMalus(reduceCoeff);

                    Vector3 vector = enemy.GetInitialPosition();

                    go.transform.position = new Vector3(vector.x + Random.Range(0.0f, _offset), vector.y + Random.Range(0.0f, _offset), 0.0f);
                    go.transform.rotation = Quaternion.identity;
                    go.transform.SetParent(_parentGameObject.transform, false);
                    go.SetActive(true);

                    RegisterEnemy(go);

                    return go;
                }
            }
            return null;
        }

        public GameObject CreateEnemy(EnemyType type, Vector3 position, Quaternion identity, float reduceCoeff)
        {
            for (int i = 0; i < EnemyCollection.Length; ++i)
            {
                if (EnemyCollection[i].EnemyType == type) {
                    GameObject go = _pooledEnemiesCollections[i].GetPooledObject();

                    Enemy enemy = go.GetComponent<Enemy>();

                    enemy.ApplyPermanentSpeedMalus(reduceCoeff);

                    go.transform.position = position;
                    go.transform.rotation = identity;
                    go.transform.parent = _parentGameObject.transform;
                    go.SetActive(true);

                    RegisterEnemy(go);

                    return go;
                }
            }
            return null;
        }

        public void DestroyEnemies() {
            foreach (PooledObjectScript p in _pooledEnemiesCollections) {
                foreach (GameObject go in p.GetPooledObjects()) {
                    //Could add an explosion
                    go.SetActive(false);
                }
            }
        }
    }

}
