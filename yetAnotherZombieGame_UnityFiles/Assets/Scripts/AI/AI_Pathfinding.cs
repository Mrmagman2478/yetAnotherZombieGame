using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Pathfinding : MonoBehaviour {

    GameObject player;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.GetComponent<NavMeshAgent>().enabled && player.GetComponent<Character_Movement>().enabled == true)
        {
            agent.SetDestination(player.transform.position);
        }
	}
}
