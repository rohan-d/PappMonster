using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.2f;
	public float range = 25f;
//	Animator scoreAnimation;
//	bool score = false;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	AudioSource gunAudio;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	
	void Awake () {

		gunLine = GetComponent <LineRenderer> ();
		gunLight = GetComponent <Light> ();
		gunAudio = GetComponent<AudioSource> ();
//		scoreAnimation = GetComponent <Animator> ();

		Screen.lockCursor = true;
	}

	void Update () {

		timer += Time.deltaTime;

		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
			Shoot ();
		}

		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			DisableEffects ();
		}
	}

	public void DisableEffects () {
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot () {

		timer = 0f;
		gunAudio.Play ();
		gunLight.enabled = true;
		gunLine.enabled = true;
		gunLine.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast (shootRay, out shootHit, range)) {

			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
//				score = true;
//				if (score) {
//					scoreAnimation.SetTrigger ("Score");
//					score = false;
//				}
			}
			gunLine.SetPosition (1, shootHit.point);
		}

		else {
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
