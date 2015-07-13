using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int StartingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 3f;
	public int scoreValue = 100;
	public AudioClip deathClip;
	AudioSource enemyAudio;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;

	void Awake () {
		enemyAudio = GetComponent <AudioSource> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		currentHealth = StartingHealth;
	}

	void Update () {

		if (isSinking) {
			transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amount, Vector3 hitPoint) {

		if (isDead) {
			return;
		}

		currentHealth -= amount;
		enemyAudio.Play ();
//	 		print ("Damage Taken");

		if(currentHealth <= 0) {
			Death ();
//			print ("dead");
		}
	}

	void Death () {

		isDead = true;
		capsuleCollider.isTrigger = true;
		enemyAudio.clip = deathClip;
		enemyAudio.Play ();
		StartSinking ();
	}

	public void StartSinking () {
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		ScoreManager.score += scoreValue;	
		Destroy (gameObject, 1.2f);
//		print ("sink");
	}
}
	
