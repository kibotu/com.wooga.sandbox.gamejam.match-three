using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour {

	public float progress;
	public Vector2 pos;
	public Vector2 size;
	public Texture2D progressBarEmpty;
	public Texture2D progressBarFull;

	void Start() {
		if(pos != null) pos = new Vector2 (5.5f,13f);
		if(size != null) size = new Vector2 (72.5f,15f);
	}
	
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x, size.y), progressBarEmpty);
		GUI.DrawTexture(new Rect(pos.x, pos.y, size.x * Mathf.Clamp01(progress), size.y), progressBarFull);
	} 
}
