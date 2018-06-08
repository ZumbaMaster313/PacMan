using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public Transform refPoint;
	public Transform refPoint2;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isPassingL())
		{
			this.transform.position = new Vector2(2, 0);
		}

		if (isPassingR())
		{
			this.transform.position = new Vector2(-5, 0);
		}
	}

	bool isPassingL()
	{
		if (this.transform.position.x <= refPoint2.transform.position.x)
		{
			return true;
		}
		else
		{
			return false;

		}
	}
	bool isPassingR()
	{
		if (this.transform.position.x >= refPoint.transform.position.x)

		{
			return true;
		}
		else
		{
			return false;
		}
	}
}

 

