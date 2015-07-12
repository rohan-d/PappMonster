using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int StartingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 100;
	CapsuleCollider capsuleCollider;
	bool isDead;
	bool isSinking;

	void Awake () {
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
//	 		print ("Damage Taken");

		if(currentHealth <= 0) {
			Death ();
//			print ("dead");
		}
	}

	void Death () {

		isDead = true;
		capsuleCollider.isTrigger = true;
		StartSinking ();
	}

	public void StartSinking () {
		GetComponent <Rigidbody> ().isKinematic = true;
		isSinking = true;
		ScoreManager.score += scoreValue;
		Destroy (gameObject, 2f);
		print ("sink");
	}
}
	
