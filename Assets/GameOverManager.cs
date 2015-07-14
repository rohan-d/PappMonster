using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
	Animator anim;
	private bool restart;
	public GameObject shootingScript;

	void Awake () {

		anim = GetComponent <Animator> ();
		restart = false;

	}

	void Update () {

		if(Timer.timeRemaining <= 0) {

			anim.SetTrigger ("GameOver");
			shootingScript.GetComponent<PlayerShooting>().enabled = false;
			restart = true;

			if(restart) {
				if (Input.GetKeyDown (KeyCode.R)) {
					shootingScript.GetComponent<PlayerShooting>().enabled = true;
					Timer.timeRemaining = 51;
					Application.LoadLevel(Application.loadedLevel);
				}
			}
		}
	}
}	