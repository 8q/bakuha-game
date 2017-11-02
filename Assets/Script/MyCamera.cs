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
        if(new Vector3(newPosition.x, 0, newPosition.z).magnitude > 30 && new Vector3(newPosition.x, 0, newPosition.z).magnitude < 80)
        {
            child.position = newPosition;
        }

        float pitch = 0f;
        if (Input.GetKey(KeyCode.UpArrow)) pitch = -0.8f;
        else if (Input.GetKey(KeyCode.DownArrow)) pitch = 0.8f;
        child.transform.Rotate(Quaternion.AngleAxis(0.001f, new Vector3(child.position.x, 0, child.position.z).normalized) * new Vector3(pitch, 0, 0));

        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, 0.5f, 0);
            if (transform.position.y > 100) transform.position = new Vector3(transform.position.x, 100, transform.position.z);
        }
        else if(transform.position.y > 0)
        {
            transform.Translate(0, -1f, 0);
            if (transform.position.y < 0) transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
