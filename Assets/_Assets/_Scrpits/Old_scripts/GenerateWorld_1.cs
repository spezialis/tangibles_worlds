using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// initialisation DoTween
using DG.Tweening;

public class GenerateWorld_1 : MonoBehaviour {

	public static UnityEvent mustExplode;
	public static UnityEvent mustUnexplode;

	public GameObject root;

	//public string resource;
	public float nbr = 100;

	public GameObject clone;
//	
	//public GameObject[] clones;

	public List<GameObject> clones;

	public float radius = 5;

	// Reference to scripts
//	DetectZone detectZone;
	UseMessage useMessage;

	// Reference to box collider component
//	public BoxCollider boxColZone;
	private bool exploding = false;
	private bool unexploding = false;

	//Vector3 endPosition;
	//Vector3 startPosition = new Vector3(-0.4f, 1.31f, 0.516f);
	//Vector3 startPosition = new Vector3(root.transform);

	// DONE: make this script work for each zone
	void Awake(){
		
		// Reference to antother script
//		detectZone = boxColZone.GetComponent<DetectZone> ();
		useMessage = GetComponent<UseMessage>();
	}

	// Use this for initialization
	void Start () {

		mustExplode = new UnityEvent ();
		mustUnexplode = new UnityEvent ();
		mustExplode.AddListener (DoExplode);
		mustUnexplode.AddListener (DoUnexplode);

		// DONE: load resources using their name on the inspector
		// OLD clone = Resources.Load(resource) as GameObject;
		// List of clones
		clones = new List<GameObject> ();
		for (int i = 0; i < nbr; i++){
			GameObject clonedObject = Spawn ();
			clones.Add(clonedObject);
			clonedObject.SetActive (false);
		}
	}

	void DoExplode() {
		if (exploding) {
			return;
		}

		exploding = true;

		foreach (GameObject clone in clones) {
			//randomPos ();
			clone.SetActive(true);
			// TODO animation sequence Dotween & take care of exploding only in the sequence onmComplete, not in each tween onComplete
			clone.transform.DOMove (randomPos(), 1).SetEase (Ease.OutBack).OnComplete(
				() => {
					exploding = false;
				}
			);
		}
	}

	void DoUnexplode() {
		if (unexploding) {
			return;
		}

		unexploding = true;

		foreach (GameObject clone in clones) {
			
			clone.transform.DOMove (Vector3.zero, 1).SetEase (Ease.InExpo).OnComplete(
				() => {
					clone.SetActive(false);
					unexploding = false;
				}
			);
		}
	}

	// Update is called once per frame
	void Update () {

		// QUESTION: How to place the explosion better?

		//------------- CHECK SENSOR MESSAGE ----------------//
		//Debug.Log (useMessage.startWorld);

		//------------- CHECK IF PLAYER IS INSIDE A SPECIFIC ZONE ----------------//
//		Debug.Log (detectZone.playerInZone + " " + detectZone.gameObject.name);
/*		
 		if (detectZone.playerInZone == true && explode) {
			// Active the root
//			root.SetActive (true);

			foreach (GameObject clone in clones) {
				randomPos();

				clone.transform.DOMove (endPosition, 3).SetEase (Ease.OutBack);
			}

			explode = false;

		} else if (detectZone.playerInZone == false && !explode){
			// Desactive the root
//			root.SetActive (false);

			foreach (GameObject clone in clones) {
				clone.transform.DOMove (startPosition, 2).SetEase (Ease.InExpo);
			}

			explode = true;
		}
*/

		//----------------- KEYBOARD -----------------//
		// Keyboard input
/*		if (Input.GetKeyUp (KeyCode.Space)) {
			foreach (GameObject clone in clones) {

				// QUESTION: why I need always to ad this line of code to place the element randomly?
//				endPosition = Random.insideUnitSphere * radius;
				randomPos();

				Tweener end = clone.transform.DOMove (endPosition, 3).SetEase (Ease.InOutBack);

//				Tweener start = clone.transform.DOMove (startPosition, 3).SetEase (Ease.InOutBack);

			}
		}
*/

	}

	GameObject Spawn() {
		//"Random.onUnitSphere" Returns a random point on the surface of a sphere with radius 1
		//		Vector3 position = Random.onUnitSphere * radius + transform.position; 

		// Instantiate elements
		GameObject newClone = Instantiate(clone, Vector3.zero, Quaternion.identity) as GameObject;

		// asign random scale to each newClone
		newClone.transform.localScale = Vector3.one * Random.Range(0.1f, 0.2f);

		// DONE: set the clones as a child of the game object "world"
		newClone.transform.SetParent(root.transform);
//		newClone.transform.SetParent(gameObject.transform);

		// "Random.insideUnitSphere" Returns a random point inside a sphere with a radius
//		endPosition = Random.insideUnitSphere * radius;
//		randomPos();

		newClone.transform.localPosition = Vector3.zero;

		return newClone;

	}

	Vector3 randomPos(){
		return Random.insideUnitSphere * radius;
	}
}
