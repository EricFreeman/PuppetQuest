using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreenShake : MonoBehaviour
{
    public static CameraScreenShake Instance;

    private float _amplitude;
    private float _frequency;

    private void Start()
    {
        Instance = this;
    }

    private void LateUpdate()
    {
        var x = (Mathf.PerlinNoise(Time.time * _frequency, 0) - .5f) * _amplitude;
        var y = (Mathf.PerlinNoise(Time.time * _frequency, 3) - .5f) * _amplitude;
        _amplitude = Mathf.Lerp(_amplitude, 0, 4 * Time.deltaTime);
        transform.localPosition = new Vector3(x, y, 0);
    }

    public void Shake(float amplitude = .5f, float frequency = 2f)
    {
        _amplitude = amplitude;
        _frequency = frequency;
    }
}