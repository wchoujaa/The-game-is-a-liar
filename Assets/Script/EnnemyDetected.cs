using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDetected : MonoBehaviour
{

	public UnityEngine.AI.NavMeshAgent agent;
	public Transform position;
    // Start is called before the first frame update
    void Start()
    {

	}


	void OnTriggerEnter(Collider other)
	{
		agent.SetDestination(position.position);
	}
}
