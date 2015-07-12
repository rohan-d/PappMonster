﻿using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.2f;
	public float range = 100f;

	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	AudioSource gunAudio;
	//int shootableMask;
	LineRenderer gunLine;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	
	void Awake () {

		//shootableMask = LayerMask.GetMask ("Shootable");

		gunLine = GetComponent <LineRenderer> ();
		gunLight = GetComponent <Light> ();
		gunAudio = GetComponent<AudioSource> ();

		Screen.lockCursor = false;
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

		if (Physics.Raycast (shootRay, out shootHit, range/*, shootableMask*/)) {

			EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

			if (enemyHealth != null) {
				enemyHealth.TakeDamage (damagePerShot, shootHit.point);
//				print ("enemy shot");
			}
			gunLine.SetPosition (1, shootHit.point);
		}

		else {
//			print ("shoot else");
			gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
		}
	}
}
