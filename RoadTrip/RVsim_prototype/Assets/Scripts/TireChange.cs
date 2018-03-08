using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TireChange : MonoBehaviour {

	public int boltCount; //this is used to determind if the tire can be clicked
	public GameObject oldBolt, flatTire, newTire, newBolt; //all the gameobj to be used in minigame
	public bool removeFlat, replaceFlat, flatChanged, removeBolt = false; //will be used to make items "clickable"
	public Vector3 tireTransform = new Vector3(0, 0, 0); //this tells the newTire gameObj where to go
	public Vector3 boltTransform = new Vector3(0, 0, 0); 
	public Button boltBtn, tireBtn, newTireBtn, newBoltBtn;
	
	void Start() {

	}

	void Update() {

		while (!flatChanged) {

			//will loop while flatChanged remains false
			if(Input.GetButtonDown("bolt")) { //may just put in a long && sequence || a if/else sequence

				boltCount = boltCount + 1;
				Destroy(oldBolt);
				//Destroy(GUI.Button("bolt"));

				} else if (boltCount == 1) { //this will be 5 in later version

					removeBolt = true;

					} else if(Input.GetButtonDown("tire")) {

						removeFlat = true;
						Destroy(flatTire);
						//Destroy(GUI.Button("tire"));

						} else if(Input.GetButtonDown("new tire")) {

							//will already have gameobj for "new tire" positioned to the side
							newTire.transform.position = tireTransform;
							//Destroy(Button("new tire"));
							replaceFlat = true;

							} else if(replaceFlat) {

								ReplaceBolts();
								flatChanged = true;

								} else {

									Debug.Log("Still not complete.");

									}

		} 

		Debug.Log("Great job! You're ready to go."); //user has completed minigame

	}

	void OnGUI() {

		//creates bolt button
		GUI.Button(new Rect(10, 10, 10, 10), "bolt");
		Button boltButton = boltBtn.GetComponent<Button>();

		if(removeBolt) { //once all bolts are "removed" removeBolt is set to true

			boltButton.enabled = false; //disables button from before
			GUI.Button(new Rect(20, 10, 10, 20), "tire");
			Button tireButton = tireBtn.GetComponent<Button>();

		}

		if(removeFlat)
			GUI.Button(new Rect(30, 10, 10, 10), "new tire");

		if(replaceFlat)
			GUI.Button(new Rect(40, 10, 10, 10), "new bolt");

	}

	void ReplaceBolts() {

		bool boltsReplaced = false;
		int boltCount = 0;

		while(!boltsReplaced) {

			if(Input.GetButtonDown("new bolt") && boltCount < 1) { //will change to 5 in later version

				newBolt.transform.position = boltTransform;
				boltCount = boltCount + 1;

			} else {

				boltsReplaced = true;

			}

		}

	}
}