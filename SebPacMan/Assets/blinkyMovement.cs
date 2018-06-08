using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkyMovement : MonoBehaviour {
	public Transform[] waypoints;
	public Transform[] refPoints;

	private int i = 0;
	int j = 0;
	int k;
	public float speed = 0.3f;
	float activeFollowRadius = 6f;

	public Transform Player;

	bool Switch;
	// Use this for initialization
	void Start()
	{
		Switch = false;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (IsPlayerWithinFollowRadius())
		{
			Switch = true;
		}

		if (Switch != true)
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
		}

		if (Switch == true)
		{
			
		}
		Vector2 dir = waypoints[i].position - transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		GetComponent<Animator>().SetFloat("DirY", dir.y);

	}

	bool IsPlayerWithinFollowRadius()
	{
		var distanceToPlayer = (Player.transform.position - this.transform.position).magnitude;
		if (distanceToPlayer <= activeFollowRadius)
		{
			return true;
		}
		else
		{
			return false;
		}
	}


	void OnTriggerEnter2D(Collider2D co)
	{
		if (co.gameObject.tag == "Player")
		{
			Destroy(co.gameObject);
		}
	}

	public Transform FindClosest(Transform[] targets)
	{
    var closestDistance = (refPoints[0].position - this.transform.position).sqrMagnitude;
	var targetNumber = 0;

    for (j = 1; j < targets.Length; j++)
		{
        var thisDistance = (refPoints[i].position - this.transform.position).sqrMagnitude;

        if (thisDistance < closestDistance)
		{
            closestDistance = thisDistance;
            targetNumber = i;
        }
    }
    return refPoints[targetNumber];
	}
}
