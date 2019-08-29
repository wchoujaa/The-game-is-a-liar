using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public static float score;        // The player's score.

	public TMP_Text scoreText;
	public static ScoreData scoreData;

	public ScoreData scoreDataInstance;

	void Awake()
	{
		scoreData = scoreDataInstance;
		// Set up the reference.
		// Reset the score.
		score = 0;
	}


	void Update()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		scoreText.text = "Score: " + score;
	}
}