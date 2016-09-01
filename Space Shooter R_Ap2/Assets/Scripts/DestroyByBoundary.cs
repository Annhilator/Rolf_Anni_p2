using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	public int hazardPenalty;

	void OnTriggerExit(Collider other) {
		
		if (other.CompareTag ("Hazard")) {
			GameController.FindGameController ().AddScore (-hazardPenalty);
		}

		if (other.name == "Enemy Ship(Clone)") {
			GameController.FindGameController ().AddScore (-hazardPenalty);
		}

		Destroy(other.gameObject);
	}
}
