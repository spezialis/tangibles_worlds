using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// can only work if there is also a DisplayWorld component in the same object
public class WorldActivator : MonoBehaviour {

	public WorldManager manager;

	DisplayWorld displayer;

	public string whichPinWorldActivation;

	public int thresholdWorldActivation;

	void ArduinoUpdateWorldActivation() {
		// TODO maybe consolidate this as we don't want the entire world to disappear on a single glitchy value under the threshold
		// (count small values and turn off only if there are enough of them in a row - like 10 e.g.)
		displayer.enabled = manager.ArduinoUpdateForPin(whichPinWorldActivation, thresholdWorldActivation, false);
	}

	void Start () {
		displayer = GetComponent<DisplayWorld> ();
	}
	
	void Update () {
		ArduinoUpdateWorldActivation ();
	}
}
