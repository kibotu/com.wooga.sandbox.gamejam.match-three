using UnityEngine;
using System.Collections;

public class Prefabs : MonoBehaviour {

	public GameObject[] availableColors;
	private static Grid grid;

	public void Start()
	{
		Instance = this;
	}
	
	public static Prefabs Instance { get; private set; }
	
	public static GameObject CreateGameObject<T>(T type) where T : Object
	{
		return (GameObject) Instantiate(type); //, new Vector3(0, 0, 0), Quaternion.identity); 
	}

	public static Piece CreateRandomPiece(int x, int y)
	{
		if(grid == null) 
			grid = GameObject.Find ("Board").GetComponent<Grid>();

		var randomType = Random.Range(0, Instance.availableColors.Length);
		GameObject go = CreateGameObject (Instance.availableColors [randomType]);
		Piece piece = go.AddComponent<Piece> ();
		piece.x = x;
		piece.y = y;
		piece.type = randomType;
		piece.transform.position = new Vector3(x * (1 + grid.spacing), y * (1 + grid.spacing), 0);
		return piece;
	}
}
