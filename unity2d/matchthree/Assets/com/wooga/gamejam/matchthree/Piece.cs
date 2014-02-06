using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public int x;
	public int y;
	public int type;

	public void SwapPosition(Piece other) {
		int tmp = x;
		x = other.x;
		other.x = tmp;

		tmp = y;
		x = other.y;
		other.y = tmp;
		
		Vector3 t = gameObject.transform.position;
		gameObject.transform.position = other.gameObject.transform.position;
		other.gameObject.transform.position = t;
	}
}
