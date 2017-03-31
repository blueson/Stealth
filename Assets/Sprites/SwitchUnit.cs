using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUnit : MonoBehaviour {

	public GameObject laser;
	public GameObject screen;
	public Material unlock;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.Z)) {
				screen.GetComponent<Renderer> ().material = unlock;
				laser.SetActive (false);
				audio.Play ();
			}
		}
	}
}
