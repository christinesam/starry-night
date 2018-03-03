using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = transform.up * speed;
		//rb.angularVelocity = Random.insideUnitCircle * tumble;
	}

	void Update() {
		transform.Rotate (Vector3.back);
	}
}
