using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress_ScreenShot : MonoBehaviour {

	
	public void ButtonPress_SC (){
		
		ScreenCapture.CaptureScreenshot ("Screenshot.png");
	}
}
