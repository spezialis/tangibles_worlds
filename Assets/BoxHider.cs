using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHider : MonoBehaviour {

	static BoxHider instance;

	public List<GameObject> boxes;

	public static void SetBoxesVisibility(bool active) {
		foreach (GameObject box in instance.boxes) {
			box.SetActive (active);
		}
	}

	void Start () {
		instance = this;
		// SetBoxesVisibility (false);
	}
	
	void Update () {
		
	}

}
