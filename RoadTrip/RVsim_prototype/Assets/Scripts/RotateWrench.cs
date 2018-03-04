using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWrench : MonoBehaviour {

	// Use this for initialization
	void Start () {

		//get the position of the cursor
		Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10);

		transform.position = Camera.main.ScreenToWorldPoint(mousePos);

		Debug.Log("New wrench");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
