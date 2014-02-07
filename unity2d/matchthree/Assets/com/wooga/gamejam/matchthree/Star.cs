using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

	public Vector2 pos;
	public Vector2 size;
	public Texture2D emptyStar;
	public Texture2D filledStar;
	private bool isEmpty;
	
	void Awake() {
		isEmpty = true;
		size = new Vector2 (15,15);
		pos = new Vector2 (0,0);
	}
	
	public void OnGUI()
	{
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), isEmpty ? emptyStar : filledStar);
	} 

	public void toggleStar() {
		isEmpty = !isEmpty;
	}

	public void enable(bool isEnabled) {
		isEmpty = !isEnabled;
	}

	public bool isEnabled() {
		return !isEmpty;
	}
}
