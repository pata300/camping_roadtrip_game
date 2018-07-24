using UnityEngine;
using System.Collections;


public class City //base class
{
	
	public const int TRIPCOST, TRAVELTIME, FUELNEEDED;
	public int playerLocation;
	public string cityName;

	public City()
	{

		//default cost to travel from city to city
		TRIPCOST = 50;
		TRAVELTIME = 4;
		FUELNEEDED = 150;

		cityName = "base city";

		Debug.Log("Base City variables set");

	}

	public City(string newCity) //module overriding
	{

		cityName = newCity; //allows you to keep track of which city you're in
		Debug.Log("You are now in" + newCity);

	}

	public int getMoney(int playerMoney) //fucntion updates the player's cash after the trip cost
	{

		playerMoney = playerMoney - TRIPCOST;
		return playerMoney;

	}

	public int getTime(int timeOfDay) //returns the time of the day
	{

		timeOfDay = checkTime(timeOfDay + TRAVELTIME);
		return timeOfDay;

	}

	public int getFuel(int playerFuel) //returns the amount of fuel left
	{

		playerFuel = playerFuel - FUELNEEDED;
		return playerFuel;

	}

	public int setLocation() //return the player's location
	{

		playerLocation = 0;
		return playerLocation;
	}
}