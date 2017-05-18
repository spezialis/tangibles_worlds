/**
 * SerialCommUnity (Serial Communication for Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * When creating your message listeners you need to implement these two methods:
 *  - OnMessageArrived
 *  - OnConnectionEvent
 */
public class MessageListener : MonoBehaviour {
	public static Dictionary<string, int> pins = new Dictionary<string, int>();
	string[] pinNames = {"pin8", "pin9", "pin10", "pin11"};
	//public int pin8;
	//int pin9;
	//int pin10;
	//int pin11;
	//public static int test = 5;
	
	// Invoked when a line of data is received from the serial device.
	void OnMessageArrived(string msg) {
		//Debug.Log("Message arrived: " + msg);

		string[] msgs = msg.Split('\t');
		//Debug.Log (msgs[0]);

		// QUESTION: how to use a boucle for in this case?
//		for (int i = 0; i < msgs.Length; i++) {
//			int [] values = int.Parse[i];
//		}
		// 
		for(int i=0; (i<msgs.Length && i<pinNames.Length); i++) {
			if (pins.ContainsKey (pinNames [i])) {
				pins [pinNames [i]] = int.Parse (msgs [i]);
			} else {
				pins.Add(pinNames [i],  int.Parse (msgs [i]));
			}

			//pins.Add(pinNames[i], int.Parse(msgs[i]));
		}

		/*pin8 = int.Parse(msgs[0]);
		pin9 = int.Parse(msgs[1]);
		pin10 = int.Parse(msgs[2]);
		pin11 = int.Parse(msgs[3]);

		if (pin8 > 7500) {
			// -> blinkFast = true;
		} else if (pin8 < 7500) {
			//blink = false;
			// -> blinkFast = false;
		}*/

		/*GameObject[] controllers = GameObject.FindGameObjectsWithTag ("controller");
		foreach(GameObject c in controllers) {
			c.SendMessage ();
		}*/
	}

	//		 Invoked when a connect/disconnect event occurs. The parameter 'success'
	// will be 'true' upon connection, and 'false' upon disconnection or
	// failure to connect.
	void OnConnectionEvent(bool success) {
		if (success)
			Debug.Log("Connection established");
		else
			Debug.Log("Connection attempt failed or disconnection detected");
	}
}
