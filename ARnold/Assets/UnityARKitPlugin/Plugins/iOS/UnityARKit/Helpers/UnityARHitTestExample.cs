using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace UnityEngine.XR.iOS
{
	public class UnityARHitTestExample : MonoBehaviour
	{
		
		private Animation anim_sc1;
		public GameObject SC2;
		public GameObject SC4;
		public GameObject SC5;
		public GameObject SC6;
		public GameObject SC7;
		public GameObject TC2;
		public GameObject TC3;
		public GameObject TC4;
		public GameObject TC5;
		public GameObject TC6;
		public GameObject TC2_iPad;
		public GameObject TC3_iPad;
		public GameObject TC4_iPad;
		public GameObject TC5_iPad;
		public GameObject TC6_iPad;
		public GameObject EC;
		public GameObject Dummy;
		public GameObject Dummy_iPad;
		public GameObject EndCard;
		public GameObject EndCard_iPad;

		private GameObject sc2;
		private GameObject sc4;
		private GameObject sc5;
		private GameObject sc6;
		private GameObject sc7;
		private GameObject tc2;
		private GameObject tc3;
		private GameObject tc4;
		private GameObject tc5;
		private GameObject tc6;
		private GameObject tc2_ipad;
		private GameObject tc3_ipad;
		private GameObject tc4_ipad;
		private GameObject tc5_ipad;
		private GameObject tc6_ipad;
		private GameObject ec;
		private GameObject dummy;
		private GameObject dummy_ipad;
		private GameObject endcard;
		private GameObject endcard_ipad;
		public GameObject Planes;

		public Transform m_HitTransform;

		//AudioSource and AudioClips
		public AudioSource Main;
		public AudioSource Scene1_Arnold;
		private AudioSource Scene4_Arnold;
		private AudioSource Scene5_Arnold;
		private AudioSource Scene6_Arnold;
		private AudioSource Scene7_Arnold;

		public AudioClip BeforeTC2;
		public AudioClip BeforeTC3;
		public AudioClip BeforeTC4;
		public AudioClip BeforeTC5;
		public AudioClip BeforeTC6;

		public AudioClip Scanning;
		public AudioClip Scene1;
		public AudioClip Scene4;
		public AudioClip Scene5;
		public AudioClip Scene6;
		public AudioClip Scene7;
		public AudioClip EndCredits_Audio;


		int flag = 0;
		int flag1 = 0;

        bool HitTestWithResultType (ARPoint point, ARHitTestResultType resultTypes)
        {
            List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface ().HitTest (point, resultTypes);
            if (hitResults.Count > 0) {
                foreach (var hitResult in hitResults) {
                    Debug.Log ("Got hit!");
                    m_HitTransform.position = UnityARMatrixOps.GetPosition (hitResult.worldTransform);
                    m_HitTransform.rotation = UnityARMatrixOps.GetRotation (hitResult.worldTransform);
                    Debug.Log (string.Format ("x:{0:0.######} y:{1:0.######} z:{2:0.######}", m_HitTransform.position.x, m_HitTransform.position.y, m_HitTransform.position.z));
                    return true;
                }
            }
            return false;
        }

		void Start (){
			anim_sc1 = this.GetComponent<Animation> ();
		}

		// Update is called once per frame
		void Update () {
			if (Input.touchCount > 0 && m_HitTransform != null)
			{
				var touch = Input.GetTouch(0);
				if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(0) && flag==0)
				{
                    // if the user taps the screen in amera mode then it enters the condition and excutes only once
                    // this flag sets to 1 indicating that this condition will never be entered again
                    // this is done so that the story stays in the same place when the user taps in all the subsequesnt scenes
					flag = 1;

					transform.localPosition = Vector3.zero;
					var screenPosition = Camera.main.ScreenToViewportPoint(touch.position);
					ARPoint point = new ARPoint {
						x = screenPosition.x,
						y = screenPosition.y
					};

                    // prioritize results types
                    ARHitTestResultType[] resultTypes = {
                        ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent, 
                        // if you want to use infinite planes use this:
                        //ARHitTestResultType.ARHitTestResultTypeExistingPlane,
                        ARHitTestResultType.ARHitTestResultTypeHorizontalPlane, 
                        ARHitTestResultType.ARHitTestResultTypeFeaturePoint
                    }; 
						
                    foreach (ARHitTestResultType resultType in resultTypes)
                    {
                        if (HitTestWithResultType (point, resultType))
                        {
                            // if user taps screen then it spawns screen 1
							Spawn_Scene1 ();
                            return;
                        }
                    }
				}
			}

			// TC2
			if (((tc2.activeInHierarchy == false) || (tc2_ipad.activeInHierarchy == false)) && flag1 == 1) {
				flag1 = 2;

				// Instantiate Scene4 animation
				sc4 = Instantiate (SC4, this.transform.position, this.transform.rotation);
				Scene4_Arnold = sc4.transform.Find ("Beagle4").gameObject.GetComponent<AudioSource> ();
				Scene4_Arnold.clip = Scene4;
				Main.Stop ();
				Scene4_Arnold.Play ();

				StartCoroutine (Scene4_wait ());
				// jump to tag Scene4_wait
			}

			// TC3
			if (((tc3.activeInHierarchy == false) || (tc3_ipad.activeInHierarchy == false)) && flag1 == 2) {
				flag1 = 3;

				// Instantiate Scene5 animation
				sc5 = Instantiate (SC5, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 1.0f), this.transform.rotation);
				Scene5_Arnold = sc5.transform.Find ("Beagle5").gameObject.GetComponent<AudioSource> ();
				Scene5_Arnold.clip = Scene5;
				Main.Stop ();
				Scene5_Arnold.Play ();

				StartCoroutine (Scene5_wait ());
				// jump to tag Scene5_wait
			}

			// TC4
			if (((tc4.activeInHierarchy == false) || (tc4_ipad.activeInHierarchy == false)) && flag1 == 3) {
				flag1 = 4;

				// Instantiate Scene6 animation
				sc6 = Instantiate (SC6, this.transform.position, this.transform.rotation);
				Scene6_Arnold = sc6.transform.Find ("Beagle6").gameObject.GetComponent<AudioSource> ();
				Scene6_Arnold.clip = Scene6;
				Main.Stop ();
				Scene6_Arnold.Play ();

				StartCoroutine (Scene6_wait ());
				// jump to tag Scene6_wait
			}

			// TC5
			if (((tc5.activeInHierarchy == false) || (tc5_ipad.activeInHierarchy == false)) && flag1 == 4) {
				flag1 = 5;

				// Instantiate Scene7 animation
				sc7 = Instantiate (SC7, this.transform.position, this.transform.rotation);
				Scene7_Arnold = sc7.transform.Find ("Beagle7").gameObject.GetComponent<AudioSource> ();
				Scene7_Arnold.clip = Scene7;
				Main.Stop ();
				Scene7_Arnold.Play ();

				StartCoroutine (Scene7_wait ());
				// jump to tag Scene7_wait
			}

			// TC6
			if ((Screen.width == 750 && Screen.height == 1334) && ((tc6.activeInHierarchy == false) || (tc6_ipad.activeInHierarchy == false)) && flag1 == 5) {
				flag1 = 6;

				// Instantiate End Credits animation
				ec = Instantiate (EC, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 1.0f), this.transform.rotation);
				Main.clip = EndCredits_Audio;
				Main.Play ();
				dummy = Instantiate (Dummy);
			}

			// TC6_iPad
			if (((Screen.width == 2048 && Screen.height == 2732) || (Screen.width == 1668 && Screen.height == 2224)) && ((tc6.activeInHierarchy == false) || (tc6_ipad.activeInHierarchy == false)) && flag1 == 5) {
				flag1 = 6;

				// Instantiate End Credits animation
				ec = Instantiate (EC, new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z - 1.0f), this.transform.rotation);
				Main.clip = EndCredits_Audio;
				Main.Play ();
				dummy_ipad = Instantiate (Dummy_iPad);
			}

			// Dummy
			if ((Screen.width == 750 && Screen.height == 1334) && ((dummy.activeInHierarchy == false) || (dummy_ipad.activeInHierarchy == false)) && flag1 == 6) {
				flag1 = 7;

				// Instantiate End title card
				Main.Stop ();
				endcard = Instantiate (EndCard);
			}

			// Dummy_IPad
			if (((Screen.width == 2048 && Screen.height == 2732) || (Screen.width == 1668 && Screen.height == 2224)) && ((dummy.activeInHierarchy == false) || (dummy_ipad.activeInHierarchy == false)) && flag1 == 6) {
				flag1 = 7;

				// Instantiate End title card
				Main.Stop ();
				endcard_ipad = Instantiate (EndCard_iPad);
			}

			// endcard
			if (((endcard.activeInHierarchy == false) || (endcard_ipad.activeInHierarchy == false)) && flag1 == 7) {
				flag1 = 5;
			}
		} 

		// MasterControl script takes care of StartCard, UserTap and TitleCard1
		// After that Scene1 animation starts
		void Spawn_Scene1 () {
			Planes.SetActive (false);
			Destroy (Planes);
			//this.transform.LookAt(Camera.main.transform);
			anim_sc1.Play ();
			Scene1_Arnold.clip = Scene1;
			Main.Stop ();
			Scene1_Arnold.Play ();
			StartCoroutine (Scene1_wait ());
		}

		IEnumerator Scene1_wait () {
			yield return new WaitForSeconds (anim_sc1.clip.length + 2);
			for(int i=0; i< this.transform.childCount; i++)
			{
				var child = this.transform.GetChild(i).gameObject;
				if(child != null)
					child.SetActive(false);
			}

			// After Scene1 animation finishes start TitleCard2
			if (Screen.width == 750 && Screen.height == 1334) {
				tc2 = Instantiate (TC2);
			}else{
				tc2_ipad = Instantiate (TC2_iPad);
			}
			Main.clip = BeforeTC2;
			Main.Play ();
			flag1 = 1;
			// jump to update function tag TC2
		}

		// Scene4_wait: wait for Scene4 to finish
		IEnumerator Scene4_wait () {
			yield return new WaitForSeconds (sc4.GetComponent<Animation> ().clip.length + 2);
			GameObject.DestroyImmediate (sc4);
			if (Screen.width == 750 && Screen.height == 1334) {
				tc3 = Instantiate (TC3);
			}else{
				tc3_ipad = Instantiate (TC3_iPad);
			}
			Main.clip = BeforeTC3;
			Main.Play ();
		}

		// Scene5_wait: wait for Scene5 to finish
		IEnumerator Scene5_wait () {
			yield return new WaitForSeconds (sc5.GetComponent<Animation> ().clip.length + 2);
			GameObject.DestroyImmediate (sc5);
			if (Screen.width == 750 && Screen.height == 1334) {
				tc4 = Instantiate (TC4);
			}else{
				tc4_ipad = Instantiate (TC4_iPad);
			}
			Main.clip = BeforeTC4;
			Main.Play ();
		}

		// Scene6_wait: wait for Scene6 to finish
		IEnumerator Scene6_wait () {
			yield return new WaitForSeconds (sc6.GetComponent<Animation> ().clip.length + 2);
			GameObject.DestroyImmediate (sc6);
			if (Screen.width == 750 && Screen.height == 1334) {
				tc5 = Instantiate (TC5);
			}else{
				tc5_ipad = Instantiate (TC5_iPad);
			}
			Main.clip = BeforeTC5;
			Main.Play ();
		}
			
		// Scene7_wait: wait for Scene7 to finish
		IEnumerator Scene7_wait () {
			yield return new WaitForSeconds (sc7.GetComponent<Animation> ().clip.length + 2);
			GameObject.DestroyImmediate (sc7);
			if (Screen.width == 750 && Screen.height == 1334) {
				tc6 = Instantiate (TC6);
			}else{
				tc6_ipad = Instantiate (TC6_iPad);
			}
			Main.clip = BeforeTC6;
			Main.Play ();
		}
	}
}

