using UnityEngine;
using System.Collections;

public class GuiMenu : MonoBehaviour {

	private float btnWidth = 100f;
	private float btnHeight = 50f;

	void Start () {
	}
	
	void Update () {
		
	}

	void OnGUI() {
		if(GUI.Button(new Rect(Screen.width/2 - btnWidth/2,Screen.height / 2 -btnHeight/2 + btnHeight * 3,btnWidth,btnHeight), "Start Game")) {
			var level = new GameObject("Grid");
			level.AddComponent<Level>();
			Destroy(gameObject);
		}
	}
}
