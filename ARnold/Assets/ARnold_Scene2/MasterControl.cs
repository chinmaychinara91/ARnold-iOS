using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterControl : MonoBehaviour {

	public GameObject StartCard;
	private GameObject startcard;

	public GameObject StartCard_iPad;
	private GameObject startcard_ipad;

	public GameObject HereBoyCard;
	private GameObject hereboycard;

	public GameObject HereBoyCard_iPad;
	private GameObject hereboycard_ipad;

	public GameObject TC1;
	private GameObject tc1;

	public GameObject TC1_iPad;
	private GameObject tc1_ipad;

	public GameObject BeforeScanningCard;
	private GameObject beforescanningcard;

	public GameObject BeforeScanningCard_iPad;
	private GameObject beforescanningcard_ipad;

	//AudioSource and AudioClips
	public AudioSource Main;
	public AudioClip BeforeTC1;

	int flag = 1;
	int flag_res = 1;

	// Use this for initialization
	void Start () {
		if (Screen.width == 750 && Screen.height == 1334) {
			startcard = Instantiate (StartCard);
			Debug.Log ("7");
		}
		else if ((Screen.width == 2048 && Screen.height == 2732) || (Screen.width == 1668 && Screen.height == 2224)) {
			startcard_ipad = Instantiate (StartCard_iPad);
			Debug.Log ("10");
			flag_res = 2;
		}
	}

	void Update ()	{
		if (flag_res == 1) {
			if (startcard.activeInHierarchy == false && flag == 1) {
				hereboycard = Instantiate (HereBoyCard);
				flag = 2;
				Debug.Log ("7_1");
			}

			if (startcard.activeInHierarchy == false && hereboycard.activeInHierarchy == false && flag == 2) {		
				tc1 = Instantiate (TC1);
				Main.clip = BeforeTC1;
				Main.Play ();
				flag = 3;
				Debug.Log ("7_2");
			}

			if (startcard.activeInHierarchy == false && hereboycard.activeInHierarchy == false && tc1.activeInHierarchy == false && flag == 3) {		
				beforescanningcard = Instantiate (BeforeScanningCard);
				Main.Stop ();
				flag = 4;
				Debug.Log ("7_3");
			}

		} else {
			if (startcard_ipad.activeInHierarchy == false && flag == 1) {
				hereboycard_ipad = Instantiate (HereBoyCard_iPad);
				flag = 2;
				Debug.Log ("10_1");
			}

			if(startcard_ipad.activeInHierarchy == false && hereboycard_ipad.activeInHierarchy == false && flag == 2) {		
				tc1_ipad = Instantiate (TC1_iPad);
				Main.clip = BeforeTC1;
				Main.Play ();
				flag = 3;
				Debug.Log ("10_2");
			}

			if (startcard_ipad.activeInHierarchy == false && hereboycard_ipad.activeInHierarchy == false && tc1_ipad.activeInHierarchy == false && flag == 3) {		
				beforescanningcard_ipad = Instantiate (BeforeScanningCard_iPad);
				Main.Stop ();
				flag = 4;
				Debug.Log ("10_3");
			}
		}
	}
}
