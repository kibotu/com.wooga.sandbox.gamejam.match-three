using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragDrop : MonoBehaviour {

	// private SwipeRecognizer swipeRecognizer;
	public Grid grid;
	private List<GameObject> selectedTiles;
	public float zIndex = -0.001f;
	public Color highLightColor = new Color (0.3f,0.3f,0.3f);
	public Vector3 StartPosition = new Vector3(0,-6,0);

	void Start () {
		//gameObject.AddComponent<DragRecognizer> ().OnGesture += OnDragDrop;
		//gameObject.AddComponent<ScreenRaycaster> ();
		selectedTiles = new List<GameObject> ();

		transform.position = StartPosition;
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
		gameObject.transform.position = new Vector3(point.x,point.y,zIndex);
	}

	public void OnMouseUp() {

		// 0) something selected?
		if (selectedTiles.Count < 1)
			return;

		// 1) find closest tile
		GameObject closestTile = FindNearestTile ();
	//	closestTile.renderer.material.color -= highLightColor;

		// 2) swap with playerTile and set it towards start position (maybe some transition?)
		// 2.1) set player controlled tile to grid tile
		transform.position = closestTile.transform.position;
		// 2.2 add drag-ability to new tile
		closestTile.AddComponent<DragDrop> (); 
		// 2.3) change index meta info
		GetComponent<TileMetaData> ().index = closestTile.GetComponent<TileMetaData>().index; // not needed currently
		//Debug.Log (closestTile.GetComponent<TileMetaData>().index);

		// 3) find matching tiles
 		gameObject.AddComponent<ExplodeNeighbours> ();


		// 4) make some fancy explosions

		// remove dragging script from old tile
		Destroy (this);
	}

	public void OnCollisionEnter(Collision collision) {
		//collision.gameObject.renderer.material.color += highLightColor;
		if (!selectedTiles.Contains (collision.gameObject))
			selectedTiles.Add (collision.gameObject);
	}

	public void OnCollisionExit(Collision collision) {
	//	collision.gameObject.renderer.material.color -= highLightColor;
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
