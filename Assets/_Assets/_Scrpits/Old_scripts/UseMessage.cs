using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMessage : MonoBehaviour {

	// reference to another scrpit
	// QUESTION: how to create a reference to this script without the public?
	public SerialPortCom03 serialPortCom;
//	SerialPortCom03 serialPortCom;

	public string msgIn;
	float value;

	public bool startWorld = false;

//	void Awake (){
//		serialPortCom = GetComponent<SerialPortCom03> ();
//	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// DEBUG
		if (startWorld) {
			GenerateWorld_1.mustExplode.Invoke();	
		}

		// Get arduino messages from another script
		msgIn = serialPortCom.messageIn;
//		Debug.Log (msgIn);
		
		if (msgIn != null){
			// Check if the message isn't empty
			if (msgIn != "") {
				// verify it's a string
				string message = msgIn;

				// parse the string into float
				value = float.Parse (message);
				//			Debug.Log (value);

				// Map the value
//				float newValue = map (value, 20, 255, 0, 5);

				//............
				if (value >= 254) {
					// startWorld = false;
					GenerateWorld_1.mustUnexplode.Invoke();
				} 

				if (value >= 20 && value <= 254) {
					// startWorld = true;
					GenerateWorld_1.mustExplode.Invoke();
				}

				//			prefab.transform.scale = new Vector3(newValue, newValue, newValue);
			}
		}
	}
		
	public static float map(float value, float istart, float istop, float ostart, float ostop){
		return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
	}
}
