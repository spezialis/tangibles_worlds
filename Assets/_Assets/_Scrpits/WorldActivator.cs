using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// can only work if there is also a DisplayWorld component in the same object
public class WorldActivator : MonoBehaviour {

//	bool wasPreviouslyOff;
	float durationSensorBeingOff;
	bool sensorWasPreviouslyOn;
	float durationSensorBeingOn;

	public float delayMustWaitBeforeActivationWhenOff;
	public float delayMustWaitBeforeDisableWhenOn;

	public float delayMustWaitBeforeActivationDuringScalingDown;
	public float delayMustWaitBeforeDisableDuringScalingUp;


	public float activateDuration;
	public float disableDuration;

	Vector3 startScale = new Vector3(0, 0, 0);
	Vector3 endScale = new Vector3(35, 35, 35);

	public GameObject world;

	public WorldManager manager;

	public string whichPinWorldActivation;

	public int thresholdWorldActivation;

	bool worldSupposedToBeActive;

	Tween scalingTween;

	bool isThereAScalingPlaying() {
		return scalingTween != null && scalingTween.IsActive() && scalingTween.IsPlaying();
	}

	void ActivateWorld() {
		if (world) {
			
//			Debug.Log ("I'm going to activate");

			// first check if we have to cancel activation tween
			if (isThereAScalingPlaying()) {
				scalingTween.Kill ();
			}

			float scaleFactor = world.transform.localScale.x;
			float duration = activateDuration * ( 35 - scaleFactor ) / 35;

			worldSupposedToBeActive = true;
			world.SetActive (true);
			scalingTween = world.transform.DOScale (endScale, duration)
				.OnKill (
					() => scalingTween = null
				)
				//.SetEase(Ease.InSine)
				;
		}
	}

	void DisableWorld() {
		if (world) {

//			Debug.Log ("I'm going to deactivate");

			// first check if we have to cancel activation tween
			if (isThereAScalingPlaying()) {
				scalingTween.Kill ();
			}

			float scaleFactor = world.transform.localScale.x;
			float duration = disableDuration * scaleFactor / 35;

			worldSupposedToBeActive = false;
			scalingTween = world.transform.DOScale (startScale, duration)
				.OnComplete (
					() => world.SetActive (false)
				).OnKill (
					() => scalingTween = null
				)
				//.SetEase(Ease.OutSine)
				;
		}
	}

	void ArduinoUpdateWorldActivation() {

		bool currentSensorState = manager.ArduinoUpdateForPin_isPinValueSuperiorToThreshold(whichPinWorldActivation, thresholdWorldActivation);

		if (currentSensorState) {

//			Debug.Log ("Sensor ON - " + whichPinWorldActivation);

			if (sensorWasPreviouslyOn) {
				// currently sensor is ON, previously was ON
				durationSensorBeingOn += Time.deltaTime;
			} else {
				// currently sensor is ON, previously was OFF
				durationSensorBeingOn = 0;
			}

			sensorWasPreviouslyOn = true;

		} else {
			
//			Debug.Log ("Sensor OFF - " + whichPinWorldActivation);

			if (sensorWasPreviouslyOn) {
				// currently sensor is OFF, previously was ON
				durationSensorBeingOff = 0;
			} else {
				// currently sensor is OFF, previously was OFF
				durationSensorBeingOff += Time.deltaTime;
			}

			sensorWasPreviouslyOn = false;
			
		}

		// must activate ?
		if (currentSensorState) {

			float delayMustWait = isThereAScalingPlaying() ? delayMustWaitBeforeActivationDuringScalingDown : delayMustWaitBeforeActivationWhenOff;

			if (durationSensorBeingOn > delayMustWait) {
				if (!worldSupposedToBeActive) {
					ActivateWorld();
				}
			}

		} else if (!currentSensorState) {

			float delayMustWait = isThereAScalingPlaying() ? delayMustWaitBeforeDisableWhenOn : delayMustWaitBeforeDisableWhenOn;

			if (durationSensorBeingOff > delayMustWait) {
				if (worldSupposedToBeActive) {
					DisableWorld();
				}
			}

		}

	}

	void Start () {
		sensorWasPreviouslyOn = false;
		durationSensorBeingOff = 0;
		durationSensorBeingOn = 0;
		world.transform.localScale = startScale;
	}
	
	void Update () {
		ArduinoUpdateWorldActivation ();
	}
}
