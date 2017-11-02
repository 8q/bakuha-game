using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, (Input.GetAxis("Horizontal") * -1), 0);
        var child = transform.Find("Main Camera");
        float verticalInput = -Input.GetAxis("Vertical");
        var newPosition =  new Vector3(
            child.position.x + verticalInput * child.position.normalized.x, 
            child.position.y, 
            child.position.z + verticalInput * child.position.normalized.z);
        if(newPosition.magnitude > 30 && newPosition.magnitude < 80)
        {
            child.position = newPosition;
        }
    }
}
