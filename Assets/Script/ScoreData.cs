using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Score/ScoreStats")]
public class ScoreData : ScriptableObject
{
	public float Medium;
	public float High;
	public float Low;

	public float Enemy;
	public float RedStone;
	public float BlueStone;
}