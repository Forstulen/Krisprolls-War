using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    [RequireComponent(typeof(LineRenderer))]
    public class DisplayRadiusScript : MonoBehaviour
    {
        [Range(0, 100)]
        public int segments = 100;
        [Range(0, 5)]
        public float xradius = 5;
        [Range(0, 5)]
        public float yradius = 5;
        LineRenderer line;

        void Start()
        {
            line = gameObject.GetComponent<LineRenderer>();

            line.positionCount = segments + 1;
            line.useWorldSpace = false;
            CreatePoints();
        }

        void CreatePoints()
        {
            float x;
            float y;
            float z;

            float angle = 20f;

            for (int i = 0; i < (segments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
                y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

                line.SetPosition(i, new Vector3(x, y, -2));

                angle += (360f / segments);
            }
        }
    }
}
