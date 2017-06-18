using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMessage1 : MonoBehaviour {

	// reference to another scrpit
	public SerialPortCom03 serialPortCom;

	public string msgIn;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		// Get arduino messages from another script
		msgIn = serialPortCom.messageIn;
//		Debug.Log (msgIn);

		if (msgIn != null){
			// Check if the message isn't empty
			if (msgIn != "") {
				// verify it's a string
				string message = msgIn;

				// Separate the string
				string[] messages = message.Split('\t');

				//Debug.Log("0: " + messages[0]);
//				for (int i = 0; i < messages.Length; i++) {
//					values = int.Parse(messages[i]);
//				}

				int a = int.Parse(messages[0]);
				int b = int.Parse(messages[1]);
				int c = int.Parse(messages[2]);
				int d = int.Parse(messages[3]);

				if (a > 8000) {

				}

				// parse the string into float
				//value = float.Parse (message);
				//			Debug.Log (value);

				// Map the value
//				float newValue = map (value, 20, 255, 0, 5);

				//............
//				if (value > 8000) {
//					stopBlinking = true;
//				}
//
//				if (value < 8000) {
//					stopBlinking = false;
//				}
			}
		}
	}

	public static float map(float value, float istart, float istop, float ostart, float ostop){
		return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
	}
}
