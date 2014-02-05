using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	private Grid grid;

	void Start () {
		grid = gameObject.AddComponent<Grid> ();
		grid.CreateGrid (9, 7);

		Populate ();
	}

	void Populate() {
		
	}
	
	void Update () {
	
	}
}
