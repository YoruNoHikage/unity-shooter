using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour
{
	public float speed;
	public bool isCameraTop = true;

	void Update ()
	{
		Vector3 cameraTopPos = new Vector3 (0, 12, 0);
		Vector3 cameraSidePos = new Vector3 (0, -6, -15);

		if (Input.GetKeyUp ("space")) {
			isCameraTop = !isCameraTop;
		}

		Vector3 targetDir = -(isCameraTop ? cameraTopPos : cameraSidePos) - transform.position;

		Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, speed * Time.deltaTime, 0.0f);
		transform.rotation = Quaternion.LookRotation (newDir);
	}
}