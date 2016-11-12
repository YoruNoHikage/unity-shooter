using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
};

public class SpaceshipMovement : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject center;

	void FixedUpdate ()
	{
		bool isCameraTop = center.GetComponent<CameraSwitch> ().isCameraTop;
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (
			                   moveHorizontal,
			                   isCameraTop ? 0.0f : moveVertical,
			                   isCameraTop ? moveVertical : 0.0f
		                   );
		GetComponent<Rigidbody> ().velocity = movement * speed;

		float xPosition = Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax);
		if (isCameraTop) {
			float zPosition = Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax);
			GetComponent<Rigidbody> ().position = new Vector3 (xPosition, 5.0f, zPosition);
			GetComponent<Rigidbody> ().rotation = Quaternion.Euler (GetComponent<Rigidbody> ().velocity.z * -tilt, 180.0f, 90.0f);
		} else {
			float yPosition = Mathf.Clamp (GetComponent<Rigidbody> ().position.y, boundary.yMin, boundary.yMax);
			GetComponent<Rigidbody> ().position = new Vector3 (xPosition, yPosition, 0.0f);
			GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 180.0f, 90.0f + GetComponent<Rigidbody> ().velocity.y * -tilt);
		}
	}
}