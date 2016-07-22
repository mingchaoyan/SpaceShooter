using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject go = GameObject.FindWithTag("GameController");
		if(go != null) {
			gameController = go.GetComponent<GameController>();
		} else {
			Debug.LogError("Can not find GameObject with tag GameController");
		}

		if(gameController == null)
			Debug.LogError("Can not find Script GameController");
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Boundary") {
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);
		gameController.AddScore(scoreValue);
		if(other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
