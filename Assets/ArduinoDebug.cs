using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoDebug : MonoBehaviour {

	public static ArduinoDebug instance;

	public List<Vector2> pinDebug_A;
	public List<Vector2> pinDebug_D;

	public void UpdateDebugValue(List<Vector2> list, int index, int value) {
		Vector2 newValue = new Vector2 (
			list[index].x,
			value
		);
		list[index] = newValue;
	}

	int pinNameToInt(string pinName) {
		int result;
		int.TryParse (pinName.Substring (4), out result);
		return result;
	}

	public void Declare(List<Vector2> list, string pinName) {
		list.Add (new Vector2 (pinNameToInt(pinName), 0));
	}

	void Start() {
		pinDebug_A = new List<Vector2> ();
		pinDebug_D = new List<Vector2> ();
		instance = this;
	}
	
	void Update () {
		
	}
}
