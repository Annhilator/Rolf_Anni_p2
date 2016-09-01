using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			PlayerController playerController =  other.gameObject.GetComponent<PlayerController> ();
			playerController.powerUp.laserCount++;
		}
	}
}
