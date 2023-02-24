using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
	public Transform Checkpoint;
	GameObject player;
	// Use this for initialization
	void Start()
	{

		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider plyr)
	{
		if (plyr.gameObject.tag == "Player")
		{
			player.transform.position = Checkpoint.position;
			player.transform.rotation = Checkpoint.rotation;
		}
	}
}
