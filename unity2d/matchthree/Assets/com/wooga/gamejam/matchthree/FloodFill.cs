using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloodFill
{
    private List<GameObject> _floodFill;
    private Grid _board;

	public List<GameObject> FillFromPiece(GameObject piece, Grid board)
    {
		_floodFill = new List<GameObject>();
        _floodFill.Add(piece);

		TileMetaData pieceMeta = piece.GetComponent<TileMetaData> ();
		Debug.Log("Find Neighbours to [" + pieceMeta.x + "," + pieceMeta.y + "] " + pieceMeta.type + " " + pieceMeta.name);
		
        _board = board;
        FloodFillRecursively(piece);
        return _floodFill;
    }

    void FloodFillRecursively(GameObject piece)
    {
		TileMetaData pieceMeta = piece.GetComponent<TileMetaData> ();
		Debug.Log ("Checking " + piece.name + " " + pieceMeta.ToString());

		foreach(Vector2 coordinate in SurroundingCoordinates(pieceMeta.x, pieceMeta.y))
        {

			Debug.Log ("coords: " + coordinate + " exist in grid? " + _board.CellAtXY(coordinate) == null);

            if (_board.CellAtXY(coordinate) != null)
            {
				GameObject nextPiece = _board.CellAtXY(coordinate);
				TileMetaData nextPieceMeta = nextPiece.GetComponent<TileMetaData>();
				Debug.Log("Neighbours has same type ? [" + nextPieceMeta.x + "," + nextPieceMeta.y + "] " + nextPieceMeta.type + " " + nextPieceMeta.name);
				if (pieceMeta.type == nextPieceMeta.type && !_floodFill.Contains(nextPiece))
                {
					Debug.Log ("Adding this");
                    _floodFill.Add(nextPiece);
                    FloodFillRecursively(nextPiece);
                }
            }
        }
    }

    Vector2[] SurroundingCoordinates(int x, int y)
    {
        Vector2 left    = new Vector2(x - 1, y);
        Vector2 right   = new Vector2(x + 1, y);
        Vector2 top     = new Vector2(x, y + 1);
        Vector2 bottom  = new Vector2(x, y - 1);
        return new Vector2[] {left, right, top, bottom};
    }
}
