using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
	public Transform[] waypoints;
	private int i = 0;
	public float speed = 0.3f;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		var dist = Vector2.Distance(transform.position, waypoints[i].position);
		
		if (dist >= 0.02f)
		{
			Vector2 direction = waypoints[i].transform.position - this.transform.position;
			direction.Normalize();
			float factor = Time.deltaTime * speed;
			this.transform.Translate(direction.x * factor, direction.y * factor, 0, Space.World);
		}
		else
		{
			i++;
		}

		if (i >= waypoints.Length)
		{
			i = 0;
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
