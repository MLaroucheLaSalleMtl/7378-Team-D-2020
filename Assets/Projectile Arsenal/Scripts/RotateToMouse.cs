using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {

	public Camera cam;
	public float maximumLenght;

	private Ray rayMouse;
	private Vector3 pos;
	private Vector3 direction;
	private Quaternion rotation;
	public GameObject firpoint;
	//public GameObject firpoint2;

	void Update () {
		
			RaycastHit hit;
			//var mousePos = Input.mousePosition;
		
		int layer_mask = LayerMask.GetMask("Ignore Raycast");
		Ray ray = new Ray(transform.position, Vector3.left);

		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity, layer_mask, QueryTriggerInteraction.Ignore))
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance, Color.yellow);
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
			Debug.Log("Did Hit");
		}
		else
		{
			Debug.DrawRay(firpoint.transform.position,firpoint.transform.TransformDirection(Vector3.forward) * 1000, Color.red);
			//Debug.DrawRay(firpoint2.transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.red);
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * 1000, Color.white);
			//Debug.Log("Did not Hit");
		}
		//rayMouse = cam.ScreenPointToRay (mousePos);
		//if (Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, maximumLenght)) {
		//	RotateToMouseDirection (gameObject, hit.point);
		//} else {
		//	var pos = rayMouse.GetPoint (maximumLenght);
		//	RotateToMouseDirection (gameObject, pos);

		//} 
	}		
	

	//void RotateToMouseDirection (GameObject obj, Vector2 destination){
	//	direction = destination; //- obj.transform.position;
	//	rotation = Quaternion.LookRotation (direction);
	//	obj.transform.localRotation = Quaternion.Lerp (obj.transform.rotation, rotation, 1);
	//}

	//public Quaternion GetRotation (){
	//	return rotation;
	//}
}
