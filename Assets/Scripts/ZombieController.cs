using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	private Animator anim;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha0)) {
			anim.SetFloat("Status", 0f); }
		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			anim.SetFloat("Status", 1f); }
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			anim.SetFloat("Status", 2f); }
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			anim.SetFloat("Status", 3f); }
		if(Input.GetKeyDown(KeyCode.Alpha4)) {
			anim.SetFloat("Status", 4f); }
		if(Input.GetKeyDown(KeyCode.Alpha5)) {
			anim.SetFloat("Status", 5f); }
		if(Input.GetKeyDown(KeyCode.Alpha6)) {
			anim.SetFloat("Status", 6f); }
		if(Input.GetKeyDown(KeyCode.Alpha7)) {
			anim.SetFloat("Status", 7f); }
		if(Input.GetKeyDown(KeyCode.Alpha8)) {
			anim.SetFloat("Status", 8f); }
		if(Input.GetKeyDown(KeyCode.Alpha9)) {
			anim.SetFloat("Status", 9f); }
		if(Input.GetKeyDown(KeyCode.Q)) {
			anim.SetFloat("Status", 10f); }
		if(Input.GetKeyDown(KeyCode.W)) {
			anim.SetFloat("Status", 11f); }
		if(Input.GetKeyDown(KeyCode.E)) {
			anim.SetFloat("Status", 12f); }
		if(Input.GetKeyDown(KeyCode.R)) {
			anim.SetFloat("Status", 13f); }
		if(Input.GetKeyDown(KeyCode.T)) {
			anim.SetFloat("Status", 14f); }
		if(Input.GetKeyDown(KeyCode.Y)) {
			anim.SetFloat("Status", 15f); }
		if(Input.GetKeyDown(KeyCode.U)) {
			anim.SetFloat("Status", 16f); }
		if(Input.GetKeyDown(KeyCode.I)) {
			anim.SetFloat("Status", 17f); }
		if(Input.GetKeyDown(KeyCode.O)) {
			anim.SetFloat("Status", 18f); }
		if(Input.GetKeyDown(KeyCode.P)) {
			anim.SetFloat("Status", 19f); }
		if(Input.GetKeyDown(KeyCode.A)) {
			anim.SetFloat("Status", 20f); }
	}
}
