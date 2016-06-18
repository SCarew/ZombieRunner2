using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private int hitPoints = 100;
	private Animator anim;

	private void Start() {
		anim = GetComponent<Animator>();
	}

	public void TakeDamage (int damage) {
		hitPoints -= damage;
		if (hitPoints <= 0) {
			hitPoints = 0;
			Die();
		}
	}

	private void Die() {
		Debug.Log(transform.name + " killed");
		anim.SetFloat("Status", 17f);
		Invoke("Resurrect", 3f);
	}

	private void Resurrect() {
		hitPoints = 100;
		anim.SetFloat("Status", 0f);
	}
}
