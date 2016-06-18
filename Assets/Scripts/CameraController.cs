using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float movement = 5f;
	public float updown = 1f;
	private Vector3 pos;
	private Quaternion rot;
	private Transform camTrans;
	private RaycastHit hit;
	private float range = 2000f;

	void Start () {
		camTrans = GetComponentInChildren<Camera>().GetComponent<Transform>();
	}
	
	void Update () {
		pos = transform.position;
		rot = transform.rotation;

		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) {
			FireGun();
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position = new Vector3(pos.x, pos.y, pos.z - movement);
		}	
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position = new Vector3(pos.x, pos.y, pos.z + movement);
		}	
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position = new Vector3(pos.x + movement, pos.y, pos.z);
		}	
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position = new Vector3(pos.x - movement, pos.y, pos.z);
		}
		if (Input.GetKey(KeyCode.PageUp)) {
			transform.eulerAngles = new Vector3(rot.eulerAngles.x - updown, rot.eulerAngles.y, rot.eulerAngles.z);
		}
		if (Input.GetKey(KeyCode.PageDown)) {
			transform.eulerAngles = new Vector3(rot.eulerAngles.x + updown, rot.eulerAngles.y, rot.eulerAngles.z);
		}
		if (Input.GetKeyDown(KeyCode.Home)) {
			transform.eulerAngles = new Vector3(1, 180, 0);
		}

	}

	void FireGun() {
		if (Physics.Raycast(camTrans.TransformPoint (0,0,0.5f), camTrans.forward, out hit, range)) {
			Debug.Log("Hit " + hit.collider.name);
			if (hit.transform.tag == "Player") {
				string uIdentity = hit.transform.name;
				HitTarget(uIdentity, 50); 
			}
			if (hit.collider.transform.tag == "ZombieHead") {
				string uIdentity = hit.transform.name;
				HitTarget(uIdentity, 100);
			}
			if (hit.collider.transform.tag == "Zombie") {
				string uIdentity = hit.transform.name;
				HitTarget(uIdentity, 20); 
			}
		}
	}

	void HitTarget(string id, int damage) {
		GameObject go = GameObject.Find(id);
		go.GetComponent<Health>().TakeDamage(damage);
	}
}
