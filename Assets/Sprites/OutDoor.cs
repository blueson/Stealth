using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor : MonoBehaviour {

	public float inner_door_moveSpeed = 3.0f;
	public Transform out_door_left;
	public Transform inner_door_left;

	public Transform out_door_right;
	public Transform inner_door_right;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		float inner_door_left_x = Mathf.Lerp (inner_door_left.position.x, out_door_left.position.x, Time.deltaTime * inner_door_moveSpeed);
		inner_door_left.position = new Vector3 (inner_door_left_x, inner_door_left.position.y, inner_door_left.position.z);

		float inner_door_right_x = Mathf.Lerp (inner_door_right.position.x, out_door_right.position.x, Time.deltaTime * inner_door_moveSpeed);
		inner_door_right.position = new Vector3 (inner_door_right_x, inner_door_right.position.y, inner_door_right.position.z);
	}
}
