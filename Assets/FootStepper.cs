using UnityEngine;
using System.Collections;

public class FootStepper : MonoBehaviour {
	
	public AudioSource steps;
	
	void Start () {
		steps.GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (Input.GetButton ("Horizontal") || Input.GetButton ("Vertical")) {
			if (!steps.isPlaying) {
				steps.pitch = Random.Range (1.0f, 1.5f);
				steps.Play ();
			}
		}
	}
}