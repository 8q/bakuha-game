using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mic : MonoBehaviour {

	public GameObject attatchedObj;

    public GameObject gauge;

	public GameObject bakuhatu;

    public GameObject fire;

    private bool isDeleted = false;

    float vol = 0.0f;


	void Start()
    {
		var aud = GetComponent<AudioSource> ();
		aud.clip = Microphone.Start(null, true, 999, 44100);
		aud.loop = true;
		while (!(Microphone.GetPosition("") > 0)){}
		aud.Play();
	}
	
	void Update()
    {
        if (isDeleted) return;
        vol = GetAveragedVolume();
        //vol += 0.001f;
        float size = 450 * vol;
        var rectTransform = gauge.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, -111 + size / 2, rectTransform.localPosition.z);
        int border = 170;

        if(size <= border)
        {
            gauge.GetComponent<Image>().color = new Color(0, 1.0f, 0);
        }
        else if (size > border)
        {
            if (size > 223.0f) size = 223.0f;
            gauge.GetComponent<Image>().color = new Color(1.0f, 0, 0);
            isDeleted = true;
            StartCoroutine(Bakuhatu());
        }
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

    IEnumerator Bakuhatu()
    {
        var pos = attatchedObj.transform.position;
        float range = 30.0f;
        for(int i = 0; i < 3; i++)
        {
            Instantiate(bakuhatu, new Vector3(pos.x + Random.Range(-range, range), pos.y, pos.z + Random.Range(-range, range)), Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        fire.SetActive(true);
        Destroy(attatchedObj);
        Destroy(gameObject);
    }

}
