using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_behavior : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;

    public int lives = 1;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null && player != null)
        {
            //mover por IA
            agent.SetDestination(player.transform.position);
        }
    }
}
