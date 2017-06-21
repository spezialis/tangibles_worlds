using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireWorldManager : WorldManager {

	private static WireWorldManager instance;

//	public Animation wallWire1;
//	public Animation wallWire2;
//	public Animation wallWire3;
//	public Animation wallWire4;

	public MegaDisplace cut;
	public MegaDisplace cut1;
	public MegaDisplace cut2;
	public MegaDisplace cut3;

	public AudioSource wallSound1;
	public AudioSource wallSound2;
	public AudioSource wallSound3;
	public AudioSource wallSound4;

	public override void SetWallState( int index, bool active ) {
		switch (index) {
		case 1:
			// Animate displacement
			cut.ModEnabled = active;

			cut.amount += 0.001f;

			if (cut.amount >= 0.01f) {
				cut.amount = 0.01f;

				// PingPong lerp
				cut.offset = new Vector2(Mathf.PingPong(Time.time, 3), Mathf.PingPong(Time.time, 3));
			}

			// Sound
			wallSound1.enabled = active;

			break;

		case 2:
			// Animate displacement
			cut1.ModEnabled = active;
		
			cut1.amount += 0.001f;

			if (cut1.amount >= 0.01f) {
				cut1.amount = 0.01f;

				// PingPong lerp
				cut1.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
			}

			// Sound
			wallSound2.enabled = active;
			break;

		case 3:
			// Animate displacement
			cut2.ModEnabled = active;
				
			cut2.amount += 0.001f;

			if (cut2.amount >= 0.01f) {
				cut2.amount = 0.01f;

				// PingPong lerp
				cut2.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
			}

			// Sound
			wallSound3.enabled = active;
			break;

		case 4:
			// Animate displacement
			cut3.ModEnabled = active;

			cut3.amount += 0.001f;

			if (cut3.amount >= 0.01f) {
				cut3.amount = 0.01f;

				// PingPong lerp
				cut3.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
			}

			// Sound
			wallSound4.enabled = active;
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

