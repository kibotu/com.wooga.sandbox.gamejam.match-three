using UnityEngine;
using System.Collections;

public class Scoring : MonoBehaviour {

	public static int finalScore;
	public static int pieceValue = 100;
	public static int mediumGroupSize = 5;
	public static int bigGroupSize = 8;
	public static int mediumBonus = 2; // For matches of medium groups
	public static int bigBonus = 4;//For matches of bigger groups

	public static int levelGoal = 50000;//Score goal to achieve
	public static int moveLimit = 10;//Number of moves available to achieve the goal
	public static int actualMoves = 1;

	public static void setFinalScore(int finalScore) {
		Scoring.finalScore = finalScore;
		ProgressBar bar = GameObject.Find ("ProgressBar").GetComponent<ProgressBar>();
		Stars stars = GameObject.Find ("Stars").GetComponent<Stars>();
		stars.updateStars (finalScore);
		bar.progress = (float)finalScore / (float)stars.threeStarValue;

		GameObject.Find ("Score").guiText.text = finalScore.ToString ();
	}
}
