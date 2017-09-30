using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MyCanvasScale :  MonoBehaviour{

	private CanvasScaler canvasScaler;

	// Use this for initialization
	void Start () {
		canvasScaler = this.GetComponentInParent<CanvasScaler> ();
	}

	void Update () {
		canvasScaler.referenceResolution = new Vector2 (Screen.width, Screen.height);
	}
}
