using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense
{
    public enum BulletType
    {
        SIMPLE_BULLET,
        EXPLOSIVE_BULLET,
        POISONOUS_BULLET

    }


    public class BulletManagerScript : SingletonScript<BulletManagerScript>
    {
        [SerializeField]
        private GameObject[] _BulletsCollections;
        private GameObject _parentGameObject;

        private PooledObjectScript[] _pooledBulletsCollections;

        private const int CAPACITY = 30;

        public void Start()
        {
            _parentGameObject = new GameObject("BulletParent");
            _pooledBulletsCollections = new PooledObjectScript[_BulletsCollections.Length];

            for (int i = 0; i < _BulletsCollections.Length; ++i)
            {
                PooledObjectScript script = new PooledObjectScript(_BulletsCollections[i], _parentGameObject.transform, CAPACITY, true);

                _pooledBulletsCollections[i] = script;
            }

        }

        public GameObject CreateBullet(BulletType type)
        {
            GameObject gameObject = _pooledBulletsCollections[(int)type].GetPooledObject();

            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.SetActive(true);

            return gameObject;
        }

        public GameObject CreateBullet(Vector3 position, Quaternion rotation, BulletType type)
        {
            GameObject gameObject = _pooledBulletsCollections[(int)type].GetPooledObject();

            gameObject.transform.position = position;
            gameObject.transform.rotation = rotation;
            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.SetActive(true);

            return gameObject;
        }
    }
}