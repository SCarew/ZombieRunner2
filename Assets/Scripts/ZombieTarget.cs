using UnityEngine;
using System.Collections;

public class ZombieTarget : MonoBehaviour {

	private float fTimer = 0f;
	private SpawnZombies sz;

	void Start () {
		sz = GameObject.Find("ZombieManager").GetComponent<SpawnZombies>();	
	}

	public bool IsReady() {
		if (fTimer > 0) 
			{ return false; }
		fTimer = Random.Range(2f, 7f);
		return true;
	}

	void Update() {
		if (fTimer > 0) {
			fTimer -= Time.deltaTime;
		}
	}

	public void SetNewTarget () {
		//a random point
		sz.SetPoint(gameObject);
		Debug.Log(gameObject.name + " setting new target");
	}

	public void SetPlayerTarget(GameObject obj) {
		//the player object
		sz.SetPoint(gameObject, obj);
		Debug.Log(gameObject.name + " setting new target to " + obj.name);
	}
}
