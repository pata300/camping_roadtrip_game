using UnityEngine;
using System.Collections;

public class TripEvents : MonoBehaviour //this is the game loop
{

	public int playerMoney = 1000;
	public int timeOfDay = 6;
	public int dayCount = 1;
	public int playerFuel = 300;
	public int playerLocation = 0;
	public bool confirmTravel, gameComplete = false;
	public bool timeAM = true;

	public Button cityXBtn, cityYBtn, cityZBtn;
	public int cityChoice; //variable for string to use for swtich structure


	void Start()
	{

		Debug.Log("Constructing Base City");
		City baseCity = new City();

		Debug.Log("Constructing X City");
		XCity xCity = new XCity();

		//constructing buttons for cities
		//not a part of original draft/psuedo
		Button xCityButton = cityXBtn.GetComponent<Button>(); //btn is constructed and clickable
		xCityButton.onClick.AddListener(XCityOnClick); //this calls function/module wanted when button is clicked
		xCityButton.gameObject.SetActive(true); //makes button visable

		Debug.Log("Constructing Y City");
		YCity yCity = new YCity();

		Button yCityButton = cityYBtn.GetComponent<Button>();
		yCityButton.onClick.AddListener(YCityOnClick);//on click, call 'YCityOnClick' module
		yCityButton.gameObject.SetActive(true);

		Debug.Log("Constructing Z City");
		ZCity zCity = new ZCity();

		Button zCityButton = cityZBtn.GetComponent<Button>();
		zCityButton.onClick.AddListener(ZCityOnClick); 
		zCityButton.gameObject.SetActive(true);

		Debug.Log("Money: " + playerMoney);
		timeOfDay = checkTime(timeOfDay); //calls timeOfDay with makes sure time isn't military time format
		Debug.Log("Time: " + timeOfDay);
		Debug.Log("Fuel: " + playerFuel);

	}

	/*
		7/19
			ending session
				started draft for switch structure. 
				Game logic as of now: on click of city buttons
				code will call city obj setLocation function for int
				int is then placed in switch structure to further game loop
				***might need to construct obj in 'onClick' module
				***may be able to make global objs???

	*/
	void Update()
	{

		//game loop begins
		while(!gameComplete) //while the game isn't complete, program listens for mouse clicks
		{

			switch(cityChoice)
			{

				case 1:
					//change cityChoice to null
					//city x
					break;

				case 2:
					//change cityChoice to null
					//city y
					break;

				case 3:
					//change cityChoice to null
					//city z
					break;

				default:
					//change cityChoice to null
					//default
					break;

			}
		}
	}

	/*

		All 'OnClick' modules exist to change 
		cityChoice string for switch structure

	*/

	void XCityOnClick()
	{

		//calls setLocation function from corrosponding city objects
		//returns int from function for switch structure 
		cityChoice = xCity.setLocation();

	}

	void YCityOnClick()
	{

		cityChoice = yCity.setLocation();

	}

	void ZCityOnClick()
	{

		cityChoice = zCity.setLocation();

	}

}