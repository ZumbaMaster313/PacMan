using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsCounter : MonoBehaviour
{
	public Text pointsText;
	public static int score;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		score = DotExterminate.Points;
		pointsText.text = "Points: " + score;

		if (score >= 2450)
		{
			pointsText.text = "You Win!";
		}
	}

	


}
