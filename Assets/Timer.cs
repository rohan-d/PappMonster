using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public static int timeRemaining = 30;
	Animator anim;
	Text text;
	
	void Start () {
		text = GetComponent <Text> ();
		InvokeRepeating ("decreaseTimeRemaining", 0, 1);
	}

	void Update () {

		if (timeRemaining > -1) {
			text.text = "" + timeRemaining;
		}
//		if (timeRemaining == 0) {
//			anim.SetTrigger ("GameOver");
//		}
//		text.text = "" + timeRemaining;
	}

	void decreaseTimeRemaining() {
		timeRemaining --;
		if (timeRemaining <= 0) {
			CancelInvoke();
		}
	}
}
