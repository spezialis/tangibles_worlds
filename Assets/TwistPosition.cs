using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistPosition : MonoBehaviour {

	public MegaTwist megaTwist;

	// Use this for initialization
	void Start () {
		megaTwist.gizmoPos = new Vector3(0, -1.5f, 0);
	}

	// Update is called once per frame
	void Update () {
		float posY = Mathf.PingPong (Time.time, 4 - 1) - 1.5f;
		megaTwist.gizmoPos = new Vector3(0, posY, 0);
	}
}
