using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration, intensity,frequncy;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= duration)
        {
            transform.localPosition = new Vector3(
            wackyCurves(intensity, frequncy, duration),
            wackyCurves(intensity, frequncy, duration),
            0);
            timer += Time.deltaTime;
        }
        else
        {
            transform.localPosition = Vector3.zero;
        }
        
    }

    float wackyCurves(float a, float b, float c)
    {
        return a * Mathf.Sin(((b * Mathf.PI) / c) * timer);
    }
}
