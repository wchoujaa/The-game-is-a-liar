using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
	Transform player;               // Reference to the player's position.
	AController playerHealth;      // Reference to the player's health.
	AController enemyHealth;        // Reference to this enemy's health.
	UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.
	public float rangeSqr;

	void Awake()
	{
		// Set up the references.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		playerHealth = player.GetComponent<AController>();
		enemyHealth = GetComponent<AController>();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}



	void GetInactiveInRadius()
	{

		
			float distanceSqr = (transform.position - player.transform.position).sqrMagnitude;
			if (distanceSqr < rangeSqr)
				nav.SetDestination(player.position);

	}

	void Update()
	{
		// If the enemy and the player have health left...
		if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
		{
			GetInactiveInRadius();
		}
		// Otherwise...
		else
		{
			// ... disable the nav mesh agent.
			nav.enabled = false;
		}
	}
}