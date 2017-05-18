using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System;

public class SerialPortCom03 : MonoBehaviour {
	
	//Setup parameters to connect to Arduino
	/* The serial port where the Arduino is connected. */
	[Tooltip("The serial port where the Arduino is connected")]
	public string port = "/dev/cu.usbmodem1411";
	/* The baudrate of the serial port. */
	[Tooltip("The baudrate of the serial port")]
	public int baudrate = 9600;

	public static SerialPort stream;
	public string portStatus;

	public string messageIn;

	// Use this for initialization
	void Start () {

		stream = new SerialPort (port, baudrate);

		try {
			stream = new SerialPort (port, baudrate);

			OpenConnection();
		}

		catch (Exception e) {
			Debug.Log(e);
		}
	}

	void Update(){
		try {
			if (stream != null) {
				if (stream.IsOpen) {
					//Read incoming data
					messageIn = stream.ReadLine ();
	//				print (messageIn);

					///////////////////////////
					//Parse the messageIn
					if(messageIn != ""){
	//					string text = messageIn;
	//					print (text);

	//					range = int.Parse (messageIn);
	//
	//					float newRange = map (range, 20, 255, 0, 3);
					}
				}
			}
		} catch (Exception e) {
			Debug.Log (e);
		}
	}

	//Function connecting to Arduino
	public void OpenConnection() {
		if (stream != null) {
			if (stream.IsOpen) {
				stream.Close();
				portStatus = "Closing port, because it was already open!";
			}
			else {
				stream.Open();  // opens the connection
//				stream.ReadTimeout = 50;  // sets the timeout value before reporting error
				portStatus = "Port Opened!";
			}
		}
		else {
			if (stream.IsOpen){
				print("Port is already open");
			}
			else {
				print("Port == null");
			}
		}
	}

	void OnApplicationQuit(){
		stream.Close();
	}
}