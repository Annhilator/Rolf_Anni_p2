using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}
	
public class PowerUp {
	public int laserCount;
	public float speedModifier;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;
	public PowerUp powerUp;

	public GameObject shot;
	public GameObject shotLeft;
	public GameObject shotRight;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Start () {
		powerUp = new PowerUp();
		powerUp.speedModifier = 1.0f;
		powerUp.laserCount = 1;
	}

	void Update() {
		if ((Input.GetButton ("Fire1") || Input.GetButton ("Jump")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			FireLaser ();
			GetComponent<AudioSource> () .Play();
		}

	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical );
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax));

		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, -GetComponent<Rigidbody> ().velocity.x * tilt);
	}

	void FireLaser() {
		switch (powerUp.laserCount) {
		case 1:
			// 0 1 0
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			break;
		case 2:
			// 0 2 0
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			break;
		case 3: 
			// 0 3 0
			Instantiate (shot, shotSpawn.position + new Vector3(-0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			break;
		case 4:
			// 1 0 1
			Instantiate (shot, shotSpawn.position + new Vector3(-0.35f, 0.0f, 0.0f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.35f, 0.0f, 0.0f), Quaternion.Euler(0, 45, 0));
			break;
		case 5:
			// 1 1 1
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); 
			Instantiate (shot, shotSpawn.position + new Vector3(-0.35f, 0.0f, 0.0f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.35f, 0.0f, 0.0f), Quaternion.Euler(0, 45, 0));
			break;
		case 6:
			// 1 2 1
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(-0.35f, 0.0f, 0.0f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.35f, 0.0f, 0.0f), Quaternion.Euler(0, 45, 0));
			break;
		case 7:
			// 1 3 1
			Instantiate (shot, shotSpawn.position + new Vector3(-0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(-0.35f, 0.0f, 0.0f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.35f, 0.0f, 0.0f), Quaternion.Euler(0, 45, 0));
			break;
		case 8:
			// 2 0 2
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(-0.5f, -0.0f, -0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.15f), Quaternion.Euler(0, 45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.5f, 0.0f, -0.15f), Quaternion.Euler(0, 45, 0));
			break;
		case 9:
			// 2 1 2
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(-0.5f, -0.0f, -0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.15f), Quaternion.Euler(0, 45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.5f, 0.0f, -0.15f), Quaternion.Euler(0, 45, 0));
			break;
		case 10:
			// 2 2 2
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(-0.5f, -0.0f, -0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.15f), Quaternion.Euler(0, 45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.5f, 0.0f, -0.15f), Quaternion.Euler(0, 45, 0));
			break;
		default:
			// 2 3 2
			Instantiate (shot, shotSpawn.position + new Vector3(-0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(0.4f, 0.0f, 0.0f), shotSpawn.rotation);
			Instantiate (shot, shotSpawn.position + new Vector3(-0.2f, 0.0f, 0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(-0.5f, -0.0f, -0.15f),  Quaternion.Euler(0, -45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.2f, 0.0f, 0.15f), Quaternion.Euler(0, 45, 0));
			Instantiate (shot, shotSpawn.position + new Vector3(0.5f, 0.0f, -0.15f), Quaternion.Euler(0, 45, 0));
			break;
		}
	}
}
