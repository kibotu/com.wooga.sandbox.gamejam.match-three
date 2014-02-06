using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public int columns;
	public int rows;
	public float spacing = 0.1f;
	public GameObject[,] grid;

	public void CreateGrid (int rows, int columns, float spacing = 0.1f) {

		this.rows = rows;
		this.columns = columns;

		grid = new GameObject[rows, columns];

		float y = 0;
		float x = 0;
		for (y = 0; y < columns; y+=1+spacing) {
			for(x = 0; x < rows; x+=1+spacing) {
				var tile = Prefabs.CreateRandomColor ();
				tile.transform.localPosition = new Vector2(x, y);
				tile.transform.parent = transform;
				grid[(int)x,(int)y] = tile;
				TileMetaData meta = tile.GetComponent<TileMetaData>();
				meta.x = (int)x;
				meta.y = (int)y;
			}
		};
		//Camera.main.transform.position = new Vector3 (x/2 + (1+spacing)/2, y/2+ (1+spacing)/2, 1);
	}

	public GameObject CellAtXY(Vector2 c) {
		return c.x < 0 || c.x >= rows || c.y < 0 || c.y >= columns ? null : grid[(int)c.x,(int)c.y];
	}

	public void movePieceFromTo(int sx, int sy, int tx, int ty) {

		Debug.Log ("Moving [" + sx + "," + sy + "] to " + "["+tx+","+ty+"]"); 

		GameObject toMove = grid [sx, sy];
		TileMetaData meta = toMove.GetComponent<TileMetaData> ();
	//meta.x = tx;
	//	meta.y = ty;

		for(int y = columns-1; y >= (int) ty; --y) {


			grid[sx, y].transform.position = new Vector3(grid[sx, y].transform.position.x, y  * (1 + spacing) - (1 + spacing) , 0);
		}

		//grid [tx, ty] = toMove;
	}
	
	void Update () {
	
	}
}
