//script used to move gameObject

using UnityEngine;
using System.Collections;

public class MousePos : MonoBehaviour {

	Rigidbody rB; 
	public GameObject rotateWrench;

	void Start() {

	}

	void Update() {

		//position of the Z coordinate
		//int posZ = -3;

		//get the position of the cursor
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10);

		//set fixed roation
		//Vector3 fixedRotation = new Vector3(0, 0, 135);

		//set Z coordinate to posZ
		//mousePos.z = posZ;

		//set the gameObject to mouse position
		transform.position = Camera.main.ScreenToWorldPoint(mousePos);
		//transform.rotation = fixedRotation;

	}

	void OnGUI() {

		//failed gui test
		//GUI.Label(new Rect(200, 200, 0, 0), "Test");

	}

	//function to check for wrench and bolt collision
	void OnTriggerStay(Collider other) {

		bool freeze = false;

		//get the position of the cursor
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10);

		//Debug.Log("COLLISION");

		if(Input.GetMouseButtonDown(0)){

			Debug.Log("Click");
			//make sure the script is responding, keeping track of clicks

			//no such thing as freezePosition in regidbody;
			//rigidbody.freezePosition = true;
			//rB.constraints = RigidbodyConstraints.FreezeAll;

			freeze = true;

			if(freeze) {

				transform.position = mousePos;
				Debug.Log("Moved");
				Destroy(gameObject);
				Instantiate(rotateWrench);


			}

		}

	}

}