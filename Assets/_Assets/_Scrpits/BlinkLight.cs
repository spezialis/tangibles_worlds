using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLight : MonoBehaviour {

	public float duration;
	Light light;

	void Start () {
		light = GetComponent<Light> ();
	}

	void Update () {
		float lerp = Mathf.PingPong (Time.time, duration) / duration;
		//float lerp = Mathf.PingPong (Time.time, duration);

		// Change the color of the material
		light.range = Mathf.Lerp (100, 200, lerp);
	}
}
