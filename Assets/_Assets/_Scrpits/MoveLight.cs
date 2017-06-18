using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening; 

public class MoveLight : MonoBehaviour {

	// TODO proposition: maybe the light could follow the camera rotation, and stay at a specific distance id:4
	Light light;

	public float duration;
	float startTime;

	// Position
	float xStart;
	float yStart;
	float zStart;

	float xTarget;
	float yTarget;
	float zTarget;

	float rangePosition = 0.5f;

	// Color
	public Color[] randomColor;
	int startColor;
	int targetColor;

	// TODO change intensity or range or both id:6

	void Start () {
		light = GetComponent<Light> ();

		xTarget = 0;
		yTarget = 0;
		zTarget = 0;
		AssignNewTargets ();

		startColor = getRandomColor();
		light.color = randomColor[startColor];
	}

	void AssignNewTargets() {
		startTime = Time.time;

		// Position
		xStart = xTarget;
		yStart = yTarget;
		zStart = zTarget;

		xTarget = Random.Range (-rangePosition, rangePosition);
		yTarget = Random.Range (-rangePosition, rangePosition);
		zTarget = Random.Range (-rangePosition, rangePosition);

		// Color
		startColor = targetColor;
		targetColor = getRandomColor();
	}
		
	public int getRandomColor(){
		return Random.Range(0, (randomColor.Length - 1));
	}
		
	void Update () {
		// Random range with duration
		float completion = (Time.time - startTime) / duration;

		// Position
		float xLerped = Mathf.Lerp(xStart, xTarget, completion);
		float yLerped = Mathf.Lerp(yStart, yTarget, completion);
		float zLerped = Mathf.Lerp(zStart, zTarget, completion);

		light.transform.localPosition = new Vector3(xLerped, yLerped, zLerped);

		// Color
		Color lerpedColor = Color.Lerp (randomColor [startColor], randomColor [targetColor], completion);
		light.color = lerpedColor;

		if (completion >= 1) {
			AssignNewTargets ();
		} 
	}
}
