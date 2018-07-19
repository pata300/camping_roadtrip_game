using UnityEngine;
using System.Collections;

//inherits from city class

public class ZCity : City 
{

	public ZCity()
	{

		cityName = "Z City";
		Debug.Log("You are in " + cityName);

	}

	//example of module overriding by sending variable to base class
	public XCity(string newCity) : base(newCity)
	{

		cityName = newCity;

	}

	public int setLocation()
	{

		playerLocation = 3;
		return playerLocation;

	}

}