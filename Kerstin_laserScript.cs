using UnityEngine;
using System.Collections;

public class laserScript : MonoBehaviour {

	LineRenderer Line;
	//public float range = 100f;
	public float hitForce = 20f;
	public GameObject projectile;
	public float velocity;

	void Start() {
		//Line = gameObject.GetComponent<LineRenderer>();
		//Line.enabled = false;
		Cursor.visible = false;
	}


	void Update() {
		if (Input.GetButtonDown("Fire1")) {
			shoot ();
			//StopCoroutine("FireLaser");
			//StartCoroutine("FireLaser");
		}
	}
	/*
	IEnumerator FireLaser() {
		Line.enabled = true;
		while (Input.GetButton("Fire1")) {

			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;

			Line.SetPosition(0, ray.origin);

			if (Physics.Raycast(ray, out hit, range))
				Line.SetPosition(1, hit.point);
			if (hit.rigidbody){
				hit.rigidbody.AddForceAtPosition(transform.forward * hitForce, hit.point);
			}
			else
				Line.SetPosition(1, ray.GetPoint(range));


			yield return null;
		}
		Line.enabled = false;
	}*/


	void shoot() {
		GameObject throwthis;
		Vector3 direction = transform.forward;
		direction.x *= velocity;
		direction.y *= velocity;
		direction.z *= velocity;
		throwthis = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject;
		throwthis.GetComponent<Rigidbody>().AddRelativeForce(direction); 
	}
	

}
