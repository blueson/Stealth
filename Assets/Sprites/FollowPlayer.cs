using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public float moveSpeed = 6.0f;
	public float rotateSpeed = 1.0f;

	private Vector3 offset;
	private Transform player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		offset = transform.position - player.position;
		offset = new Vector3 (0, offset.y, offset.z);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 begin = player.position + offset;
		Vector3 end = player.position + offset.magnitude * Vector3.up;
		Vector3 pos1 = Vector3.Lerp (begin, end, 0.25f);
		Vector3 pos2 = Vector3.Lerp (begin, end, 0.5f);
		Vector3 pos3 = Vector3.Lerp (begin, end, 0.75f);

		Vector3[] posArray = new Vector3[]{begin,pos1,pos2,pos3,end};
		Vector3 targetPos = posArray [0];
		foreach (Vector3 pos in posArray) {
			RaycastHit hit;
			if (Physics.Raycast (pos,player.position - pos,out hit)) {
				if (hit.collider.tag == "Player") {
					targetPos = pos;
					break;
				}
			}
		}

		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * moveSpeed);
		Quaternion nowQuaternion = transform.rotation;
		transform.LookAt(player.position);
		transform.rotation = Quaternion.Lerp (nowQuaternion, transform.rotation, Time.deltaTime * rotateSpeed);
	}
}
