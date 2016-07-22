using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public Vector3 spawnPosition=Vector3.zero;
	private Quaternion spawnRotation;
	public int hazardCount;
	public float startWait;
	public float spawnWait;
	public float waveWait;

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
			yield return new WaitForSeconds(waveWait);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnWaves());
	}
	
}
