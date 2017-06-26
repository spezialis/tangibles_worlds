using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OculusRemoteControl : MonoBehaviour {

	void Restart() {
		SceneManager.LoadScene (0);
	}

	void OnButton() {
		Restart ();
	}

	void Start () {
		
	}
	
	void Update () {
		if (OVRInput.GetDown(OVRInput.Button.Any, OVRInput.Controller.Remote)) {
			Debug.Log ("Pressed a button on the remote");
			OnButton ();
		}
	}
}
