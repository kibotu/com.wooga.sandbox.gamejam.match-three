using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour {

	// private SwipeRecognizer swipeRecognizer;
	public Grid grid;
	private List<GameObject> selectedTiles;
	public Color highLightColor = new Color (0.2f,0.2f,0.2f);
    public Vector3 StartPosition = new Vector3(3.3f, -2f, -0.1f);
	private Piece piece;

	void Start () {
		piece = gameObject.GetComponent<Piece> ();
		selectedTiles = new List<GameObject> ();
		grid = GameObject.Find ("Board").GetComponent<Grid>();
		moveToStartPosition ();
	}
	
	void moveToStartPosition() {
		transform.position = StartPosition;
	}

	void OnDragDrop(DragGesture gesture) {
		Vector3 newPos = Camera.main.ScreenToWorldPoint (gesture.TotalMove);
		newPos.z = -5f;
		newPos.y += 5f;
		transform.position = newPos;

		Debug.Log (Camera.main.ScreenToWorldPoint (gesture.TotalMove));
	}

	public void OnMouseDrag () {
		Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		gameObject.transform.position = new Vector3(point.x,point.y,StartPosition.z);
	}

	public void OnMouseUp()
	{
	    grid.ResetColor();

		if (Scoring.moveLimit <= Scoring.actualMoves) {

			Stars stars = GameObject.Find ("Stars").GetComponent<Stars>();

			// one more stars => win screen
			// less than one star => losing screen
			Application.LoadLevel(stars.oneStar.isEnabled() ? (int)Prefabs.Scene.winscreen : (int)Prefabs.Scene.losingscreen);
		}

		// 0) something selected?
		if (selectedTiles.Count < 1) {
			moveToStartPosition();
			return;
		}
			

		// 1) find closest tile
        Piece closestPiece = FindNearestTile();

		// can't drop same color on same tile
		if (piece.type == closestPiece.type) {
			//Debug.Log ("dropped on same color");
			moveToStartPosition ();
			return; 
		}

		//Debug.Log ("doing some floodflill");

		// 2) swap with playerTile and set it towards start position (maybe some transition?)
		// 2.1) set player controlled tile to grid tile
		transform.position = closestPiece.gameObject.transform.position;
		// 2.2 add drag-ability to new tile
		closestPiece.gameObject.AddComponent<DragDrop> (); 
		// 2.3) change index meta info

		piece.SwapPosition (closestPiece); // not needed currently

		// move limit
		Scoring.actualMoves++;

		// update moves label
		GameObject.Find ("Moves").guiText.text = ""+(Scoring.moveLimit +1 - Scoring.actualMoves);

		//Debug.Log (closestTile.GetComponent<TileMetaData>().index);

		// 3) find matching tiles
		FloodFill floodFill = new FloodFill ();
		List<Piece> matches = floodFill.FillFromPiece(gameObject.GetComponent<Piece>(), grid);
		// gameObject.AddComponent<ExplodeNeighbours> ().Neighbours = Neighbours;

	

		// 4) make some fancy explosions
		if (matches.Count > 2) {

			int bonusValue;
			if(matches.Count >= Scoring.mediumGroupSize && matches.Count < Scoring.bigGroupSize)
			{
				bonusValue = Scoring.mediumBonus;
			}else if(matches.Count >= Scoring.bigGroupSize)
			{
				bonusValue = Scoring.bigBonus;
			}else
			{
				bonusValue = 1;
			}
			
			Scoring.setFinalScore(Scoring.finalScore + (Scoring.pieceValue * matches.Count * bonusValue));
			Debug.Log("Score earned for the match: " + Scoring.finalScore);
			Debug.Log("Final Score: " + Scoring.finalScore);


			List<int> cols = new List<int>();

			Debug.Log ("Desotryed " + matches.Count + " Pieces");
			foreach (Piece match in matches) {

				// match.AddComponent<Explode>();

				grid.SetPieceAt(null, match.x, match.y);

				if(!cols.Contains(match.x))
				   cols.Add(match.x);


				Destroy (match.gameObject);
			}

			grid.dropRows(cols);
		}

		// remove dragging script from old tile
		Destroy (this);
	}

	public void OnCollisionEnter(Collision collision) {
	    foreach (var c in collision.contacts)
	    {
            if (!selectedTiles.Contains(c.otherCollider.gameObject))
            {
                selectedTiles.Add(c.otherCollider.gameObject);
                c.otherCollider.gameObject.renderer.material.color += highLightColor;
            }
	    }
	}

	public void OnCollisionExit(Collision collision) {

        foreach (var c in collision.contacts)
        {
            if (selectedTiles.Contains(c.otherCollider.gameObject))
            {
                selectedTiles.Remove(c.otherCollider.gameObject);
                c.otherCollider.gameObject.renderer.material.color = c.otherCollider.gameObject.GetComponent<Piece>().color;
            }
        }
	}

	private Piece FindNearestTile() {
		GameObject closest = selectedTiles[0];
		float smallestDistance = Vector3.Distance(transform.position, closest.transform.position);
		for(int i = 1; i < selectedTiles.Count; ++i)
		{
			float dis = Vector3.Distance(transform.position, selectedTiles[i].transform.position);
			if(smallestDistance >= dis) {
				closest = selectedTiles[i];
			    smallestDistance = dis;
			}
		}
		return closest.GetComponent<Piece>();
	}
}
