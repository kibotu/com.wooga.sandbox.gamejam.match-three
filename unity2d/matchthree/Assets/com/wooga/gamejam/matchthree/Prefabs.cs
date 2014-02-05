using UnityEngine;
using System.Collections;

public class Prefabs : MonoBehaviour {

	public GameObject Yellow;
	public GameObject Red;
	public GameObject Blue;
	public GameObject Green;
	public GameObject White;
	public GameObject Purple;

	private GameObject[] availableColors;

	public void Start()
	{
		availableColors = new GameObject[] {
			Yellow, Red, Blue, Green, White, Purple
		};

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
