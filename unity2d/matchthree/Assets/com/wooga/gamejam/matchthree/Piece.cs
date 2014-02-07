using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public int x;
	public int y;
	public int type;
    public Color color;

    void Start()
    {
        color = renderer.material.color;
    }

	public void SwapPosition(Piece other) {
		int tmp = x;
		x = other.x;
		other.x = tmp;

		tmp = y;
		y = other.y;
		other.y = tmp;

		
		Vector3 t = gameObject.transform.position;
		gameObject.transform.position = other.gameObject.transform.position;
		other.gameObject.transform.position = t;

		GameObject.Find ("Board").GetComponent<Grid>().SetPieceAt(this,x,y);
	}

	public string ToString() {
		return name + " [" + x + "," + y + "]";
	}
}
