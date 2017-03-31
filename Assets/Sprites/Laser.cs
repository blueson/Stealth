using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public bool isTwinkle = false;

	public float showTime = 2.0f;
	public float hideTime = 2.0f;

	private float time = 0.0f;

	void Update(){
		if (isTwinkle) {
			time += Time.deltaTime;

			if (GetComponent<Renderer> ().enabled) {
				if (showTime <= time) {
					GetComponent<Renderer> ().enabled = false;
					GetComponent<BoxCollider> ().enabled = false;
					time = 0.0f;
				}
			} else {
				if (hideTime <= time) {
					GetComponent<Renderer> ().enabled = true;
					GetComponent<BoxCollider> ().enabled = true;
					time = 0.0f;
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameController._instance.seePlayer (other.transform.position);
		}
	}
}
