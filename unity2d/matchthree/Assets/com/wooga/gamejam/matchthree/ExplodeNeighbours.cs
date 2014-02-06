using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodeNeighbours : MonoBehaviour {

	public List<GameObject> Neighbours;

	void Start() {

        Debug.Log("Checking Neighbours to " + gameObject.GetInstanceID());

        // add neighbours only once
        if (Neighbours.Contains(gameObject)) return;

		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 0.7f);
		
		TileMetaData _thisMeta = GetComponent<TileMetaData> ();

		foreach (Collider coll in hitColliders) {

            if (gameObject == coll.gameObject) continue;

            // add neighbours only once
            if (Neighbours.Contains(coll.gameObject)) continue;

			TileMetaData _otherMeta = coll.gameObject.GetComponent<TileMetaData> ();

		    if (_thisMeta.type == _otherMeta.type)
		    {
                Debug.Log(name + " (" + _thisMeta.index + " | " + _thisMeta.type + ") has been hit by " + coll.name + "(" + _otherMeta.index + " | " + _otherMeta.type + ")");
                
              //  renderer.material.color = Color.black; // color this
                //coll.renderer.material.color = Color.black; // color all neighbours

                // collect neighbours with same color
                if(Neighbours.Contains(coll.gameObject)) Neighbours.Add(coll.gameObject); 

                // chain neighbours
		        //coll.gameObject.AddComponent<ExplodeNeighbours>().Neighbours = Neighbours;
                
                Destroy(this);
		    }
		}
	} 
}