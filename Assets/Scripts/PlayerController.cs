using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Camera cam;
	private bool jump;
	private Vector3 move;
	private Text txtSpeed, txtRotation, txtPosition, txtH, txtV;
	private 
	void Start () {
		cam = GetComponentInChildren<Camera>();
		txtH = GameObject.Find("HText").GetComponent<Text>();
		txtV = GameObject.Find("VText").GetComponent<Text>();
		txtSpeed = GameObject.Find("SpeedText").GetComponent<Text>();
		txtRotation = GameObject.Find("RotText").GetComponent<Text>();
		txtPosition = GameObject.Find("XYZText").GetComponent<Text>();
	}
	
	void Update () {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		jump = CrossPlatformInputManager.GetButton("Jump");
		Vector3 camForward = Vector3.Scale(cam.transform.forward, new Vector3(1,0,1)).normalized;
		move = (v*camForward + h*cam.transform.right).normalized; 

		txtH.text = h.ToString();
		txtV.text = v.ToString();
	}

	void FixedUpdate() {
		Move(move, jump);
		jump = false;
	}

	private void Move(Vector3 moveDir, bool isJumping) {
		
	}
}
