using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public enum TowerType {
        DAMAGE_MONO = 0,
        BREAK_ARMOR,
        FROST,
        AOE,
        POISON,
        UNKNOWN
    }

    public class TowerManagerScript : SingletonScript<TowerManagerScript>
    {
        [SerializeField]
        private GameObject[]                        _TowerCollections;
        private GameObject                          _parentGameObject;

        private Dictionary<Vector3, Tower>          _TowerDictionnary;

        private Vector3                             _potentialTowerPosition;

        private PooledObjectScript[]                _pooledTowerCollections;

        private const int                           CAPACITY = 3;

        public void Start()
        {
            _parentGameObject = new GameObject("TowerParent");
            _TowerDictionnary = new Dictionary<Vector3, Tower>();
            _pooledTowerCollections = new PooledObjectScript[_TowerCollections.Length];

            for (int i = 0; i < _TowerCollections.Length; ++i) {
                PooledObjectScript script = new PooledObjectScript(_TowerCollections[i], _parentGameObject.transform, CAPACITY, true);

                _pooledTowerCollections[i] = script;
            }        
        }

        public GameObject CreateTower(TowerType type) {
            GameObject gameObject =  _pooledTowerCollections[(int)type].GetPooledObject();

            gameObject.transform.position = _potentialTowerPosition;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.SetActive(true);

            Tower script = gameObject.GetComponent<Tower>();

            script.CreateTower();

            _TowerDictionnary.Add(_potentialTowerPosition, script);
            _potentialTowerPosition = Vector3.zero;

            return gameObject;
        }

        public GameObject CreateTower(Vector3 position, Quaternion rotation, TowerType type) {
            GameObject gameObject = _pooledTowerCollections[(int)type].GetPooledObject();

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.SetActive(true);

            Tower script = gameObject.GetComponent<Tower>();

            script.CreateTower();

            _TowerDictionnary.Add(_potentialTowerPosition, script);
            _potentialTowerPosition = Vector3.zero;

            return gameObject;
        }

        public bool UpgradeTower()
        {
            if (_potentialTowerPosition != Vector3.zero && 
                _TowerDictionnary.ContainsKey(_potentialTowerPosition)) {
                _TowerDictionnary[_potentialTowerPosition].UpgradeTower();

                return true;
            }
            return false;
        }

        public int GetPriceTower(TowerType type)
        {
            if (type == TowerType.DAMAGE_MONO)
            {
                return DamageMono._COST;
            }
            if (type == TowerType.BREAK_ARMOR)
            {
                return BreakArmor._COST;
            }
            if (type == TowerType.AOE)
            {
                return DamageAoE._COST;
            }
            if (type == TowerType.FROST)
            {
                return Frost._COST;
            }
            if (type == TowerType.POISON)
            {
                return Poison._COST;
            }
            return DamageMono._COST;

        }

        public string GetNameTower(TowerType type)
        {
            if (type == TowerType.DAMAGE_MONO)
            {
                return DamageMono._NAME;
            }
            if (type == TowerType.BREAK_ARMOR)
            {
                return BreakArmor._NAME;
            }
            if (type == TowerType.AOE)
            {
                return DamageAoE._NAME;
            }
            if (type == TowerType.FROST)
            {
                return Frost._NAME;
            }
            if (type == TowerType.POISON)
            {
                return Poison._NAME;
            }
            return DamageMono._NAME;

        }

        public Tower GetCurrentTower()
        {
            Tower script = _TowerDictionnary[_potentialTowerPosition];

            return script;
        }

        public bool DestroyTower()
        {
            if (_potentialTowerPosition != Vector3.zero &&
                _TowerDictionnary.ContainsKey(_potentialTowerPosition))
            {
                Tower script = _TowerDictionnary[_potentialTowerPosition];

                script.DestroyTower();

                _TowerDictionnary.Remove(_potentialTowerPosition);
                script.gameObject.SetActive(false);

                return true;
            }
            return false;
        }

        public bool CanBuildTower(Vector3 position) {
            return !_TowerDictionnary.ContainsKey(position);
        }

        public void DisplayTowerRange() {
            if (_TowerDictionnary.ContainsKey(_potentialTowerPosition))
                _TowerDictionnary[_potentialTowerPosition].ShowRange();
        }

        public void HideTowerRange() {
            if (_TowerDictionnary.ContainsKey(_potentialTowerPosition))
                _TowerDictionnary[_potentialTowerPosition].HideRange();
        }

        public void SetPotentialPosition(Vector3 v) {
            _potentialTowerPosition = v;
        }

        public void DestroyTowers()
        {
            foreach (PooledObjectScript p in _pooledTowerCollections)
            {
                foreach (GameObject go in p.GetPooledObjects())
                {
                    //Could add an explosion
                    _TowerDictionnary.Clear();

                    go.SetActive(false);
                }
            }
        }

    }
}
