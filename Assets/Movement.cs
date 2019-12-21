using UnityEngine;

public class Movement : MonoBehaviour {
	public float maxSpeed;
	public float rotationRate;
	float pitch;

    void Update() {
		if(Cursor.lockState != CursorLockMode.Locked)
			return;

        transform.Rotate(new Vector3(0, rotationRate * Input.GetAxis("Mouse X"), 0), Space.World);

		var rot = transform.localEulerAngles;
		pitch = Mathf.Clamp(pitch - (rotationRate * Input.GetAxis("Mouse Y")), -80.0f, 80.0f);
		rot.x = pitch;
		transform.localEulerAngles = rot;

		var speed = maxSpeed * Time.deltaTime;

		float verticalSpeed = (Input.GetKey(KeyCode.Space) ? speed : 0.0f);
		verticalSpeed -= (Input.GetKey(KeyCode.LeftShift) ? speed : 0.0f);

		var lateralDirection =	(transform.forward * Input.GetAxisRaw("Vertical") +
								transform.right * Input.GetAxisRaw("Horizontal")).normalized;

		transform.Translate((Vector3.up * verticalSpeed) + (lateralDirection * speed), Space.World);
    }
}
