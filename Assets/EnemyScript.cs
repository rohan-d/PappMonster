using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	EnemyHealth enemyHealth;

	void Awake () {
		enemyHealth = GetComponent <EnemyHealth> (); 
	}
}
