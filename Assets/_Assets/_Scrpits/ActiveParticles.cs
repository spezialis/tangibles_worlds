using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveParticles : MonoBehaviour {

	public GameObject particle;

	public bool activeParticles;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (activeParticles) {
			particle.SetActive (true);
		}

		if (!activeParticles) {
			particle.SetActive (false);
		}

	}
}
