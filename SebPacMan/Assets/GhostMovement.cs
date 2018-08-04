using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public Transform[] waypoints;
	public Transform spawnPoint;
	public Transform pacSpawn;


	public int i = 0;
	public float speed = 0.3f;
	public static int PacLives = 3;
	public bool paused;

	public bool Scared;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void FixedUpdate()
	{
			var dist = Vector2.Distance(transform.position, waypoints[i].position); 
			//Finds the distance of the current position to the next

			if (dist >= 0.02f) //Cannot put 0 because once on next position 0 will always be true
			{
				Vector2 direction = waypoints[i].transform.position - this.transform.position;
				direction.Normalize();
				float factor = Time.deltaTime * speed;
				this.transform.Translate(direction.x * factor, direction.y * factor, 0, Space.World);
				//^^ This moves the position of the ghost the next waypoint
			}
			else
			{
				i++;
			}

			if (i >= waypoints.Length) 
			{
				i = 0; //Once the loop is done it will repeat again
			}

			Vector2 dir = waypoints[i].position - transform.position;
			GetComponent<Animator>().SetFloat("DirX", dir.x);
			GetComponent<Animator>().SetFloat("DirY", dir.y);

	}

	void OnTriggerEnter2D(Collider2D co)
	{
			if (co.gameObject.tag == "Player")
			{
			Destroy(co.gameObject);
			}
	}
}
