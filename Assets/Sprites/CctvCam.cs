using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CctvCam : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameController._instance.seePlayer (other.transform.position);
		}
	}
}
