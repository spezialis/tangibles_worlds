using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour {

	Animator anim;

	public float restartDelay;
	float restartTimer;

	void Awake () {
		anim = GetComponent<Animator> ();
	}

	void Update () {
		// TODO: When the user finish the experience show the credits
		if (Input.GetKey ("space")) {
			anim.SetTrigger("ShowCredits");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				// TODO: restart application or experience
				// QUESTION: there is another way to reload the whole experience? For example when the user remove the headset?
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
