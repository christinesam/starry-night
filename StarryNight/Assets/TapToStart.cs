using UnityEngine;
using System.Collections;

public class TapToStart : MonoBehaviour {

	public GUIText startText;
	// Use this for initialization
	void Start () {
		startText.text = "Tap to start";
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.touchCount >= 1)
			{
				Application.LoadLevel (1);
			}
	}
}
