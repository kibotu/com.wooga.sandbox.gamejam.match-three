using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public int rows = 9;
	public int columns = 7;
	private Grid grid;
	public Piece startPiece;

	void Start () {
		//coloredGrid.AddComponent<RotateTowardsMouse> ().enabled = false;
		grid = gameObject.AddComponent<Grid> ();
		grid.CreateGrid (rows, columns);

		startPiece = Prefabs.CreateRandomPiece ();
		startPiece.gameObject.AddComponent<DragDrop> ();
	}
}
