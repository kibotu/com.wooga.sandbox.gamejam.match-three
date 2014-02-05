using UnityEngine;
using System.Collections;

public class RotateTowardsMouse : MonoBehaviour {

	void Update () {

		Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
		transform.LookAt(MouseWorldPosition);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
	}
}