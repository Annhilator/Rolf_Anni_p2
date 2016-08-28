using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

	public string buff;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Pickup")) {
			buff = "Red";
			Destroy (other);
		}
	}
}
