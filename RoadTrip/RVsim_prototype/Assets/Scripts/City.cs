using UnityEngine;
using System.Collections;


public class City //base class
{
	
	public CONSTANT int TRIPCOST, TRAVELTIME, FUELNEEDED;
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
	
}