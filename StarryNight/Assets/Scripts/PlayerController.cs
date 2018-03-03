using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float xMin, xMax, yMin, yMax;
	public int scoreValue;
	private GameController gameController;

	void Start() {
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

	void Update()
	{
		//tilt to move ship
		transform.Translate(Input.acceleration.x * speed, 0, 0);

		//create boundries
		transform.position = new Vector2(
			Mathf.Clamp(transform.position.x, xMin, xMax), 
			Mathf.Clamp(transform.position.y, yMin, yMax)
		);
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
		if (other.gameObject.CompareTag("Star"))
		{
			Destroy (other.gameObject);
			gameController.AddScore (scoreValue);
		}
	}
}
