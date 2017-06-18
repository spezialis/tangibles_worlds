using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// initialisation DoTween
using DG.Tweening;

public class GenerateWorld : MonoBehaviour {

	public GameObject root;

	public string resource;
	public float nbr = 100;
	GameObject clone;
	public List<GameObject> clones;

	private float radius = 5;

	bool explode = true;

	Vector3 endPosition;
	Vector3 startPosition = new Vector3 (0, 1.5f, 0);

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {

		clone = Resources.Load(resource) as GameObject;

		// List of clones
		clones = new List<GameObject> ();

		for (int i = 0; i < nbr; i++){
			clones.Add( Spawn() );
		}
	}
	
	// Update is called once per frame
	void Update () {

		//----------------- KEYBOARD -----------------//
		// Keyboard input
		if (Input.GetKeyUp (KeyCode.Space)) {
			foreach (GameObject clone in clones) {

				// QUESTION: why I need always to ad this line of code to place the element randomly?
//				endPosition = Random.insideUnitSphere * radius;
				randomPos();

				Tweener end = clone.transform.DOMove (endPosition, 3).SetEase (Ease.InOutBack);

//				Tweener start = clone.transform.DOMove (startPosition, 3).SetEase (Ease.InOutBack);

			}
		}
	}

	GameObject Spawn() {
		//"Random.onUnitSphere" Returns a random point on the surface of a sphere with radius 1
		//		Vector3 position = Random.onUnitSphere * radius + transform.position; 

		// Instantiate elements
		GameObject newClone = Instantiate(clone, Vector3.zero, Quaternion.identity) as GameObject;

		// asign random scale to each newClone
		newClone.transform.localScale = Vector3.one * Random.Range(1f, 3f);
		newClone.transform.localRotation = Random.rotation;

		// DONE: set the clones as a child of the game object "world" id:8
		newClone.transform.SetParent(root.transform);
//		newClone.transform.SetParent(gameObject.transform);

		// "Random.insideUnitSphere" Returns a random point inside a sphere with a radius
		endPosition = Random.insideUnitSphere * radius;
//		randomPos();

		newClone.transform.localPosition = endPosition;

		return newClone;

	}

	void randomPos(){
		endPosition = Random.insideUnitSphere * radius;
	}
}
