using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AController
{

	public float speed;
	private float translation;
	private float straffe;
	public LayerMask collectableLayer;
	public GameManager gameManager;

	public AudioClip collecting;
	public AudioClip HeartBeats;


	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if(CameraMovement.escape == true)
		{
			return;
		}

		var x = Input.GetAxis("Horizontal");
		var y = Input.GetAxis("Vertical");

		translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		transform.Translate(straffe, 0, translation);

		if (Input.GetKeyDown("escape"))
		{
			// turn on the cursor
			Cursor.lockState = CursorLockMode.None;
		}
	}


	void OnTriggerEnter(Collider other)
	{


		if ((collectableLayer.value & 1 << other.gameObject.layer) == 1 << other.gameObject.layer)
		{
			if (other.gameObject.CompareTag("Blue"))
			{
				ScoreManager.score += ScoreManager.scoreData.BlueStone;
			}
			if (other.gameObject.CompareTag("Red"))
			{
				ScoreManager.score += ScoreManager.scoreData.RedStone;
			}

			audioSource.clip = collecting;
			audioSource.Play();


			other.gameObject.SetActive(false);

		}
		else if (other.gameObject.CompareTag("CheckPoint"))
		{
			gameManager.CurrentCheckPoint = other.gameObject;
		}
	}

	internal void Reset()
	{
		currentHealth = startingHealth;
		HealthBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthBarWidth);

	}

	public override void Death()
	{
		gameManager.LoadLastCheckPoint();
	}
}
