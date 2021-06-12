using UnityEngine;

public class SimpleNoise : MonoBehaviour
{
    public float Amplitude = .25f;
    public float Frequency = .5f;
    private Vector3 _origin;

    private void Start()
    {
        _origin = transform.localPosition;
    }

    void Update()
    {
        var x = Mathf.PerlinNoise(Time.time * Frequency, 1) * Amplitude;
        var y = Mathf.PerlinNoise(Time.time * Frequency, 2) * Amplitude;
        var z = Mathf.PerlinNoise(Time.time * Frequency, 3) * Amplitude;
        var noise = new Vector3(x, y, z);
        transform.localPosition = _origin + noise;
        transform.localEulerAngles = new Vector3(x, y, z);
    }
}
