using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TireChange : MonoBehaviour {

	public int boltCount; //this is used to determind if the tire can be clicked
	public int newBoltCount; 
	public GameObject[] bolts, newBolt;
	public GameObject flatTire, newTire; //all the gameobj to be used in minigame
	public bool flatRemoved, flatReplaced, flatChanged, removeBolt = false; //will be used to make items "clickable"
	public Vector3 tireTransform = new Vector3(0, 0, 0); //this tells the newTire gameObj where to go
	public Vector3 boltTransform = new Vector3(0, 0, 0); 
	public Button boltBtn, tireBtn, newTireBtn, newBoltBtn;
	
	void Start() {

		//constructs first bolt button at beginning of game
		//adds a listener for click
		Button boltButton = boltBtn.GetComponent<Button>();
		boltButton.onClick.AddListener(BoltOnClick);

		//construct tire button obj and disable it on start
		Button tireButton = tireBtn.GetComponent<Button>();
		tireButton.gameObject.SetActive(false); //code to make buttons visable and disappear

		//disable other buttons on start
		//new tire settings
		Button newTireButton = newTireBtn.GetComponent<Button>();
		newTireButton.gameObject.SetActive(false);
		//newTire.SetActive(false);

		//new bolt settings
		Button newBoltButton = newBoltBtn.GetComponent<Button>();
		newBoltButton.gameObject.SetActive(false);
		
		for(int x = 0; x <= 4; x++) {

			newBolt[x].SetActive(false);

		}


	}

	void Update() {

		if (boltCount == 5) { //this will be 5 in later version

		 		boltCount++;
		 		Button tireButton = tireBtn.GetComponent<Button>();
		 		tireButton.gameObject.SetActive(removeBolt);
		 		tireButton.onClick.AddListener(TireOnClick);

		 }

		if(flatRemoved) {

			flatRemoved = false; //ends if loop

			Button newTireButton = newTireBtn.GetComponent<Button>();
			newTireBtn.gameObject.SetActive(true); //activates new tire button

			newTireButton.onClick.AddListener(NewTireOnClick);

		}

		if(flatReplaced) {

			flatReplaced = false;

			Button newBoltButton = newBoltBtn.GetComponent<Button>();
			newBoltBtn.gameObject.SetActive(true);

			newBoltButton.onClick.AddListener(NewBoltOnClick);

		}

		if(flatChanged) {

			Debug.Log("Great job! You're ready to go."); //user has completed minigame
			Debug.Log("Game Over");
			flatChanged = false;

		}

	}

	void OnGUI() {


	}

	// void ReplaceBolts() {

	// 	bool boltsReplaced = false;
	// 	int boltCount = 0;

	// 	while(!boltsReplaced) {

	// 		if(GUI.Button(new Rect(), "new bolt button") && boltCount < 1) { //will change to 5 in later version

	// 			//newBolt.transform.position = boltTransform;
	// 			boltCount = boltCount + 1;

	// 		} else {

	// 			boltsReplaced = true;

	// 		}

	// 	}

	// }

	//listener function
	void BoltOnClick() {

		Debug.Log("bolt button clicked");
		//GameObject bolt = bolts.GetComponent<GameObject>();
		//no need to construct a gameobj object in prior line
		//instead of destorying asset I simply disable it
		//unity warns that .active is "obsolete" but works fine
		bolts[boltCount].active = false;
		newBolt[boltCount].SetActive(true); //makes bolts pop up in inventory

		//Destroy(bolts[boltCount]);
		boltCount = boltCount + 1;

		if(boltCount >= 5) {
			//Destroy(oldBolt);
			Button boltButton = boltBtn.GetComponent<Button>(); //construct button again to disable
			//Destroy(GUI.Button("bolt")); instead of destroying the button I disable it in the next line
			//can also use Destroy(boltButton) for same effect as next line
			//need to figure out a way to make the button disappear from player view
			boltButton.enabled = false; //disables button from before

			//boltBtnBool = false; no need
			//to make bolt button disappear
			boltButton.gameObject.SetActive(false);

			//boltButton.active = false; .active does not apply to button components
			Destroy(boltButton.gameObject);

			//makes tire button active
			removeBolt = true;
		}

	}

	void TireOnClick() {

		Debug.Log("old tire removed");

		//Destroy(flatTire);
		flatTire.active = false; //makes tire disappear

		Button tBtn = tireBtn.GetComponent<Button>();
		tBtn.enabled = false;
		tBtn.gameObject.SetActive(false);

		flatRemoved = true; //marks that flat has been removed


	}

	void NewTireOnClick() {

		Debug.Log("replaced tire");

		flatRemoved = false;

		newTire.SetActive(false);
		flatTire.SetActive(true);



		Button newTBtn = newTireBtn.GetComponent<Button>();
		newTBtn.enabled = false;
		newTBtn.gameObject.SetActive(false);

		flatReplaced = true;

	}

	void NewBoltOnClick() {

		Debug.Log("bolt fastedned");

		bolts[newBoltCount].SetActive(true);
		newBolt[newBoltCount].SetActive(false); //takes bolts from inventory and fastens tire

		newBoltCount = newBoltCount + 1;

		if(newBoltCount >= 5) {

			Debug.Log("all bolts fastened");

			//Destroy(oldBolt);
			Button newBoltButton = newBoltBtn.GetComponent<Button>(); //construct button again to disable
			//Destroy(GUI.Button("bolt")); instead of destroying the button I disable it in the next line
			//can also use Destroy(boltButton) for same effect as next line
			//need to figure out a way to make the button disappear from player view
			newBoltButton.enabled = false; //disables button from before

			//boltBtnBool = false; no need
			//to make bolt button disappear
			newBoltButton.gameObject.SetActive(false);

			//boltButton.active = false; .active does not apply to button components
			//Destroy(newBoltButton.gameObject);

			flatChanged = true;

		}

	}
}