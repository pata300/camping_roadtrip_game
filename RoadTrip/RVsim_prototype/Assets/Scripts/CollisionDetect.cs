using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		Debug.Log("Detection Script working.");
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	//function to check for wrench and bolt collision
	void OnTriggerEnter(Collider other) {
		
		Debug.Log("COLLISION");

	}

}
