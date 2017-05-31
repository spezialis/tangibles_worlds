using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour {

	public Material[] randomMaterials;
	MeshRenderer[] elements;

	// Use this for initialization
	void Start () {

		elements = GetComponentsInChildren<MeshRenderer>();

		foreach(MeshRenderer child in elements) { //see all objects
//			//Assign random material to object
			child.material = randomMaterials[Random.Range(0, randomMaterials.Length)];

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
