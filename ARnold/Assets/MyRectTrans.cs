using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRectTrans : MonoBehaviour {

	private RectTransform rect;

	// Use this for initialization
	void Start () {
		rect = this.GetComponent<RectTransform> ();
	}
	void Update () {
		rect.sizeDelta = new Vector2 (Screen.width, Screen.height);
	}
}
