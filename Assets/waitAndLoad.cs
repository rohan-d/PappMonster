using UnityEngine;
using System.Collections;

public class waitAndLoad : MonoBehaviour {

	public int loadingTime = 10;
	public string levelName;

	void Awake () {
		InvokeRepeating ("decreaseLoadingTime", 0, 1);
	}

	void Update () {
//		if (loadingTime > -1) {
//		}
	}

	void decreaseLoadingTime() {
		loadingTime --;
		if (loadingTime <= 0) {
			CancelInvoke ();
			Application.LoadLevel(levelName);
		}
	}
}
