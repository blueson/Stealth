using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour {

	public AudioClip clip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		print (other.tag);
		if (other.tag == "Player") {
			Ethan ethan = other.GetComponent<Ethan> ();
			ethan.hasKey = true;

			AudioSource.PlayClipAtPoint (clip, other.gameObject.transform.position);
			Destroy (this.gameObject);
		}
	}
}
