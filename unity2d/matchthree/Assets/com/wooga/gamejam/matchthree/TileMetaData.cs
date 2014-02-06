using UnityEngine;

public class TileMetaData : MonoBehaviour {

	public int x;
	public int y;
	public int index;
    public int type;

	public void swapPosition(GameObject other) {
		TileMetaData otherMeta = other.GetComponent<TileMetaData> ();
		int tmp;
		tmp = x;
		x = otherMeta.x;
		otherMeta.x = tmp;
		
		tmp = y;
		y = otherMeta.y;
		otherMeta.y = tmp;
	}

	public string ToString() {
		return "[" + x + "," + y + "] " + type;
	}
}
