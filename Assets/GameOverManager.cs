using UnityEngine;

public class GameOverManager : MonoBehaviour
{

	public float restartDelay = 600;
	float restartTimer = 0; 
	Animator anim;                         
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
	}

	void Update ()
	{

		if(Timer.timeRemaining <= 0) {

			anim.SetTrigger ("GameOver");
			restartTimer ++;

			if(restartTimer >= restartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}	