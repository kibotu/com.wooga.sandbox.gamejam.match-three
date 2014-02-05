using UnityEngine;
using System.Collections;

public class Prefabs : MonoBehaviour {

	public GameObject Yellow;
	public GameObject Red;
	public GameObject Blue;
	public GameObject Green;
	public GameObject White;
	public GameObject Purple;

	public void Start()
	{
		Instance = this;
	}
	
	public static Prefabs Instance { get; private set; }
	
	private static GameObject CreateGameObject<T>(T type) where T : Object
	{
		return (GameObject) Instantiate(type); //, new Vector3(0, 0, 0), Quaternion.identity); 
	}
}
