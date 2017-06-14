using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWorld : MonoBehaviour {
	
	public GameObject world;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		world.SetActive (false);
	}
}
