using UnityEngine;
using System.Collections;

public class GuiMenu : MonoBehaviour {

	public float originalWidth = 800f;  // define here the original resolution
	public float originalHeight = 480f; // you used to create the GUI contents 
	private Vector3 scale;
	
	private float btnWidth = 150f;
	private float btnHeight = 75f;
	public Rect button;

	public int scene;
	public string btnText;

	void Start() {
		if(button == null) button = new Rect (originalWidth / 2 - btnWidth / 2, originalWidth / 2 - btnHeight / 2 + btnHeight * 2, btnWidth, btnHeight);
	}

	void OnGUI() {
		
		scale.y = Screen.height/originalHeight; // calculate vert scale
		scale.x = scale.y; // this will keep your ratio base on Vertical scale
		scale.z = 1;
		var svMat = GUI.matrix; // save current matrix
		// substitute matrix - only scale is altered from standard
		float scaleX = Screen.width/originalWidth; // store this for translate
		//GUI.matrix = Matrix4x4.TRS(new Vector3( (scaleX - scale.y) / 2 * originalWidth, 0, 0), Quaternion.identity, scale);

		if(GUI.Button(button, btnText)) {
			Application.LoadLevel(scene);
		}
		
		GUI.matrix = svMat;
	}
}
