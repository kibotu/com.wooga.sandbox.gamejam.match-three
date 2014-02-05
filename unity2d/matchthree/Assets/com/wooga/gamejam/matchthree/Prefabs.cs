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

	public static GameObject CreateRandomColor() {

		return CreateGameObject(Instance.availableColors[Random.Range (0, Instance.availableColors.Length)]);
	}
}
