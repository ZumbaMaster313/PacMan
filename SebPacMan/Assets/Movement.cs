using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour {

	[SerializeField]
	private float speed = 1f;

	private Rigidbody2D rb2d;

	private bool movingUp;
	private bool movingDown;
	private bool movingLeft;
	private bool movingRight;

	Vector2 dest = Vector2.zero;

	// Use this for initialization
	void Start () {

		//Get and store a reference to the Rigidbody2D component so that we can access it.
		rb2d = GetComponent<Rigidbody2D> ();
		dest = transform.position;

	}

	// Update is called once per frame
	void FixedUpdate ()
	{

		//Checks to see if moving up
		if (Input.GetKeyDown ("up") || Input.GetKeyDown ("w")
			|| ((Input.GetKeyUp ("right") || Input.GetKeyUp ("d") || Input.GetKeyUp ("left") || Input.GetKeyUp ("a") || Input.GetKeyUp ("down") || Input.GetKeyUp ("s")) 
				&& (Input.GetKey ("up") || Input.GetKey ("w"))))
		{
			movingUp = true;
			movingDown = false;
			movingLeft = false;
			movingRight = false;
		}

		//Checks to see if moving down
		else if (Input.GetKeyDown ("down") || Input.GetKeyDown ("s")
			|| ((Input.GetKeyUp ("right") || Input.GetKeyUp ("d") || Input.GetKeyUp ("left") || Input.GetKeyUp ("a") || Input.GetKeyUp ("up") || Input.GetKeyUp ("w")) 
				&& (Input.GetKey ("down") || Input.GetKey ("s"))))
		{
			movingUp = false;
			movingDown = true;
			movingLeft = false;
			movingRight = false;
		}

		//Checks to see if moving left
		else if (Input.GetKeyDown ("left") || Input.GetKeyDown ("a")
			|| ((Input.GetKeyUp ("right") || Input.GetKeyUp ("d") || Input.GetKeyUp ("up") || Input.GetKeyUp ("w") || Input.GetKeyUp ("down") || Input.GetKeyUp ("s")) 
				&& (Input.GetKey ("left") || Input.GetKey ("a"))))
		{
			movingUp = false;
			movingDown = false;
			movingLeft = true;
			movingRight = false;
		}

		else if (Input.GetKeyDown ("right") || Input.GetKeyDown ("d")
			|| ((Input.GetKeyUp ("left") || Input.GetKeyUp ("a") || Input.GetKeyUp ("up") || Input.GetKeyUp ("w") || Input.GetKeyUp ("down") || Input.GetKeyUp ("s")) 
				&& (Input.GetKey ("right") || Input.GetKey ("d"))))
		{
			movingUp = false;
			movingDown = false;
			movingLeft = false;
			movingRight = true;
		}

		if (movingUp == true)
		{
			dest = (Vector2)transform.position + Vector2.up;
			this.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
		}
		else if (movingDown == true)
		{
			dest = (Vector2)transform.position - Vector2.up;
			this.transform.position += new Vector3(0, -2.5f, 0) * Time.deltaTime;
		}
		else if (movingRight == true)
		{
			dest = (Vector2)transform.position + Vector2.right;
			this.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
		}
		else if (movingLeft == true)
		{
			dest = (Vector2)transform.position - Vector2.right;
			this.transform.position += new Vector3(-2.5f, 0, 0) * Time.deltaTime;
		}

		Vector2 dir = dest - (Vector2)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

}
