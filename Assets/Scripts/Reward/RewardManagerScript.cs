using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public enum RewardType {
        CHEST = 0,
        NONE
    }

    public class RewardManagerScript : SingletonScript<RewardManagerScript>
    {
        [SerializeField]
        private GameObject[] _RewardCollection;
        private GameObject _parentGameObject;

        private PooledObjectScript[] _pooledRewardCollections;

        private const int CAPACITY = 3;

        public void Start()
        {
            _parentGameObject = new GameObject("RewardParent");
            _pooledRewardCollections = new PooledObjectScript[_RewardCollection.Length];

            for (int i = 0; i < _pooledRewardCollections.Length; ++i)
            {
                PooledObjectScript script = new PooledObjectScript(_RewardCollection[i], _parentGameObject.transform, CAPACITY, true);

                _pooledRewardCollections[i] = script;
            }

        }

        public GameObject CreateReward(RewardType type, int golds, Vector3 position)
        {
            return InternalCreateReward(type, golds, position);
        }

        public GameObject CreateReward(RewardType type, int golds)
        {
            return InternalCreateReward(type, golds, GetRandomPosition());
        }

        private GameObject InternalCreateReward(RewardType type, int golds, Vector3 position) {
            GameObject gameObject = _pooledRewardCollections[(int)type].GetPooledObject();

            gameObject.transform.parent = _parentGameObject.transform;
            gameObject.transform.position = position;
            gameObject.SetActive(true);

            Debug.Log("create reward ");

            RewardScript script = gameObject.GetComponent<RewardScript>();

            script.Initialize(golds);

            return gameObject;
        }

        private Vector3 GetRandomPosition() {
            return new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), 0.0f);
        }
    }

}