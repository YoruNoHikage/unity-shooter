using UnityEngine;
using System.Collections;

public class GroundHandler : MonoBehaviour
{
	public float speed = 1.0f;

	void Update ()
	{
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).Translate (Vector3.left * speed * Time.deltaTime);
		}

		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		GameObject leftPlate = transform.GetChild(0).gameObject;
		if (!GeometryUtility.TestPlanesAABB(planes, leftPlate.transform.GetChild(0).GetComponent<Collider>().bounds)) {
			leftPlate.transform.SetAsLastSibling ();

			leftPlate.transform.position = new Vector3(
				transform.GetChild(1).position.x + transform.GetChild(1).GetChild(0).GetComponent<Collider>().bounds.size.x,
				0,
				0
			);
		}
	}
}
