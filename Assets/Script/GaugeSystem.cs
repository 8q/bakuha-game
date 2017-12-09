using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeSystem : MonoBehaviour
{

    public GameObject gauge;

    public bool stop = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetValue(float height)
    {

        if (stop) return;

        if (height > 223.0f) height = 223.0f;
        var rectTransform = gauge.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, -111 + height / 2, rectTransform.localPosition.z);


        float border = 170.0f;
        if (height <= border)
        {
            gauge.GetComponent<Image>().color = new Color(0, 1.0f, 0);
        }
        else if (height > border)
        {
            stop = true;
            gauge.GetComponent<Image>().color = new Color(1.0f, 0, 0);
            GameObject.Find("Systems/BakuhatuSystem").SendMessage("Ignition");
        }
    }

}
