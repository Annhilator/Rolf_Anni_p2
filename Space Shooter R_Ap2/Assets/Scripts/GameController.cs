﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public GameObject[] pickUps;

	public Vector3 spawnValues;
	public float hazardSpeed;
	public int hazardCount;
	public float hazardSpeedModifier;
	public float maxHazardSpeed;
	public float maxHazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	private int score;
	private int nextPickUp;
	private int pickUpCounter;

	private bool gameOver;
	private bool restart;

	private GameObject startScreen;

	void Start() {
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "Asteroids incoming Captain!";
		scoreText.text = "";
		score = 0;
		pickUpCounter = 0;
		nextPickUp = Random.Range (5, 20);
		StartCoroutine (SpawnWaves ());
	}

	void Update() {
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("Menu");
			}
		}

		if (score <= -150) {
			GameOver ();
		}
	}

	IEnumerator SpawnWaves() {
		startScreen = GameObject.FindGameObjectWithTag ("StartScreen");
		yield return new WaitForSeconds (startScreen.GetComponent<DestroyByTime> ().lifeTime);
		UpdateScore ();
		gameOverText.text = "";
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				pickUpCounter++;
				if (pickUpCounter == nextPickUp) {
					GameObject pickUp = pickUps [Random.Range(0, pickUps.Length)];
					Vector3 spawnPositionPickUp = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
					Quaternion spawnRotationPickUp = Quaternion.identity;
					Instantiate (pickUp, spawnPositionPickUp, spawnRotationPickUp);
					nextPickUp = Random.Range (5, 20);
					pickUpCounter = 0;
					yield return new WaitForSeconds (0.25f);
				}
				GameObject hazard = hazards [Random.Range(0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				GameObject spawnedHazard = Instantiate (hazard, spawnPosition, spawnRotation) as GameObject;
				spawnedHazard.GetComponent<Mover> ().speed = -hazardSpeed;
				yield return new WaitForSeconds (spawnWait);
			}
			if (hazardSpeed + hazardSpeedModifier < maxHazardSpeed) {
				hazardSpeed += hazardSpeedModifier;
			} else {
				hazardSpeed = maxHazardSpeed;
			}
			yield return new WaitForSeconds (waveWait);

			if (hazardCount <= maxHazardCount) {
				hazardCount += 1;
			}

			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
		
	public void AddScore (int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	public static GameController FindGameController() {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			return gameControllerObject.GetComponent <GameController> ();
		}

		if (gameControllerObject == null) {
			Debug.Log ("Cannot find GameController script");
		}
		return null;
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
