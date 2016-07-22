using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public Vector3 spawnPosition=Vector3.zero;
	private Quaternion spawnRotation;

	void SpawnWaves() {
		spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
		spawnPosition.z = spawnValues.z;
		spawnRotation = Quaternion.identity;
		Instantiate(hazard, spawnPosition, spawnRotation);
	}

	// Use this for initialization
	void Start () {
		SpawnWaves();	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
