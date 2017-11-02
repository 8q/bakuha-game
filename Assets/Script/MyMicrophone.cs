using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyMicrophone : MonoBehaviour {

    private GaugeSystem gauge;

    private bool isMicrophoneSet = false;

	IEnumerator Start()
    {
		var aud = GetComponent<AudioSource> ();
		aud.clip = Microphone.Start(null, true, 999, 44100);
		aud.loop = true;
		while (!(Microphone.GetPosition("") > 0))
        {
            yield return null;
        }
		aud.Play();
        gauge = GameObject.Find("Systems/GaugeSystem").GetComponent<GaugeSystem>();
        isMicrophoneSet = true;
    }
	
	void Update()
    {
        if (!isMicrophoneSet) return;

        float vol = GetAveragedVolume();
        float size = 450 * vol;
        gauge.SetValue(size);
	}

	float GetAveragedVolume()
    { 
		float[] data = new float[1000];
		float a = 0;
		GetComponent<AudioSource> ().GetOutputData(data,0);
		foreach(float s in data)
        {
			a += Mathf.Abs(s);
		}
		return a/1000.0f;
	}

}
