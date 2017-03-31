using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public bool jingbao = false;
	public static GameController _instance;
	public Vector3 lastPlayerPosition = Vector3.zero;

	public AudioSource musicNormal;
	public AudioSource musicPanic;
	private GameObject[] sirens;

	void Awake(){
		jingbao = false;
		sirens = GameObject.FindGameObjectsWithTag ("JingBao");
		_instance = this;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		JiangBao._instance.chufa = jingbao;

		if (jingbao) {
			musicNormal.volume = Mathf.Lerp(musicNormal.volume,0,Time.deltaTime);
			musicPanic.volume = Mathf.Lerp(musicPanic.volume,1,Time.deltaTime);
			playSiren ();
		} else {
			musicNormal.volume = Mathf.Lerp(musicNormal.volume,1,Time.deltaTime);
			musicPanic.volume = Mathf.Lerp(musicPanic.volume,0,Time.deltaTime);
			stopSiren ();
		}
	}

	private void playSiren(){
		foreach(GameObject siren in sirens){
			AudioSource audio = siren.GetComponent<AudioSource> ();
			if (!audio.isPlaying) {
				audio.Play ();
			}
		}
	}

	private void stopSiren(){
		foreach (GameObject siren in sirens) {
			siren.GetComponent<AudioSource> ().Stop ();
		}
	}

	public void seePlayer(Vector3 position){
		lastPlayerPosition = position;
		jingbao = true;
	}
}
