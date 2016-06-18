using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class SimpleMouseLook : MonoBehaviour {
	// attach to camera obj (child of character obj)
	 
	public float mouseSensitivity = 100.0f;
	public float clampAngle = 50.0f; 
	public bool lockCursor = true;
	private bool isLocked;
	public bool useController = true;
	public float controllerLookSensitivity = 100.0f;
	public bool independentLook = false;  //don't move body - only camera

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis
	private float smoothRot = 5.0f;

 	private Text txtRotation;
 	private Transform charTrans;

	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x; 
		LockCursor(lockCursor);
		isLocked = lockCursor;
		txtRotation = GameObject.Find("RotText").GetComponent<Text>();
		charTrans = transform.parent.transform;  // get parent's transform
	}

	void LockCursor(bool hide) {
		if (hide) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

	}

	void Update () {
		float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
		float mouseY = -CrossPlatformInputManager.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		if (useController) {
			float horizontal2 = CrossPlatformInputManager.GetAxis("RHorizontal");
			float vertical2   = -CrossPlatformInputManager.GetAxis("RVertical");
			rotY += horizontal2 * controllerLookSensitivity * Time.deltaTime;
			rotX += vertical2 * controllerLookSensitivity * Time.deltaTime;
		}

		//txtRotation.text = rotX.ToString();
		rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		if (independentLook) {
			Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
			transform.rotation = Quaternion.Slerp (transform.rotation, localRotation, 
				smoothRot * Time.deltaTime); 
		} else {
			Quaternion camRotation  = Quaternion.Euler(rotX, 0.0f, 0.0f);
			Quaternion charRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
			transform.localRotation = camRotation; 
			charTrans.localRotation = Quaternion.Slerp (charTrans.localRotation, charRotation,
				smoothRot * Time.deltaTime);
		}

		if (lockCursor && Input.GetKeyDown(KeyCode.Escape)) {
			isLocked = !isLocked;
			LockCursor(isLocked);
		}
	}

}
