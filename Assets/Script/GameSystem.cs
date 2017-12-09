using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{

    public GameObject building;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        GameObject.Find("Systems/BakuhatuSystem").GetComponent<BakuhatuSystem>().building = Instantiate(building, new Vector3(0, 100f, 0), Quaternion.identity);
        GameObject.Find("Systems/GaugeSystem").GetComponent<GaugeSystem>().stop = false;
    }
}
