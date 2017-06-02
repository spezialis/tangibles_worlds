using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerDebugger : MonoBehaviour {

	WorldManager reference;

	public bool animateWall1;
	public bool animateWall2;
	public bool animateWall3;
	public bool animateWall4;

	void Start () {
		reference = GetComponent<WorldManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (reference) {
			reference.SetWallState(1, animateWall1);
			reference.SetWallState(2, animateWall2);
			reference.SetWallState(3, animateWall3);
			reference.SetWallState(4, animateWall4);
		}
	}
}
