using UnityEngine;
using System.Collections;

//inherits from city class

public class YCity : City 
{

	public YCity()
	{

		cityName = "Y City";
		Debug.Log("You are in " + cityName);

	}

	//example of module overriding by sending variable to base class
	public YCity(string newCity) : base(newCity)
	{

		cityName = newCity;

	}

	public int setLocation()
	{

		playerLocation = 2;
		return playerLocation;

	}

}