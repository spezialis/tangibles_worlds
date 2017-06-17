using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDisplaceRandomRange : MonoBehaviour {

	public MegaDisplace cut;

	public float duration;

	float xStart;
	float yStart;

	float xTarget;
	float yTarget;

	float startTime;

	void Start () {
		xTarget = 0;
		yTarget = 0;
		AssignNewTargets ();
	}
		
	void AssignNewTargets() {
		xStart = xTarget;
		yStart = yTarget;
	
		xTarget = Random.Range (-1.0f, 1.0f);
		yTarget = Random.Range (-1.0f, 1.0f);
		startTime = Time.time;
	}
		
	void Update () {
		cut.amount += 0.0001f;

		if (cut.amount >= 0.01f) {
			cut.amount = 0.01f;

			// Random range with duration
			float completion = (Time.time - startTime) / duration;
			float xLerped = Mathf.Lerp(xStart, xTarget, completion);
			float yLerped = Mathf.Lerp(yStart, yTarget, completion);
	
			cut.offset = new Vector2(xLerped, yLerped);

			if (completion >= 1) {
				AssignNewTargets ();
			}
		}
	}
}
