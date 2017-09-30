using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCanvasForPlanes : MonoBehaviour {

	public GameObject CanvasScale;
	private GameObject canvasscale;

	public GameObject CanvasScaleiPad;
	private GameObject canvasscaleipad;

	
	// Update is called once per frame
	void Start () 
	{
		if (Screen.width == 750 && Screen.height == 1334) {
			canvasscale = Instantiate (CanvasScale);
		}

		if ((Screen.width == 2048 && Screen.height == 2732) || (Screen.width == 1668 && Screen.height == 2224)) {
			canvasscaleipad = Instantiate (CanvasScaleiPad);
		}
	}
}
