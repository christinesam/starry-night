﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

	private GameController gameController;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag("Star"))
		{
			gameController.RemoveLife ();

		}
	}
}
