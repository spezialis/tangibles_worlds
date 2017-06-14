using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is specified for all the worlds
public class WorldManager : MonoBehaviour {

	public string whichPinWall1;
	public string whichPinWall2;
	public string whichPinWall3;
	public string whichPinWall4;

	public int threshold1;
	public int threshold2;
	public int threshold3;
	public int threshold4;

	public bool ArduinoUpdateForPin_isPinValueInferiorToThreshold( string whichPin, int threshold ) {
		return ArduinoUpdateForPin( whichPin, threshold, false);
	}

	public bool ArduinoUpdateForPin_isPinValueSuperiorToThreshold( string whichPin, int threshold ) {
		return ArduinoUpdateForPin( whichPin, threshold, true);
	}

	public bool ArduinoUpdateForPin( string whichPin, int threshold, bool superior ) {
		if (MessageListener.pins.ContainsKey (whichPin)) {
			int pinValue = MessageListener.pins [whichPin];
			if (superior) {
				return pinValue > threshold;
			} else {
				return pinValue < threshold;
			}
			//Debug.Log ( whichPin + " exists");
		} else {
			Debug.LogWarning ( whichPin + " does not exist");
			return false;
		}
		return false; // fucking compiler
	}

	void ArduinoUpdateWalls() {
		//Debug.Log ("ARDUINO UPDATE");
		SetWallState(1, ArduinoUpdateForPin (whichPinWall1, threshold1, true));
		SetWallState(2, ArduinoUpdateForPin (whichPinWall2, threshold2, true));
		SetWallState(3, ArduinoUpdateForPin (whichPinWall3, threshold3, true));
		SetWallState(4, ArduinoUpdateForPin (whichPinWall4, threshold4, true));
	}

	public virtual void SetWallState (int index, bool active) {
		// Please override me in a child class
	}

	void Start () {
		
	}
	
	void Update () {
		//Debug.Log ("UPDATE");
		ArduinoUpdateWalls ();
	}
}
