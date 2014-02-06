using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloodFill
{
    private List<Piece> _floodFill;
    private Grid _board;

	public List<Piece> FillFromPiece(Piece piece, Grid board)
    {
		_floodFill = new List<Piece>();
        _floodFill.Add(piece);

		//Debug.Log("Find Neighbours to [" + pieceMeta.x + "," + pieceMeta.y + "] " + pieceMeta.type + " " + pieceMeta.name);
		
        _board = board;
        FloodFillRecursively(piece);
        return _floodFill;
    }

    void FloodFillRecursively(Piece piece)
    {
		//Debug.Log ("Checking " + piece.name + " " + pieceMeta.ToString());

		foreach(Vector2 coordinate in SurroundingCoordinates(piece.x, piece.y))
        {
            if (_board.CellAtXY(coordinate) != null)
            {
				Piece nextPiece = _board.CellAtXY(coordinate);
			//	Debug.Log("Neighbours has same type ? [" + nextPieceMeta.x + "," + nextPieceMeta.y + "] " + nextPieceMeta.type + " " + nextPieceMeta.name);
				if (piece.type == nextPiece.type && !_floodFill.Contains(nextPiece))
                {
				//	Debug.Log ("Adding this");
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
