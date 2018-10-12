using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public class FXManagerScript : SingletonScript<FXManagerScript>
    {
        [SerializeField]
        private GameObject[] _FXCollections;
        private GameObject _parentGameObject;

        private PooledObjectScript[] _pooledFXCollections;

        private const int CAPACITY = 10;

        public void Start()
        {
            _parentGameObject = new GameObject("FXParent");
            _pooledFXCollections = new PooledObjectScript[_FXCollections.Length];

            for (int i = 0; i < _FXCollections.Length; ++i)
            {
                PooledObjectScript script = new PooledObjectScript(_FXCollections[i], _parentGameObject.transform, CAPACITY, true);

                _pooledFXCollections[i] = script;
            }

        }

        public GameObject CreateFX(Vector3 position)
        {
            GameObject gameObject = _pooledFXCollections[Random.Range(0, _pooledFXCollections.Length)].GetPooledObject();

            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.transform.position = position;
            gameObject.SetActive(true);

            Debug.Log("create FX ");

            return gameObject;
        }
    }
}