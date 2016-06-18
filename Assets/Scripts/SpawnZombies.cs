using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class SpawnZombies : MonoBehaviour {

	public GameObject zombiePrefab;
	public int zombieNumber = 25;
	private int pointCount = 0;
	private Transform[] zPoints;
	private static int zombiesSpawned = 0;
	private Terrain terrain;

	void Start () {
		PopulatePoints();
		FindPoints();
		for (int i = 0; i < zombieNumber; i++) {
			SpawnZombie();
		}
	}

	void PopulatePoints() {
		terrain = GameObject.Find("Terrain").GetComponent<Terrain>();
		Debug.Log("X=" + terrain.terrainData.size.x + " Y=" + terrain.terrainData.size.y + " Z=" + terrain.terrainData.size.z);
		float x = terrain.terrainData.size.x;
		float z = terrain.terrainData.size.z;
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
