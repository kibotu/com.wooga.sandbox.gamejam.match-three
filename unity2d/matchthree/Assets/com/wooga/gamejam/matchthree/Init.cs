using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	void Start () {
		var board = new GameObject("Board");
		board.AddComponent<Board>();
		Destroy(gameObject);

		// reset score, stars and moves
		Scoring.actualMoves = 1;
		Scoring.finalScore = 0;
		
		GameObject.Find ("Score").guiText.text = "0";
		GameObject.Find ("Moves").guiText.text = ""+Scoring.moveLimit;
		GameObject.Find ("Objectives").guiText.text = ""+ GameObject.Find ("Stars").GetComponent<Stars> ().threeStarValue;
	}
}
