using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y > 3.11)
        {
            transform.Translate(0, -5f, 0);
            if (transform.position.y < 3.11f) transform.position = new Vector3(transform.position.x, 3.11f, transform.position.z);
        }
		
	}
}
