using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawnTime = 6f;
	public Transform[] spawnPoints;
	
	void Start (){
		InvokeRepeating ("Spawn", 3f, spawnTime);
	}

	void Spawn () {
	
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
	}
}
