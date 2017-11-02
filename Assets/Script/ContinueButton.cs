using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour {

    public GameObject building;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        GameObject.Find("Systems/GameSystem").SendMessage("RestartGame");
        SceneManager.UnloadSceneAsync("dialog");
    }
}
