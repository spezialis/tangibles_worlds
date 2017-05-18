using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	void Start () {
		
	}

	void Update () {

		//Raycast 
		//crée un vecteur de 1 devant la camera
		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		//dessine un rayon devant de 20 unité
		Debug.DrawRay(transform.position, fwd*100, Color.green);

		//résultat du raycast
		RaycastHit hit;

		if (Physics.Raycast (transform.position, fwd, out hit)) {
			// The game object need to have a collider
			//print ("There is something in front of the object! " + hit.collider.gameObject);

		}
	}
}
