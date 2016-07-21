using UnityEngine;
using System.Collections;

public class BoltMove : MonoBehaviour {
	public float speed =40.0f;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	
	}
}
