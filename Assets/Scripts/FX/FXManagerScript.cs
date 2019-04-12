using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class FXManagerScript : SingletonScript<FXManagerScript>
    {
        [SerializeField]
        private GameObject[] _FXCollections;
        [SerializeField]
        private GameObject[] _ExplosionCollections;

        private GameObject _parentGameObject;

        private PooledObjectScript[] _pooledFXCollections;

        private PooledObjectScript[] _pooledExplosionCollections;

        private const int CAPACITY = 10;

        public void Start()
        {
            _parentGameObject = new GameObject("FXParent");
            _pooledFXCollections = new PooledObjectScript[_FXCollections.Length];
            _pooledExplosionCollections = new PooledObjectScript[_ExplosionCollections.Length];

            for (int i = 0; i < _FXCollections.Length; ++i)
            {
                _FXCollections[i].SetActive(false);

                PooledObjectScript script = new PooledObjectScript(_FXCollections[i], _parentGameObject.transform, CAPACITY, true);

                _pooledFXCollections[i] = script;
            }

            for (int i = 0; i < _ExplosionCollections.Length; ++i)
            {
                _ExplosionCollections[i].SetActive(false);

                PooledObjectScript script = new PooledObjectScript(_ExplosionCollections[i], _parentGameObject.transform, CAPACITY, true);

                _pooledExplosionCollections[i] = script;
            }

        }

        public GameObject CreateFX(Vector3 position)
        {
            GameObject gameObject = _pooledFXCollections[Random.Range(0, _pooledFXCollections.Length)].GetPooledObject();

            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.transform.position = position;
            gameObject.SetActive(true);

            return gameObject;
        }

        public GameObject CreateExplosion(Vector3 position)
        {
            GameObject gameObject = _pooledExplosionCollections[Random.Range(0, _pooledExplosionCollections.Length)].GetPooledObject();

            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.transform.position = position;
            gameObject.SetActive(true);

            return gameObject;
        }
    }
}