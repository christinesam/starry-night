using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject star;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	public GUIText lifeText;
	private int life;

	public GUIText gameOverText;
	private bool gameOver;

	public GUIText restartText;
	private bool restart;

	void Start ()
	{
		gameOver = false;
		restart = false;
		StartCoroutine (SpawnWaves ());
		score = 0;
		life = 3;
		scoreText.text = "Score: " + score;
		lifeText.text = "FFF";
		gameOverText.text = "";
		restartText.text = "";
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	void Update() {
		if (restart)
		{
			if (Input.touchCount >= 1)
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (star, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);

				if (gameOver)
				{
					restartText.text = "Tap to restart";
					restart = true;
					break;
				}
			}
			if (gameOver)
			{
				break;
			}
			if (spawnWait > 0.05f) {
				spawnWait = spawnWait - 0.05f;
			}
			yield return new WaitForSeconds (waveWait);

		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}

	public void RemoveLife () {
		
		switch (life) {
		case 1:
			lifeText.text = "";
			life--;
			GameOver ();
			break;
		case 2: 
			lifeText.text = "F";
			life--;
			break;
		case 3:
			lifeText.text = "FF";
			life--;
			break;
		default:
			return;
		}
	}

	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
