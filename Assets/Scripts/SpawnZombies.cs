using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class SpawnZombies : MonoBehaviour {

	public GameObject zombiePrefab, pointPrefab;
	public int zombieNumber = 25;
	public int pointNumber = 100;
	private int pointCount = 0;
	private Transform[] zPoints;
	private static int zombiesSpawned = 0;
	private Terrain terrain;
	private float terr_x, terr_z;
	private Transform hero;
	private Text txtSpeed;
	public float pt_ceiling = 20f, pt_floor = 0f;

	void Start () {
		PopulatePoints();
		FindPoints();
		for (int i = 0; i < zombieNumber; i++) {
			SpawnZombie();
		}
		// *** following for use only with Update()
		hero = GameObject.FindWithTag("Player").transform;
		txtSpeed = GameObject.Find("SpeedText").GetComponent<Text>();
	}

	void Update() {
		//txtSpeed.text = terrain.terrainData.GetHeight((int)hero.position.x, (int)hero.position.z).ToString();
		txtSpeed.text = terrain.SampleHeight(hero.position).ToString();
	}

	void PopulatePoints() {
		GameObject point, zPointsParent;
		float pt_x, pt_y, pt_z, trpos_x, trpos_y, trpos_z;
		terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
		zPointsParent = GameObject.Find("ZPoints");
		Debug.Log("X=" + terrain.terrainData.size.x + " Y=" + terrain.terrainData.size.y + " Z=" + terrain.terrainData.size.z);
		terr_x = terrain.terrainData.size.x;
		terr_z = terrain.terrainData.size.z;
		trpos_x = terrain.transform.position.x;
		trpos_y = terrain.transform.position.y;
		trpos_z = terrain.transform.position.z;
		pt_floor += trpos_y;   //update for height of terrain tranform
		pt_ceiling += trpos_y;
		for (int i = 0; i < pointNumber; i++) {
			do {
				pt_x = Random.Range(trpos_x, terr_x + trpos_x);
				pt_z = Random.Range(trpos_z, terr_z + trpos_z);
				pt_y = terrain.SampleHeight(new Vector3(pt_x, 0, pt_z)) + 0.4f + trpos_y;
			} while (CheckOnNavmesh(new Vector3(pt_x, pt_y, pt_z)) == false);
			point = Instantiate(pointPrefab, new Vector3(pt_x, pt_y, pt_z), Quaternion.identity) as GameObject;
			point.name = "Point " + i;
			point.transform.parent = zPointsParent.transform;
		}
	}

	bool CheckOnNavmesh(Vector3 checkPoint) {
		if (checkPoint.y < pt_floor) 
			{ return false; }
		if (checkPoint.y > pt_ceiling) 
			{ return false; }
		NavMeshHit hit;
		if (NavMesh.SamplePosition(checkPoint, out hit, 1.0f, NavMesh.AllAreas)) 
			{ return true; }
		return false; 
	}

	void SpawnZombie() {
		GameObject go, point;
		point = GetPoint();
		go = Instantiate(zombiePrefab, point.transform.position, Quaternion.identity) as GameObject;
		go.name = "Zombie " + zombiesSpawned;
		zombiesSpawned++;
		SetPoint (go);
	}

	public void SetPoint (GameObject zombie) {
		zombie.GetComponent<AICharacterControl> ().target = GetPoint ().transform;
	}

	public void SetPoint (GameObject zombie, GameObject player) {
		zombie.GetComponent<AICharacterControl> ().target = player.transform;
	}

	void FindPoints() {
		Transform g = GameObject.Find("ZPoints").transform;
		pointCount = g.childCount;
		zPoints = new Transform[pointCount];
		int i = 0;
		foreach (Transform p in g) {
			zPoints[i] = p;
			i++;
		}

	}

	private GameObject GetPoint() {
		int i = Random.Range(0, pointCount);
		return zPoints[i].gameObject;
	}
}
