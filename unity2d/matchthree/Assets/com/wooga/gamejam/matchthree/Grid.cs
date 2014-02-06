using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public int columns; // x
	public int rows; // y
	public float spacing = 0.1f;
	public Piece[,] grid;

	public void CreateGrid (int rows, int columns, float spacing = 0.1f) {

		this.rows = rows;
		this.columns = columns;

		grid = new Piece[columns,rows];

		int r = 0;
		int c = 0;
		float y = 0;
		float x = 0;
		for(y = 0; y < rows; y+=1+spacing) {
			for (x = 0; x < columns; x+=1+spacing) {

				// piece knows its location
				var piece = Prefabs.CreateRandomPiece (c,r);

				// position within scene
				piece.gameObject.transform.localPosition = new Vector2(x, y);
				piece.gameObject.transform.parent = transform;

				// position within grid
				grid[c,r] = piece;
				++c;
			}
			c = 0;
			++r;
		};
	}

	public Piece CellAtXY(Vector2 c) {
		return inRange((int)c.x,(int)c.y) ? grid[(int)c.x,(int)c.y] : null;
	}

	public bool inRange(int x, int y) {
		return  x >= 0 && x < columns && y >= 0 && y < rows;
	}

	public void dropRows() {
		dropRow (0);
	}

	private void dropRow(int column) {

		Debug.Log ("dropping");

		// figure out lowest empty cell in a row
		int emptyCell;
		while((emptyCell = findEmptyRowCell(column)) != -1) {
			Debug.Log ("Empty cell detected at [" + column + "," + emptyCell + "]");
			if(emptyCell == (rows - 1)) 
			{
				Debug.Log ("Spawning Color at top [" + column + "," + emptyCell + "]");
				grid[column, emptyCell] = Prefabs.CreateRandomPiece(column, emptyCell);
			} else {
				for(int y = emptyCell; y < rows; ++y) {
					Piece current = grid[column, y];
					if(current == null) continue;
					moveDownByOneY(column,y);
				}
			}
		}
	}

	public int findEmptyColumnCell(int row) {
		for(int x = 0; x < columns; ++x) {
			if(grid[x,row] == null) {
				return x;
			}
		}
		return -1;
	}
	
	public int findEmptyRowCell(int column) {
		for(int y = rows - 1; y >= 0; --y) {
			if(grid[column,y] == null) {
				return y;
			}
		}
		return -1;
	}

	public void moveDownByOneY(int x, int y) {

		Debug.Log ("Dropping down from [" + x + "," + y + "] to [" + x + "," + (y-1) + "]");

		Piece current = grid [x, y];

		// displayed position
		current.transform.position = new Vector3(current.transform.position.x, y  * (1 + spacing) - (1 + spacing) , 0);

		// within grid
		if (y > 0) {
			if(grid[x, y - 1] != null) {
				Debug.Log ("Can't drop down one tile, somethin's there");
				return;
			}
			grid[x, y - 1] = current;
			grid[x, y] = null;
			Debug.Log("Changing grid from [" + x + "," + y + "] to [" + x + "," + (y-1) + "]");
		}
	}

	public void printGrid() {
		for (int y = 0; y < columns; ++y) {
			string log = "";
			for (int x = 0; x < rows; ++x) {
				log += " " + grid[x,y].type + "["+x+","+y+"]";
			}
			Debug.Log ("[" + log + "]");
		}
	}
	
	void Update () {
	
	}
}
