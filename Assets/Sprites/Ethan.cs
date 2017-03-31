using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ethan : MonoBehaviour {

	public float moveSpeed = 3;
	public float rotationSpeed = 7;
	public bool hasKey = false;

	private Animator anim;
	private AudioSource _audio;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		_audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift)) {
			anim.SetBool ("Sneak", true);
		} else {
			anim.SetBool ("Sneak", false);
		}

		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if (Mathf.Abs (h) > 0.1 || Mathf.Abs (v) > 0.1) {
			float newSpeed = Mathf.Lerp (anim.GetFloat ("Speed"), 5.6f, Time.deltaTime * moveSpeed);
			anim.SetFloat ("Speed", newSpeed);

			Vector3 targetRotation = new Vector3 (h, 0, v);
			Quaternion newQuaternion = Quaternion.LookRotation (targetRotation, Vector3.up);
			transform.rotation = Quaternion.Lerp (transform.rotation, newQuaternion, Time.deltaTime * rotationSpeed);

		} else {
			anim.SetFloat ("Speed", 0);
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("motion")) {
			if (!_audio.isPlaying) {
				_audio.Play ();
			}
		} else {
			if (_audio.isPlaying) {
				_audio.Stop ();
			}
		}
	}
}
