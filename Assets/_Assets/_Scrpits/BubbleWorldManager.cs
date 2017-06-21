using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleWorldManager : WorldManager {

	private static BubbleWorldManager instance;

	// Walls spheres
	// TODO: Make a better animation for this spheres, start whit a grown and then mouve them.
	// TODO: Check ho to simcronize the MegaPointCache animation whit the bubbles animations.
	public Animation wallBubbles1;
	public Animation wallBubbles2;
	public Animation wallBubbles3;
	public Animation wallBubbles4;

	// Walls surfaces
	public MegaPointCache wallSurface1;
	public MegaPointCache wallSurface2;
	public MegaPointCache wallSurface3;
	public MegaPointCache wallSurface4;

	// Walls sounds
	public AudioSource wallSound1;
	public AudioSource wallSound2;
	public AudioSource wallSound3;
	public AudioSource wallSound4;


	public override void SetWallState( int index, bool active ) {
		switch (index) {
		case 1:
			wallBubbles1.enabled = active;
			wallSurface1.animated = active;
			wallSound1.enabled = active;
			break;

		case 2:
			wallBubbles2.enabled = active;
			wallSurface2.animated = active;
			wallSound2.enabled = active;
			break;

		case 3:
			wallBubbles3.enabled = active;
			wallSurface3.animated = active;
			wallSound3.enabled = active;
			break;

		case 4:
			wallBubbles4.enabled = active;
			wallSurface4.animated = active;
			wallSound1.enabled = active;
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
