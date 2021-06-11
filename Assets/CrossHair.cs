using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public RectTransform[] components;
    public float bloomMulti, currentAcc,defOffset;
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        //components = transform.GetComponentsInChildren<RectTransform>().;
    }

    // Update is called once per frame
    void Update()
    {
        offset = defOffset + bloomMulti * currentAcc;
        components[0].localPosition = new Vector2(0,offset);
        components[1].localPosition = new Vector2(0, -offset);
        components[2].localPosition = new Vector2(offset,0);
        components[3].localPosition = new Vector2(-offset,0);
    }
}
