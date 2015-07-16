using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public static int timeRemaining = 51;
	Animator anim;
	Text text;
	
	void Awake () {
		text = GetComponent <Text> ();
		InvokeRepeating ("decreaseTimeRemaining", 0, 1);
	}

	void Update () {

		if (timeRemaining > -1) {
			text.text = "" + timeRemaining;
		}
	}

	void decreaseTimeRemaining() {
		timeRemaining --;
		if (timeRemaining <= 0) {
			CancelInvoke();
		}
	}
}
