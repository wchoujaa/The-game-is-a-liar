using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject startSpawn;
	public GameObject Player;
	private GameObject currentCheckPoint;

	public GameObject CurrentCheckPoint
	{
		get
		{
			return currentCheckPoint;
		}

		set
		{
			currentCheckPoint = value;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		Player.transform.position = startSpawn.transform.position;
		Player.transform.localRotation = startSpawn.transform.localRotation;
    }

	public void LoadLastCheckPoint()
	{
		Player.transform.position = CurrentCheckPoint.transform.position;
		Player.transform.localRotation = CurrentCheckPoint.transform.localRotation;

		Player.GetComponent<PlayerController>().Reset();
	}
}
