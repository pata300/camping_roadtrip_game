/*
	7/19
		ending session
			started draft for switch structure. 
			Game logic as of now: on click of city buttons
			code will call city obj setLocation function for int
			int is then placed in switch structure to further game loop
			***might need to construct obj in 'onClick' module
			***may be able to make global objs???

	7/23
		ending session
			finished a pretty crude version of what a case would be
			in the game loop
			each case in the switch structure will ask the user
			if they're sure of their decision
			activate buttons for prompting user
			check to see if the yes button was hit and where
			the player is currently located
			if true and in proper location 
			buttons or disabled
			confirmTravel boolean is nullified
			player stats and time is updated and displayed
			if not true, case breaks out of switch structure

	7/26
		session notes
			added getChoice() module
			*this module simple asked user for a yes or no decision propt
			and does not end till user makes decision (in theory, haven't used this function before)
			setTrue()/setFalse() modules not disable y/n buttons and end getChoice()
			this frees up a little space in the case

	8/1
		session notes
			finished initial game loop
			added the rest of the switch state and
			the modules that will print out the player's stats
			Also added the modules that call the function and modules
			from the city classes
			**Next step is debugging**

*/

using UnityEngine;
using System.Collections;

public class TripEvents : MonoBehaviour //this is the game loop
{

	public int playerMoney = 1000;
	public int timeOfDay = 6;
	public int dayCount = 1;
	public int playerFuel = 300;
	public int playerLocation = 0;
	public bool? confirmTravel = null; 
	//nullable bool
	public bool gameComplete = false;
	public bool timeAM = true;

	public Button cityXBtn, cityYBtn, cityZBtn, trueBtn, falseBtn;
	public int cityChoice; //variable for string to use for swtich structure

	public bool playerChoice; //to confirm player clicked a prompt


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

		//buttons to confirm travel plans later in game loop
		Button tButton = trueBtn.GetComponent<Button>();
		tButton.onClick.AddListener(SetTrue);
		tButton.gameObject.SetActive(false);
		//these are set to false until the game loop ask the player

		Button fButton = falseBtn.GetComponent<Button>();
		fButton.onClick.AddListener(SetFalse);
		fButton.gameObject.SetActive(false);

	}

	void Update()
	{


		//game loop begins
		while(!gameComplete) //while the game isn't complete, program listens for mouse clicks
		{

			switch(cityChoice)
			{

				case 1:
					//change cityChoice to 0
					//can't null an int without ?
					//city x
					cityChoice = 0;

					//call function to get player decision
					//ADDED 7/26
					getChoice();

					/*
					Debug.Log("Are you sure you would like to travel here? y/n");

					//make the yes and no buttons active
					Button tButton = trueBtn.GetComponent<Button>();
					tButton.onClick.AddListener(SetTrue);
					tButton.gameObject.SetActive(true);
					//these are set to false until the game loop ask the player

					Button fButton = falseBtn.GetComponent<Button>();
					fButton.onClick.AddListener(SetFalse);
					fButton.gameObject.SetActive(true);

					//buttons are active
					//if confirmTravel can not be set to null
					//will have to write 'while loop' for yes/no prompt
					//otherwise game loopw will fall through and always
					//believe decision is false

					OLD CODE 7/26
					*/

					if(confirmTravel == true && playerLocation == 0)
					{

						//future concept
						//ask player if they want to tank up before getting on the road
						//tankUp()

						tButton.gameObject.SetActive(false);
						fButton.gameObject.SetActive(false);
						//turn off/disable buttons

						confirmTravel = null;
						//for next loop

						getCityX();
						//module that calls function from XCity class

						displayTime();
						displayPlayerStats();
						//these modules display the player's current stats

						/*
							I'll figure out how to play an animation of the
							RV sprite moving to the correct location later
						*/
					} else Debug.Log("Invalid travel. Pick again.");

						break;
					//if player hits no/false btn or location is somthing other than location 0
					//the game will ask the player for a selection

					/*
						
						the above is more or less the structure of the game loop
						I expect to do a lot of revision later

					*/

				case 2:
					//change cityChoice to null
					cityChoice = 0;

					//call function to get player decision
					//ADDED 7/26
					getChoice();

					if(confirmTravel == true && playerLocation == 0)
					{

						//future concept
						//ask player if they want to tank up before getting on the road
						//tankUp()

						tButton.gameObject.SetActive(false);
						fButton.gameObject.SetActive(false);
						//turn off/disable buttons

						confirmTravel = null;
						//for next loop

						getCityX();
						getCityY();
						//module that calls function from XCity and YCity class

						displayTime();
						displayPlayerStats();
						//these modules display the player's current stats

						/*
							I'll figure out how to play an animation of the
							RV sprite moving to the correct location later
						*/
					} else if (confirmTravel == true && playerLocation == 1)
						{

							tButton.gameObject.SetActive(false);
							fButton.gameObject.SetActive(false);
							//turn off/disable buttons

							confirmTravel = null;
							//for next loop

							getCityY();

							displayTime();
							displayPlayerStats();

						} else Debug.Log("Invalid travel. Pick again.");

						break;

				case 3:
					//change cityChoice to null
					//city z

					cityChoice = 0;

					//call function to get player decision
					//ADDED 7/26
					getChoice();

					if(confirmTravel == true && playerLocation == 0)
					{

						//future concept
						//ask player if they want to tank up before getting on the road
						//tankUp()

						tButton.gameObject.SetActive(false);
						fButton.gameObject.SetActive(false);
						//turn off/disable buttons

						confirmTravel = null;
						//for next loop

						getCityX();
						getCityY();
						getCityZ();
						//module that calls function from XCity and YCity and ZCity class
						//player drives all the way to the last city

						displayTime();
						displayPlayerStats();
						//these modules display the player's current stats

						gameComplete = true;
						//ends game loop

						/*
							I'll figure out how to play an animation of the
							RV sprite moving to the correct location later
						*/
					} else if (confirmTravel == true && playerLocation == 1)
						{

							tButton.gameObject.SetActive(false);
							fButton.gameObject.SetActive(false);
							//turn off/disable buttons

							confirmTravel = null;
							//for next loop

							getCityY();
							getCityZ();
							//player is at first city and drives to last city

							displayTime();
							displayPlayerStats();

							gameComplete = true;
							//ends game


						} else if (confirmTravel == true && playerLocation == 2)
							{

								tButton.gameObject.SetActive(false);
								fButton.gameObject.SetActive(false);
								//turn off/disable buttons

								confirmTravel = null;
								//for next loop

								getCityZ();
								//player makes it to last city

								displayTime();
								displayPlayerStats();

								gameComplete = true;
								//ends game

							} else Debug.Log("Invalid travel. Pick again.");
					break;

				default:
					//change cityChoice to null
					//default

					cityChoice = 0;
					Debug.Log("What is your destination?");

					break;

			}
		}

		Debug.Log("Congrats!");
		Debug.Log("You have made it to your destination.");
		Debug.Log("Thanks for playing.");

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

	//this module is called when the yes/true button is clicked during the confirmation prompt to the user
	void SetTrue() 
	{

		confirmTravel = true;

		//disable buttons
		//make the yes and no buttons active
		Button tButton = trueBtn.GetComponent<Button>();
		tButton.onClick.AddListener(SetTrue);
		tButton.gameObject.SetActive(false);
		//these are set to false until the game loop ask the player

		Button fButton = falseBtn.GetComponent<Button>();
		fButton.onClick.AddListener(SetFalse);
		fButton.gameObject.SetActive(false);

		playerChoice = true;

	}

	//this module does the exact opposite of it's brother module during the confirmation prompt
	void SetFalse()
	{

		confirmTravel = false;

		//disable buttons
		//make the yes and no buttons active
		Button tButton = trueBtn.GetComponent<Button>();
		tButton.onClick.AddListener(SetTrue);
		tButton.gameObject.SetActive(false);
		//these are set to false until the game loop ask the player

		Button fButton = falseBtn.GetComponent<Button>();
		fButton.onClick.AddListener(SetFalse);
		fButton.gameObject.SetActive(false);

		playerChoice = true;

	}

	void getChoice()
	{


		Debug.Log("Are you sure you would like to travel here? y/n");

		//make the yes and no buttons active
		Button tButton = trueBtn.GetComponent<Button>();
		tButton.onClick.AddListener(SetTrue);
		tButton.gameObject.SetActive(true);
		//these are set to false until the game loop ask the player

		Button fButton = falseBtn.GetComponent<Button>();
		fButton.onClick.AddListener(SetFalse);
		fButton.gameObject.SetActive(true);

		WaitWhile(!playerChoice); //"waits" while player makes choice

		playerChoice = false; //set up for next loop

		//buttons are active
		//if confirmTravel can not be set to null
		//will have to write 'while loop' for yes/no prompt
		//otherwise game loopw will fall through and always
		//believe decision is false

	}

	//simple module that make sure time is displayed in non-military time
	//and never runs over 24 hours
	//I already added time of day with trip time in the parameters
	int checkTime(int tripTime)
	{

		if (tripTime == 12)
		{

			timeAM = false;
			return tripTime;

		} else if (tripTime == 24)
			{

				timeAM = true;
				dayCount++;
				return tripTime;

			} else if (tripTime >= 25)
				{

					tripTime = tripTime - 24;
					timeAM = true;
					dayCount++;
					return tripTime;

				} else if (tripTime > 12)
			{

				timeAM = false;
				return tripTime;

			} else 
		{

			timeAM = true;
			return tripTime;
			//double check this one if error

		}

	}

	//simple module that checks whether the time is in the am or pm
	//resets time if at midnight
	void displayTime()
	{

		if (timeAM && timeOfDay == 24)
			{

				Debug.Log("Time: " + timeOfDay - 12 + " AM");
				timeOfDay = 0;
				//sets time to 0 for next round

			} else if (timeAM)
				{

					Debug.Log("Time: " + timeOfDay + " AM");
					//Displays numbers 1 thru 11 with AM behind them

				}
			else if (!timeAM && timeOfDay == 12)
			{

			Debug.Log("Time " + timeOfDay + " PM");
			//this is the loop for Noon

			}

		else { Debug.Log("Time: " + timeOfDay - 12 + " PM"); }

	}

	//simple module that displays player's stats after a decision
	void displayPlayerStats()
	{

		Debug.Log("Day " + dayCount);
		Debug.Log("Money $" + playerMoney);
		Debug.Log("Fuel " + playerFuel);

	}

	//this module calls all the city classes functions and modules
	//each city is identical at the moment
	//modification will come later
	void getCityX()
	{

		playerMoney = xCity.getMoney(playerMoney);
		//calls XCity class getMoney(); subtracts trip cost from playerMoney
		timeOfDay = xCity.getTime(timeOfDay);
		//adds travel time to the time of day
		timeOfDay = checkTime(timeOfDay);
		//this checks if the time of day is over 24 hour
		//and whether it is AM or PM
		playerFuel = xCity.getFuel(playerFuel);
		//subtracts the fuel needed for the trip
		playerLocation = xCity.setLocation();
		//sets the location of the player

	}

	void getCityY()
	{

		playerMoney = yCity.getMoney(playerMoney);
		//calls XCity class getMoney(); subtracts trip cost from playerMoney
		timeOfDay = yCity.getTime(timeOfDay);
		//adds travel time to the time of day
		timeOfDay = checkTime(timeOfDay);
		//this checks if the time of day is over 24 hour
		//and whether it is AM or PM
		playerFuel = yCity.getFuel(playerFuel);
		//subtracts the fuel needed for the trip
		playerLocation = yCity.setLocation();
		//sets the location of the player
		
	}

	void getCityZ()
	{

		playerMoney = zCity.getMoney(playerMoney);
		//calls XCity class getMoney(); subtracts trip cost from playerMoney
		timeOfDay = zCity.getTime(timeOfDay);
		//adds travel time to the time of day
		timeOfDay = checkTime(timeOfDay);
		//this checks if the time of day is over 24 hour
		//and whether it is AM or PM
		playerFuel = zCity.getFuel(playerFuel);
		//subtracts the fuel needed for the trip
		playerLocation = zCity.setLocation();
		//sets the location of the player
		
	}


}