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

        float direction = 0f;
        if (Input.GetKey(KeyCode.Z)) direction = -0.8f;
        else if (Input.GetKey(KeyCode.X)) direction = 0.8f;
        var child = transform.Find("Main Camera");
        float verticalInput = -Input.GetAxis("Vertical");
        var newPosition =  new Vector3(
            child.position.x + direction * child.position.normalized.x, 
            child.position.y, 
            child.position.z + direction * child.position.normalized.z);
        if(newPosition.magnitude > 30 && newPosition.magnitude < 80)
        {
            child.position = newPosition;
        }

        float pitch = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) pitch = -0.8f;
        else if (Input.GetKey(KeyCode.DownArrow)) pitch = 0.8f;
        child.transform.Rotate(Quaternion.AngleAxis(0.001f, new Vector3(child.position.x, 0, child.position.z).normalized) * new Vector3(pitch, 0, 0));
    }
}
