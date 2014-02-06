using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	public int rows = 7;
	public int columns = 9;
	private Grid grid;
	public GameObject StartTile;

	void Start () {
		//coloredGrid.AddComponent<RotateTowardsMouse> ().enabled = false;
		grid = gameObject.AddComponent<Grid> ();
		grid.CreateGrid (rows, columns);

		AddStartTile ();
	}

	void AddStartTile() {
		StartTile = Prefabs.CreateRandomColor ();
		StartTile.AddComponent<DragDrop> ();
	}
	
	void Update () {
	
	}
}
