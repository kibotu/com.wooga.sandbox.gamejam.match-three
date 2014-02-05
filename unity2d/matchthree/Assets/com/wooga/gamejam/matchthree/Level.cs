using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private Grid grid;
	private GameObject coloredGrid;
	public GameObject StartTile;

	void Start () {
		coloredGrid = new GameObject ("ColoredGrid");
		grid = gameObject.AddComponent<Grid> ();
		grid.CreateGrid (9, 7);

		Populate ();

		AddStartTile ();
	}

	void AddStartTile() {
		StartTile = Prefabs.CreateRandomColor ();
		StartTile.transform.position = new Vector3 (-4.5f, 0, -5);
		StartTile.AddComponent<DragDrop> ();
	}

	void Populate() {

		Transform [] children = grid.gameObject.GetComponentsInChildren<Transform> ();
		for(int i = 0; i < children.Length; ++i) {
			var tile = Prefabs.CreateRandomColor ();
			tile.transform.position = children[i].transform.position;
			tile.transform.parent = coloredGrid.transform;
		}

		grid.enabled = false;
	}
	
	void Update () {
	
	}
}
