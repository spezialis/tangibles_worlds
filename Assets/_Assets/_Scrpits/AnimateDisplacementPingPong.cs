using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDisplacementPingPong : MonoBehaviour {

	public MegaDisplace cut;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		cut.amount += 0.0001f;

		if (cut.amount >= 0.01f) {
			cut.amount = 0.01f;

			// PingPong lerp
			cut.offset = new Vector2(Mathf.PingPong(Time.time, 3), Mathf.PingPong(Time.time, 0.1f));
		}
	}
}
