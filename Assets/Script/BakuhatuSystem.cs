using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BakuhatuSystem : MonoBehaviour
{

    public GameObject building, fire, explosion;

    public int explosionCount = 3;

    public float explosionRange = 30.0f;

    public float explosionInterval = 0.15f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Ignition()
    {
        StartCoroutine(Bakuhatu());
    }

    IEnumerator Bakuhatu()
    {
        var pos = building.transform.position;
        for (int i = 0; i < explosionCount; i++)
        {
            Instantiate(explosion, new Vector3(pos.x + Random.Range(-explosionRange, explosionRange), pos.y, pos.z + Random.Range(-explosionRange, explosionRange)), Quaternion.identity);
            yield return new WaitForSeconds(explosionInterval);
        }
        Instantiate(fire, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(building);

        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("dialog", LoadSceneMode.Additive);
    }
}
