using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is specified for all the worlds
public class WorldManager : MonoBehaviour {

	public WorldActivator myWorldActivator;

	public bool valueIsSuperior;

	public bool wallSensorsOnArduinoUno;

	public string whichPinWall1;
	public string whichPinWall2;
	public string whichPinWall3;
	public string whichPinWall4;

	public int threshold1;
	public int threshold2;
	public int threshold3;
	public int threshold4;

	public bool wall1ActivatedOnce;
	public bool wall2ActivatedOnce;
	public bool wall3ActivatedOnce;
	public bool wall4ActivatedOnce;

	public bool ArduinoUpdateForPin_isPinValueInferiorToThreshold( string whichPin, int threshold, bool arduinoUno ) {
		return ArduinoUpdateForPin( whichPin, threshold, false, arduinoUno);
	}

	public bool ArduinoUpdateForPin_isPinValueSuperiorToThreshold( string whichPin, int threshold, bool arduinoUno ) {
		return ArduinoUpdateForPin( whichPin, threshold, true, arduinoUno);
	}

	public bool MessageListenerHasPin(string whichPin, bool arduinoUno) {
		if (arduinoUno) {
			return MessageListener1.pins.ContainsKey (whichPin);
		} else {
			return MessageListener.pins.ContainsKey (whichPin);
		}
	}

	public int MessageListenerGetPin(string whichPin, bool arduinoUno) {
		if (arduinoUno) {
			return MessageListener1.pins [whichPin];
		} else {
			return MessageListener.pins [whichPin];
		}
	}

	public bool ArduinoUpdateForPin( string whichPin, int threshold, bool superior, bool arduinoUno ) {
		if (MessageListenerHasPin(whichPin, arduinoUno)) {
			int pinValue = MessageListenerGetPin (whichPin, arduinoUno);
//			Debug.Log (pinValue);
			if (superior) {
				return pinValue > threshold;
			} else {
				return pinValue < threshold;
			}
			//Debug.Log ( whichPin + " exists");
		} else {
//			Debug.LogWarning ( whichPin + " does not exist");
			return false;
		}
		return false; // fucking compiler
	}

	void ArduinoUpdateWalls() {
		//Debug.Log ("ARDUINO UPDATE");
		SetWallState(1, ArduinoUpdateForPin (whichPinWall1, threshold1, valueIsSuperior, wallSensorsOnArduinoUno));
		SetWallState(2, ArduinoUpdateForPin (whichPinWall2, threshold2, valueIsSuperior, wallSensorsOnArduinoUno));
		SetWallState(3, ArduinoUpdateForPin (whichPinWall3, threshold3, valueIsSuperior, wallSensorsOnArduinoUno));
		SetWallState(4, ArduinoUpdateForPin (whichPinWall4, threshold4, valueIsSuperior, wallSensorsOnArduinoUno));
	}

	public virtual void SetWallState (int index, bool active) {
		// Please override me in a child class
	}

	void Start () {
		
	}
	
	void Update () {
		//Debug.Log ("UPDATE");
		if (myWorldActivator.worldSupposedToBeActive) {
			ArduinoUpdateWalls ();
		}
	}
}
