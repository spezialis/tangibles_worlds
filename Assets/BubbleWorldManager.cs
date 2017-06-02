using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWorldManager : WorldManager {

	private static BubbleWorldManager instance;

//	public static void SetWallState1 ( bool active ) {
//		instance.SetWallState (1, active);
//	}
//
//	public static void SetWallState2 ( bool active ) {
//		instance.SetWallState (2, active);
//	}
//
//	public static void SetWallState3 ( bool active ) {
//		instance.SetWallState (3, active);
//	}
//
//	public static void SetWallState4 ( bool active ) {
//		instance.SetWallState (4, active);
//	}

	public Animation wall1_bubbles;
	public MegaPointCache wall1_surface;
	public AudioSource wall1_sound;

	public Animation wall2_bubbles;
	public MegaPointCache wall2_surface;
	// TODO public AudioSource wall2_sound;

	public Animation wall3_bubbles;
	public MegaPointCache wall3_surface;

	public Animation wall4_bubbles;
	public MegaPointCache wall4_surface;

	public override void SetWallState( int index, bool active ) {
		switch (index) {
		case 1:
			wall1_bubbles.enabled = active;
			wall1_surface.animated = active;
			wall1_sound.enabled = active;
			break;
		case 2:
			wall2_bubbles.enabled = active;
			wall2_surface.animated = active;
			break;
		case 3:
			wall3_bubbles.enabled = active;
			wall3_surface.animated = active;
			break;
		case 4:
			wall4_bubbles.enabled = active;
			wall4_surface.animated = active;
			break;
		default:
			break;
		}
	}

	void Start () {
		instance = this;
	}

//	void Update () {
//	}
}
