using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
public class DotExterminate : MonoBehaviour {

	// Use this for initialization
	public static int Points;
	public bool paused = false;
	public Text pointsText;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Points == 2450)
		{
			paused = true;
		}
		if (paused == true)
		{
			Time.timeScale = 0;
		}
		else if (paused == false)
		{
			Time.timeScale = 1;
		}
	}

	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.gameObject.tag == "Player")
		{
			Points = Points + 10;
			Destroy(gameObject);
		}
	}


}

