using UnityEngine;
using System.Collections;

public class Prefabs : MonoBehaviour {

	public GameObject[] availableColors;

	public void Start()
	{
		Instance = this;
	}
	
	public static Prefabs Instance { get; private set; }
	
	public static GameObject CreateGameObject<T>(T type) where T : Object
	{
		return (GameObject) Instantiate(type); //, new Vector3(0, 0, 0), Quaternion.identity); 
	}

	public static Piece CreateRandomPiece(int x = 0, int y = 0)
	{
		var randomType = Random.Range(0, Instance.availableColors.Length);
		GameObject go = CreateGameObject (Instance.availableColors [randomType]);
		Piece piece = go.AddComponent<Piece> ();
		piece.x = x;
		piece.y = y;
		piece.type = randomType;
		return piece;
	}
}
