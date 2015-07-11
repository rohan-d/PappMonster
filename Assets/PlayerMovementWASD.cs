using UnityEngine;
using System.Collections;

public class PlayerMovementWASD : MonoBehaviour {

	Rigidbody playerRigidbody;
	public float playerSpeed = 5f;

	void Awake() {
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void FixedUpdate() {
		playerRigidbody.transform.Translate(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed);
		playerRigidbody.transform.Translate(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed, Space.World);
	}
}
