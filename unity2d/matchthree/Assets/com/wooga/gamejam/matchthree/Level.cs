using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private Grid grid;
	private GameObject coloredGrid;
	public GameObject StartTile;

	void Start () {
		coloredGrid = new GameObject ("ColoredGrid");
		coloredGrid.AddComponent<RotateTowardsMouse> ().enabled = false;
		grid = gameObject.AddComponent<Grid> ();
		grid.CreateGrid (9, 7);

		Populate ();

		AddStartTile ();
	}

	void AddStartTile() {
		StartTile = Prefabs.CreateRandomColor ();
		StartTile.AddComponent<DragDrop> ().grid = grid;
	}

	void Populate() {

		Transform [] children = grid.gameObject.GetComponentsInChildren<Transform> ();
		for(int i = 1; i < children.Length; ++i) { // start at 1, because we don't need the parent grid empty
			var tile = Prefabs.CreateRandomColor ();
			tile.transform.position = children[i].transform.position;
			tile.GetComponent<TileMetaData>().index = i;
			tile.transform.parent = coloredGrid.transform;
		}

		grid.gameObject.SetActive (false);
	}
	
	void Update () {
	
	}
}
