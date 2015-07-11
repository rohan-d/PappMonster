using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	
	public float XSensitivity = 2f;
	public float YSensitivity = 5f;

	public float MinimumX = -360f;
	public float MaximumX = 360f;
	public float MinimumY = -90f;
	public float MaximumY = 90;

	float RotX = 0f;
	float RotY = 0f;
	Quaternion originalRotation;

	void Update() {
		if (axes == RotationAxes.MouseXAndY) {
			RotX += Input.GetAxis("Mouse X") * XSensitivity;
			RotY += Input.GetAxis("Mouse Y") * YSensitivity;

			RotX = Mathf.Clamp (RotX, MinimumX, MaximumX);
			RotY = Mathf.Clamp (RotY, MinimumY, MaximumY);

			Quaternion xQuaternion = Quaternion.AngleAxis (RotX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (-RotY, Vector3.right);

			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}

		else if (axes == RotationAxes.MouseX) {
			RotX += Input.GetAxis("Mouse X") * XSensitivity;
			RotX = Mathf.Clamp (RotX, MinimumX, MaximumX);

			Quaternion xQuaternion = Quaternion.AngleAxis (RotX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		}

		else {
			RotY += Input.GetAxis("Mouse Y") * YSensitivity;
			RotY = Mathf.Clamp (RotY, MinimumY, MaximumY);

			Quaternion yQuaternion = Quaternion.AngleAxis (-RotY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}
	}
	
	void Start () {
		if (GetComponent<Rigidbody> ())
			GetComponent<Rigidbody>().freezeRotation = true;
			originalRotation = transform.localRotation;
	}

}

