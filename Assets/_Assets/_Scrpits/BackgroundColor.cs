using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour {
	
	// TODO add a lerp to change the background color when a world is activate
	Camera camera;

	public GameObject picsWorld;
	public GameObject bubbleWorld;
	public GameObject wireWorld;

	public Color picsBackground;
	public Color bubbleBackground;
	public Color wireBackground;
	Color black = Color.black;

	public float duration = 1.0F;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (picsWorld.activeSelf) {
			camera.backgroundColor = Color.Lerp(black, picsBackground, duration);
		}

		if (bubbleWorld.activeSelf) {
			camera.backgroundColor = bubbleBackground;
		}

		if (wireWorld.activeSelf) {
			camera.backgroundColor = wireBackground;
		}
	}
}
