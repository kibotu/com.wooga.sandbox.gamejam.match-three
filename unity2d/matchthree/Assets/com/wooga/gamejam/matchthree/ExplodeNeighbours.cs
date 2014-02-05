using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodeNeighbours : MonoBehaviour {

	public static List<GameObject> neighbours;

	void Start() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.7f);
		
		TileMetaData _thisMeta = GetComponent<TileMetaData> ();

		foreach (Collider coll in hitColliders) {

			//if(coll.gameObject == gameObject) continue;
			TileMetaData _otherMeta = coll.gameObject.GetComponent<TileMetaData> ();
		
			//if(name == coll.name) { // ok why this is not working is curious o.o
				Debug.Log (name + " (" + _thisMeta.index + ") has been hit by " + coll.name + "(" + _otherMeta.index + ")");

				renderer.material.color = Color.black; // color this
				coll.renderer.material.color = Color.black; // color all neighbours
			//}
		}
	} 
}