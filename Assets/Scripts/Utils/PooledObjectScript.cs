using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class PooledObjectScript
    {

        //Attributes
        private GameObject  _pooledObject;
        private int         _Number;
        private bool        _canGrow;
        private Transform   _parent;

        private List<GameObject> _pooledObjects;

        public PooledObjectScript(GameObject obj, Transform parent, int capacity, bool canGrow)
        {
            _pooledObject = obj;
            _Number = capacity;
            _canGrow = canGrow;
            _parent = parent;
            _pooledObjects = new List<GameObject>(capacity);

            for (int i = 0; i < capacity; ++i)
            {
                InstantiatePooledObject(parent);
            }
        }

        private GameObject InstantiatePooledObject(Transform parent)
        {
            GameObject gameObject = Object.Instantiate(_pooledObject);
            gameObject.SetActive(false);
            gameObject.transform.parent = parent;
            gameObject.name = gameObject.name + _pooledObjects.Count;
            _pooledObjects.Add(gameObject);

            return gameObject;
        }

        public GameObject GetPooledObject()
        {
            foreach (GameObject go in _pooledObjects)
            {
                if (!go.activeInHierarchy)
                {
                    return go;
                }
            }

            if (_canGrow)
            {
                _Number++;
                return InstantiatePooledObject(_parent);
            }
            return null;
        }

        public int Count() {
            int count = 0;

            foreach (GameObject go in _pooledObjects)
            {
                if (go.activeInHierarchy)
                {
                    ++count;
                }
            }

            return count;
        }

        public List<GameObject> GetPooledObjects() {
            return _pooledObjects;
        }


    }

}
