using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour {

	public GameObject attatchedObj;

    public GameObject gauge;

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

        float size = 800 * vol;
        var rectTransform = gauge.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        Debug.Log(rectTransform.localPosition.y);
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, -111 + size / 2, rectTransform.localPosition.z);

		//if (vol > 0.1) {
		//	var pos = attatchedObj.transform.position;
		//	Instantiate (bakuhatu, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
		//	Destroy (attatchedObj);
		//	Destroy (gameObject);
		//}
	}

	float GetAveragedVolume(){ 
		float[] data = new float[1000];
		float a = 0;
		GetComponent<AudioSource> ().GetOutputData(data,0);
		foreach(float s in data) {
			a += Mathf.Abs(s);
		}
		return a/1000.0f;
	}

}
