using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkEmission: MonoBehaviour {

	Renderer rend;

	public Color colorStart = Color.white;
	public Color colorEnd = Color.red;

	public float duration;

	public float delay = 10.0f;

	public bool blink = true;
	public bool blinkFast = false;
	public int pinValue;

	//public MessageListener messageListener;

	public Light light;
	public string whichPin = "";

	void Start(){
		rend = GetComponent<Renderer> ();
		//rend.material.EnableKeyword("_Emission");

		//messageListener = messageListener.GetComponent<MessageListener> ();
	}




	void Update(){
		if(MessageListener.pins.ContainsKey(whichPin)) {
			pinValue = MessageListener.pins[whichPin];
			if (pinValue > 6000) {
				blinkFast = true;
			} else if (pinValue < 6000) {
				blinkFast = false;
			}
		}
		if (blink) {
			float lerp = Mathf.PingPong (Time.time, duration) / duration;
			//float lerp = Mathf.PingPong (Time.time, duration);

			// Change the color of the material
			rend.material.color = Color.Lerp (colorStart, colorEnd, lerp);

			// Change the color of the emission
			//rend.material.SetColor("_EmissionColor", Color.Lerp (colorStart, colorEnd, lerp));

		} else if (!blink) {
			rend.material.color = colorEnd;
			//rend.material.SetColor("_EmissionColor", colorEnd);
		}

		if (blink && blinkFast) {
			duration = 0.1f;

			float lerp = Mathf.PingPong (Time.time, duration) / duration;
			rend.material.color = Color.Lerp (colorStart, colorEnd, lerp);

			delay -= Time.deltaTime;

			if (delay < 0) {
				blinkFast = false;
				blink = false;
			}
		} 
	}
}
