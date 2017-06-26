using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistPosition : MonoBehaviour {

	public bool megaTwistEnable = false;
	public MegaTwist megaTwist;

	// Use this for initialization
	void Start () {
//		megaTwist = GetComponent<MegaTwist> ();

		megaTwist.gizmoPos = new Vector3(0, -1.5f, 0);
		megaTwist.gizmoScale = new Vector3 (1, 1.9f, 1);

		megaTwist.from = -0.5f;
		megaTwist.to = 0.5f;

		megaTwist.angle = 50;
		megaTwist.Bias = 30;

		megaTwist.axis = MegaAxis.Z;
	}

	// Update is called once per frame
	void Update () {

		float posY = Mathf.PingPong (Time.time, 4 - 1) - 1.5f;
		megaTwist.gizmoPos = new Vector3(0, posY, 0);
	
	}
}
