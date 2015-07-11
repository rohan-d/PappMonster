using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 4f;
	public GameObject CameraObjct;

	Vector3 movement;
//	Animator anim;
	Rigidbody playerRigidbody;

	void Awake()
	{
//		Animator = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}

	void FixedUpdate()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Move (horizontal, vertical);
//		Animating (horizontal, vertical);
	}

	void Move (float horizontal, float vertical)
	{
		movement.Set (horizontal, 0f, vertical);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (transform.localPosition + movement);
	}
	

//	void Animating(float horizontal, float vertical)
//	{
//		bool walking = horizontal != 0f || vertical != 0f;
//		anim.SetBool ("IsWalking", walking);
//	}

}
