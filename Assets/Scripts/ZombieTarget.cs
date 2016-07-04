using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZombieTarget : MonoBehaviour {

	private float fTimer = 0f;
	private SpawnZombies sz;	 
	private float waitTime = 3f;
	private NavMeshAgent nav; //temporary

	void Start () {
		nav = GetComponent<NavMeshAgent>();  // ***
		sz = GameObject.Find("ZombieManager").GetComponent<SpawnZombies>();	
		StartCoroutine("CheckTarget");
	}

	IEnumerator CheckTarget() {
		for (;;) {   //infinite loop
			if (Vector3.Distance(gameObject.transform.position, sz.GetPoint(gameObject).position) < 1.5f) {
				SetNewTarget(false);
			}
			yield return new WaitForSeconds(waitTime);
		}
	}

	private bool IsReady() {
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

	IEnumerator PauseSecond() {  //temporary
		yield return new WaitForSeconds(1f);
	}

	public void SetNewTarget (bool useTimer = true) {
		//a random point
		if (!useTimer || IsReady()) {
			//sz.SetPoint(gameObject);
			Transform dest = sz.ReturnPoint().transform;
			gameObject.GetComponent<NavMeshAgent> ().ResetPath();
			gameObject.GetComponent<AICharacterControl> ().SetTarget(dest);

			StartCoroutine(PauseSecond()); // ***
			Debug.Log(gameObject.name + " setting new target to " + sz.GetPoint(gameObject).name + "->" + nav.destination.ToString() +
				" -> " + gameObject.GetComponent<NavMeshAgent>().destination.ToString());
		}
	}

	public void SetPlayerTarget(GameObject obj) {
		//the player object
		if (IsReady()) {
			//sz.SetPoint(gameObject, obj);
			gameObject.GetComponent<NavMeshAgent> ().ResetPath();
			gameObject.GetComponent<AICharacterControl> ().SetTarget(obj.transform);

			StartCoroutine(PauseSecond()); // ***
			Debug.Log(gameObject.name + " setting new target to " + obj.name + "->" + nav.destination.ToString() +
				" -> " + gameObject.GetComponent<NavMeshAgent>().destination.ToString());
		}
	}
}
