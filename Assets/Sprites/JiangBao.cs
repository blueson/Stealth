using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiangBao : MonoBehaviour {

	public bool chufa = false;
	public float lightSpeed = 3f;
	public static JiangBao _instance;
	private float hightIntensity = 0.5f;
	private float lowIntensity = 0;

	private float targetIntensity;
	private Light _light;

	void Awake(){
		_instance = this;
		chufa = false;
		targetIntensity = hightIntensity;	
	}

	// Use this for initialization
	void Start () {
		_light = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		if (chufa) {
			_light.intensity = Mathf.Lerp (_light.intensity, targetIntensity, Time.deltaTime * lightSpeed);
			if (Mathf.Abs (targetIntensity - _light.intensity) < 0.05f) {
				if (targetIntensity == hightIntensity) {
					targetIntensity = lowIntensity;
				} else {
					targetIntensity = hightIntensity;
				}
			}
		} else {
			_light.intensity = Mathf.Lerp (_light.intensity, 0, Time.deltaTime * lightSpeed);
		}
	}
}
