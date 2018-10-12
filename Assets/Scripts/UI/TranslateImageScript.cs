using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TranslateImageScript : MonoBehaviour {

    public float Speed;
    private RectTransform   _rect;
    private float           _limit;

	// Use this for initialization
	void Start () {
        _rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        _rect.position = new Vector3(_rect.position.x + Speed * Time.deltaTime, _rect.position.y, _rect.position.y);

        if (_rect.localPosition.x >= _limit)
            Destroy(gameObject);
	}

    public void SetLimit(float max) {
        _limit = max;
    }
}
