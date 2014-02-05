using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public int colums = 9;
	public int rows = 7;
	public float spacing = 0.1f;

	public void CreateGrid (int colums, int rows, float spacing = 0.1f) {

		var mat =  Resources.Load("Materials/grid_mat", typeof(Material)) as Material;
		float y = 0;
		float x = 0;
		int tagId = 0;
		for ( y = 0; y < colums; y+=1+spacing) {
			for(x = 0; x < rows; x+=1+spacing) {
				var tile = GameObject.CreatePrimitive(PrimitiveType.Quad);
				tile.renderer.material = mat;
				tile.transform.localPosition = new Vector2(x, y);
				tile.transform.parent = transform;
			}
		};
		transform.position = new Vector3 (-x/2 + (1+spacing)/2, -y/2+ (1+spacing)/2, 0);
	}
	
	void Update () {
	
	}
}
