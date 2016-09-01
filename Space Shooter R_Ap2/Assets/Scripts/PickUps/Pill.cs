using UnityEngine;
using System.Collections;

public class Pill : MonoBehaviour {

	public float maxSpeed;
	public float speedBonus;

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			PlayerController playerController =  other.gameObject.GetComponent<PlayerController> ();
			if (playerController.powerUp.fireRate >= maxSpeed + speedBonus) {
				playerController.powerUp.fireRate -= speedBonus;
			} else {
				playerController.powerUp.fireRate = maxSpeed;
			}
		}
	}
}
