using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireWorldManager : WorldManager {

	private static WireWorldManager instance;

//	public Animation wallWire1;
//	public Animation wallWire2;
//	public Animation wallWire3;
//	public Animation wallWire4;

	// TODO at the end of the project remove the debugAnimateDisplacement id:9
//	public bool debugAnimateDisplacement;
	public MegaDisplace cut;
	public MegaDisplace cut1;
	public MegaDisplace cut2;
	public MegaDisplace cut3;

	public override void SetWallState( int index, bool active ) {
		switch (index) {
		case 1:
//			if (debugAnimateDisplacement) {
				// Animate displacement
				cut.amount += 0.001f;

				if (cut.amount >= 0.01f) {
					cut.amount = 0.01f;

					// PingPong lerp
					cut.offset = new Vector2(Mathf.PingPong(Time.time, 3), Mathf.PingPong(Time.time, 3));
				}
//			}

			break;

		case 2:
//			if (debugAnimateDisplacement) {
				// Animate displacement
				cut1.amount += 0.001f;

				if (cut1.amount >= 0.01f) {
					cut1.amount = 0.01f;

					// PingPong lerp
					cut1.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
				}
//			}
			break;

		case 3:
//			if (debugAnimateDisplacement) {
				// Animate displacement
				cut2.amount += 0.001f;

				if (cut2.amount >= 0.01f) {
					cut2.amount = 0.01f;

					// PingPong lerp
					cut2.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
				}
//			}
			break;

		case 4:
//			if (debugAnimateDisplacement) {
				// Animate displacement
				cut3.amount += 0.001f;

				if (cut3.amount >= 0.01f) {
					cut3.amount = 0.01f;

					// PingPong lerp
					cut3.offset = new Vector2 (Mathf.PingPong (Time.time, 3), Mathf.PingPong (Time.time, 3));
				}
//			}
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

