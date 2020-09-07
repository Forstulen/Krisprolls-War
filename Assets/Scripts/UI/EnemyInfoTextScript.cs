﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    [RequireComponent(typeof(Text))]
    public class EnemyInfoTextScript : MonoBehaviour
    {
        // Assign this to the object you want the health bar to track:
        public Transform objectToFollow;

        // This lets us tweak the anchoring position in the object's local space
        // eg. if you want the bar to appear above the unit's head.
        public Vector3 localOffset;

        // This lets us tweak the anchoring position in our canvas space
        // eg. if we want the UI to sit off to the right on our screen.
        public Vector3 screenOffset;

        // Cached reference to the canvas containing this object.
        // We'll use this to position it correctly
        RectTransform _myCanvas;


        // Cache a reference to our parent canvas, so we don't repeatedly search for it.
        void Start()
        {
            _myCanvas = GameObject.Find("HUDCanvas").GetComponent<RectTransform>();//GetComponentInParent<Canvas>().GetComponent<RectTransform>();
            transform.SetParent(_myCanvas, false);
        }



        // Use LateUpdate to apply the UI follow after all movement & animation
        // for the frame has been applied, so we don't lag behind the unit.
        void LateUpdate()
        {
            if (objectToFollow && !objectToFollow.gameObject.activeInHierarchy)
            {
                transform.gameObject.SetActive(false);
            }
            else
            {

                // Translate our anchored position into world space.
                Vector3 worldPoint = objectToFollow.TransformPoint(localOffset);

                // Translate the world position into viewport space.
                Vector3 viewportPoint = Camera.main.WorldToViewportPoint(worldPoint);

                // Canvas local coordinates are relative to its center, 
                // so we offset by half. We also discard the depth.
                viewportPoint -= 0.5f * Vector3.one;
                viewportPoint.z = 0;

                // Scale our position by the canvas size, 
                // so we line up regardless of resolution & canvas scaling.
                Rect rect = _myCanvas.rect;
                viewportPoint.x *= rect.width;
                viewportPoint.y *= rect.height;

                // Add the canvas space offset and apply the new position.
                transform.localPosition = viewportPoint + screenOffset;
            }
        }
    }
}