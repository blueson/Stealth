using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public bool needKey = false;
	private Animator anim;
	public AudioSource audio;
	public AudioSource notKeyAudio;

	private int count = 0;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Open", count > 0);

		if (anim.IsInTransition(0)) {
			if (!audio.isPlaying) {
				audio.Play ();
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (needKey) {
			if (other.tag == "Player") {
				Ethan ethan = other.GetComponent<Ethan> ();
				if (ethan.hasKey) {
					count++;
				} else {
					notKeyAudio.Play ();
				}
			}
		} else {
			if (other.tag == "Player" || other.tag == "Enemy") {
				count++;
			}
		}

	}

	void OnTriggerExit(Collider other){
		if (needKey) {
			if (other.tag == "Player") {
				Ethan ethan = other.GetComponent<Ethan> ();
				if (ethan.hasKey) {
					count--;
				}
			}
		} else {
			if (other.tag == "Player" || other.tag == "Enemy") {
				count--;
			}
		}
	}
}
