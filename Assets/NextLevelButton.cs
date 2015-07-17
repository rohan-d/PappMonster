using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelButton : MonoBehaviour {

	public void NLButton(int index) {
		Application.LoadLevel(index);
	}

	public void NLButton(string levelName) {
		Application.LoadLevel (levelName);
	}

}
