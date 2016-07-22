using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public Vector3 spawnPosition=Vector3.zero;
	private Quaternion spawnRotation;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;
	public Text scoreText;
	private int score;
	public Text gameOverText;
	public bool gameOver;
	public Text restartText;
	public bool restart;

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore() {
		scoreText.text = "得分:" + score;
	}


	IEnumerator	SpawnWaves() {

		yield return new WaitForSeconds(startWait);
		while (true) {
			for (int i = 0; i < hazardCount; ++i) {
				spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
				spawnPosition.z = spawnValues.z;
				spawnRotation = Quaternion.identity;
				Instantiate(hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			if(gameOver) {
				restartText.text = "按下R重新开始";
				restart = true;
				break;
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

	public void GameOver() {
		gameOver = true;
		gameOverText.text = "游戏结束";
	}

	// Use this for initialization
	void Start () {
		gameOverText.text = "";
		gameOver = false;
		restartText.text = "";
		restart = false;
		StartCoroutine(SpawnWaves());
	}

	void Update() {
		if(restart) {
			if(Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene(0);
			}
		}

	}
	
}
