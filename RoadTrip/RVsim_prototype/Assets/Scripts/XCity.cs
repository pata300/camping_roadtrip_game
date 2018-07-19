using UnityEngine;
using System.Collections;

//inherits from city class

public class XCity : City 
{

	public XCity()
	{

		cityName = "X City";
		Debug.Log("You are in " + cityName);

	}

	//example of module overriding by sending variable to base class
	public XCity(string newCity) : base(newCity)
	{

		cityName = newCity;

	}

	public int setLocation()
	{

		playerLocation = 1;
		return playerLocation;

	}

}