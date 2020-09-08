using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowingUIItemScript : MonoBehaviour {

    public string CanvasName;

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
    Canvas _myCanvas;

    // Cache a reference to our parent canvas, so we don't repeatedly search for it.
    void Start() {
        _myCanvas = GameObject.Find(CanvasName).GetComponent<Canvas>();//GetComponentInParent<Canvas>().GetComponent<RectTransform>();
        transform.SetParent(_myCanvas.transform, false);
    }

    // Use LateUpdate to apply the UI follow after all movement & animation
    // for the frame has been applied, so we don't lag behind the unit.
    void LateUpdate()
    {
        if (objectToFollow && !objectToFollow.gameObject.activeInHierarchy) {
            transform.gameObject.SetActive(false);
        } else {
            transform.position = WorldToUISpace(_myCanvas, objectToFollow.transform.position + localOffset + screenOffset);
        }
    }

    private Vector3 WorldToUISpace(Canvas parentCanvas, Vector3 worldPos) {
        //Convert the world for screen point so that it can be used with ScreenPointToLocalPointInRectangle function
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        Vector2 movePos;

        //Convert the screenpoint to ui rectangle local point
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, screenPos, parentCanvas.worldCamera, out movePos);
        //Convert the local point to world point
        return parentCanvas.transform.TransformPoint(movePos);
    }
}
