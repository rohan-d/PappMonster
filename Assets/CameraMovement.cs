using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject target;
	Vector3 offset;

	void Start () {
		offset = target.transform.position - transform.position;
	}
	
	void Update () {
//		float horizontal = Input.GetAxis ("Mouse X");
//		target.transform.Rotate (0, horizontal, 0);
		GetComponent<MouseLook> ();
//
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
//
//		transform.LookAt(target.transform);
	}
}
