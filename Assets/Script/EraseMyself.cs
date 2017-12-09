using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseMyself : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GoToHeaven());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GoToHeaven()
    {
        yield return new WaitForSeconds(15);

        Destroy(gameObject);
    }

}
