using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: If a world is active and his local scale is >= 35, hide the boxes.
public class BoxesManager : MonoBehaviour {

	private static BoxesManager instance;

	public List<WorldActivator> worldActivators;

	public static bool aWorldIsActive() {
		foreach (WorldActivator world in instance.worldActivators) {
			if (world.world.activeSelf) {
				return true;
			}
		}
		return false;
	}

	public static bool canActivateAWorldNow() {
		return !aWorldIsActive ();
	}

	void Start () {
		instance = this;
	}
	
	void Update () {
		
	}
}
