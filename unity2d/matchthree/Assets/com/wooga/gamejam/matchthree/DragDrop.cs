using UnityEngine;
using System.Collections;

public class DragDrop : MonoBehaviour {

	private SwipeRecognizer swipeRecognizer;

	void Start () {
		gameObject.AddComponent<DragRecognizer> ().OnGesture += OnDragDrop;
		gameObject.AddComponent<ScreenRaycaster> ();
	}
	
	void Update () {

	}

	void OnDragDrop(DragGesture gesture) {
		Vector3 newPos = Camera.main.ScreenToWorldPoint (gesture.TotalMove);
		newPos.z = -5f;
		newPos.y += 5f;
		transform.position = newPos;
		
		Debug.Log (Camera.main.ScreenToWorldPoint (gesture.TotalMove));
	}
}
