using UnityEngine;
using System.Collections;

public class GuiMenu : MonoBehaviour {

	private float btnWidth = 150f;
	private float btnHeight = 75f;
	public Rect button;

	public int scene;
	public string btnText;

	void Start() {
		if(button == null) button = new Rect (Screen.width / 2 - btnWidth / 2, Screen.height / 2 - btnHeight / 2 + btnHeight * 2, btnWidth, btnHeight);
	}

	void OnGUI() {
		if(GUI.Button(button, btnText)) {
			Application.LoadLevel(scene);
		}
	}
}
