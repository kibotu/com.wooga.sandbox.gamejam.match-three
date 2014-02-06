using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour {

	// private SwipeRecognizer swipeRecognizer;
	public Grid grid;
	private List<GameObject> selectedTiles;
	public Color highLightColor = new Color (0.2f,0.2f,0.2f);
    public Vector3 StartPosition = new Vector3(3.5f, -1.8f, -1f);
    public List<GameObject> Neighbours;

	void moveToStartPosition() {
		
		transform.position = StartPosition;
	}

	void Start () {
		//gameObject.AddComponent<DragRecognizer> ().OnGesture += OnDragDrop;
		//gameObject.AddComponent<ScreenRaycaster> ();
		selectedTiles = new List<GameObject> ();

        Neighbours = new List<GameObject>();

		grid = GameObject.Find ("Board").GetComponent<Grid>();
		moveToStartPosition ();
	}
	
	void Update () {

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

	public void OnMouseUp() {

		// 0) something selected?
		if (selectedTiles.Count < 1)
			return;

		// 1) find closest tile
		GameObject closestTile = FindNearestTile ();

		// can't drop same color on same tile
		if (gameObject.GetComponent<TileMetaData> ().type == closestTile.GetComponent<TileMetaData> ().type) {
			//Debug.Log ("dropped on same color");
			moveToStartPosition ();
			return; 
		}

		//Debug.Log ("doing some floodflill");
			
	//	closestTile.renderer.material.color -= highLightColor;

		// 2) swap with playerTile and set it towards start position (maybe some transition?)
		// 2.1) set player controlled tile to grid tile
		transform.position = closestTile.transform.position;
		// 2.2 add drag-ability to new tile
		closestTile.AddComponent<DragDrop> (); 
		// 2.3) change index meta info

		GetComponent<TileMetaData> ().swapPosition(closestTile); // not needed currently

		//Debug.Log (closestTile.GetComponent<TileMetaData>().index);

		// 3) find matching tiles
		FloodFill floodFill = new FloodFill ();
		List<GameObject> matches = floodFill.FillFromPiece(gameObject, grid);
		// gameObject.AddComponent<ExplodeNeighbours> ().Neighbours = Neighbours;

		// 4) make some fancy explosions
		Debug.Log ("Amount matches: " + matches.Count);
		if (matches.Count > 2) {
			foreach (GameObject match in matches) {
				// match.AddComponent<Explode>();

				TileMetaData meta = match.GetComponent<TileMetaData>();


				//grid.movePieceFromTo((int)meta.x, (int)meta.y + 1, (int)meta.x, (int)meta.y);
				Destroy (match);
			}
		}

		// remove dragging script from old tile
		Destroy (this);
	}

	public void OnCollisionEnter(Collision collision) {
		//collision.gameObject.renderer.material.color += highLightColor;
		if (!selectedTiles.Contains (collision.gameObject))
			selectedTiles.Add (collision.gameObject);
	}

	public void OnCollisionExit(Collision collision) {
		//collision.gameObject.renderer.material.color -= highLightColor;
		selectedTiles.Remove (collision.gameObject);
	}

	private GameObject FindNearestTile() {
		GameObject closest = selectedTiles[0];
		float smallestDistance = Vector3.Distance(transform.position, closest.transform.position);
		for(int i = 1; i < selectedTiles.Count; ++i) {
			float dis = Vector3.Distance(transform.position, selectedTiles[i].transform.position);
			if(smallestDistance >= dis) {
				closest = selectedTiles[i];
			}
		}
		return closest;
	}
}
