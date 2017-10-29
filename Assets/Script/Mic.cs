using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour {

	public GameObject attatchedObj;

	public GameObject bakuhatu;

	void Start(){
		var aud = GetComponent<AudioSource> ();
		aud.clip = Microphone.Start(null, true, 999, 44100);
		aud.loop = true;
		while (!(Microphone.GetPosition("") > 0)){}
		aud.Play();
	}
	
	void Update(){
		float vol = GetAveragedVolume();

		if (vol > 0.1) {
			var pos = attatchedObj.transform.position;
			Instantiate (bakuhatu, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
			Destroy (attatchedObj);
			Destroy (gameObject);
		}
	}

	float GetAveragedVolume(){ 
		float[] data = new float[256];
		float a = 0;
		GetComponent<AudioSource> ().GetOutputData(data,0);
		foreach(float s in data) {
			a += Mathf.Abs(s);
		}
		return a/256.0f;
	}

}
