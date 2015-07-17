using UnityEngine;
using System.Collections;

public class anyKey : MonoBehaviour {

	public string start;

	void Update () {
	if (Input.anyKeyDown) {
			Application.LoadLevel(start);
		}
	}
}
