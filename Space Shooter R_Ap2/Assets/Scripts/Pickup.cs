using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public AudioSource pickUpSound;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			Instantiate (pickUpSound, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
