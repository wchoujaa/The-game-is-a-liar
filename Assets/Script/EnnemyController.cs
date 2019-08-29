using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : AController
{


	public override void Death()
	{
		base.Death();

		ScoreManager.score += ScoreManager.scoreData.Enemy;
		// After 2 seconds destory the enemy.
		Destroy(gameObject, 2f);
	}
}
