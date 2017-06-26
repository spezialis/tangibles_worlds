using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// TODO: Check which world is active and if a second world is then activated, disable it. Never show 2 world at the same time! id:17 gh:7
public class WorldActivator : MonoBehaviour {

	public bool KeepActive;

	public bool worldIsShrinked; // additional state var we must maintain that is used to have a single variable where .active state is not enough (because KeepActive) and worldSupposedToBeActive is too early.

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

	public bool worldSupposedToBeActive;

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

			worldIsShrinked = false;

			worldSupposedToBeActive = true;
			world.SetActive (true);
			scalingTween = world.transform.DOScale (endScale, duration)
				.OnKill (
					() => scalingTween = null
				)
				//.SetEase(Ease.InSine)
				;

			BoxHider.SetBoxesVisibility (false);

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
					() => {
						world.SetActive (false || KeepActive); // non optimal syntax for readability
						worldIsShrinked = true;
					}
				).OnKill (
					() => scalingTween = null
				)
				//.SetEase(Ease.OutSine)
				;

			BoxHider.SetBoxesVisibility (true);
		}
	}

	void ArduinoUpdateWorldActivation() {

		bool activationStateIsOnArduinoUno = false; // always.

		bool currentSensorState = manager.ArduinoUpdateForPin_isPinValueSuperiorToThreshold(whichPinWorldActivation, thresholdWorldActivation, activationStateIsOnArduinoUno);

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
				if (!worldSupposedToBeActive && BoxesManager.canActivateAWorldNow()) {
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
		worldIsShrinked = true;
		sensorWasPreviouslyOn = false;
		durationSensorBeingOff = 0;
		durationSensorBeingOn = 0;
		world.transform.localScale = startScale;
	}
	
	void Update () {
		ArduinoUpdateWorldActivation ();
	}
}
