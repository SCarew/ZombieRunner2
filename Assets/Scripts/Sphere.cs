using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {

	private bool isInnerZone;
	private ZombieTarget zt;

	void Start() {
		if (gameObject.name == "InnerZone") {
			isInnerZone = true;
		} else {
			isInnerZone = false;
		}
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log("Triggered " + col.name);
		if (col.tag != "Zombie") 
			{ return; }
		if (isInnerZone) {
			zt = col.GetComponent<ZombieTarget>();
			if (zt.IsReady()) {
				zt.SetPlayerTarget(gameObject.transform.parent.gameObject);
			}
			//set zombie's target to player
		} 
	}

	void OnTriggerExit(Collider col) {
		if (col.tag != "Zombie")
			{ return; }
		if (!isInnerZone) {
			zt = col.GetComponent<ZombieTarget>();
			if (zt.IsReady()) {
				zt.SetNewTarget();
			}
			//set zombie's target to random point
		}
	}

}
