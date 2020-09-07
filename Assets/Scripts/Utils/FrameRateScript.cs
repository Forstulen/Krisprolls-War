using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateScript : MonoBehaviour {

    public int FrameRate = 60;

	// Use this for initialization
	void Start () {
        Application.targetFrameRate = FrameRate;
	}
}
