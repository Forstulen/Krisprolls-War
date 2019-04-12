using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class GenerateEnemyScript : MonoBehaviour
    {

        public void GenerateLightEnemy()
        {
            GameObject go = EnemyManagerScript.Instance.CreateEnemy(EnemyType.LIGHT_ENEMY, FollowingPath.MAIN_PATH, 1.0f);

            Enemy enemy =  go.GetComponent<Enemy>();

            enemy.Create();
        }

        public void GenerateMediumEnemy()
        {
            GameObject go = EnemyManagerScript.Instance.CreateEnemy(EnemyType.MEDIUM_ENEMY, FollowingPath.MAIN_PATH, 1.0f);

            go.GetComponent<Enemy>().Create();
        }

        public void GenerateHeavyEnemy()
        {
            GameObject go = EnemyManagerScript.Instance.CreateEnemy(EnemyType.HEAVY_ENEMY, FollowingPath.MAIN_PATH, 1.0f);

            go.GetComponent<Enemy>().Create();
        }

        public void GenerateHeavyKnightEnemy()
        {
            GameObject go = EnemyManagerScript.Instance.CreateEnemy(EnemyType.HEAVY_KNIGHT_ENEMY, FollowingPath.MAIN_PATH, 1.0f);

            go.GetComponent<Enemy>().Create();
        }

        public void GenerateSpeedEnemy()
        {
            GameObject go = EnemyManagerScript.Instance.CreateEnemy(EnemyType.SPEED_ENEMY, FollowingPath.MAIN_PATH, 1.0f);

            go.GetComponent<Enemy>().Create();
        }
    }
}
