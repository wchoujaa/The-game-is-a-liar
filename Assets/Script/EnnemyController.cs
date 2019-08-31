using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : AController
{

	public AudioClip monster;
	public float soundInterval;
	void Start()
	{
		StartCoroutine(PlayAudio());
	}

	IEnumerator PlayAudio()
	{
		while (isActiveAndEnabled)
		{
			yield return new WaitForSeconds(soundInterval + Random.Range(0f, 8f));

			audioSource.clip = monster;
			audioSource.Play();
		}
	}

	public override void Death()
	{
		base.Death();
		//animator.SetTrigger("dead");
		ScoreManager.score += ScoreManager.scoreData.Enemy;
		// After 2 seconds destory the enemy.
		Destroy(gameObject, 2f);
	}
}
