using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// initialisation DoTween
using DG.Tweening;

public class DisplayWorld : MonoBehaviour {

	public GameObject world;
	//public Transform world;

	Vector3 startScale = new Vector3(0, 0, 0);
	Vector3 endScale = new Vector3(35, 35, 35);

	public float scaleDuration;
//	public bool scaleWorld;

	// Use this for initialization
	void Start () {

		// TODO: transform world scale when someone put his hand inside a box
		// Active the world

	}
	
	// Update is called once per frame
	void Update () {

//		if (scaleWorld) {

		world.SetActive (true);

		world.GetComponent<Transform>().localScale = startScale;

			world.transform.DOScale (endScale, scaleDuration);
//		}

//		if (!scaleWorld) {
//			world.transform.DOScale (startScale, 0.5f);
//		}
	}
}
