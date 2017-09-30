using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArnoldControl : MonoBehaviour {

	public GameObject g;

	public void ButtonPress()
	{
		//g.GetComponent<Canvas> ().enabled = false;
		g.SetActive(false);
	}
}
