﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicsWorldMenager : WorldManager {

	private static PicsWorldMenager instance;

	public Animation wallPics1;
	public Animation wallPics2;
	public Animation wallPics3;
	public Animation wallPics4;

	// TODO: Check which wall is active and if all 4 are, animate the whole world id:16 gh:6

	public override void SetWallState( int index, bool active ) {
		switch (index) {
		case 1:
			wallPics1.enabled = active;
			break;
		case 2:
			wallPics2.enabled = active;
			break;
		case 3:
			wallPics3.enabled = active;
			break;
		case 4:
			wallPics4.enabled = active;
			break;
		default:
			break;
		}
	}

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Don't override this update
//	void Update () {
//		
//	}
}

