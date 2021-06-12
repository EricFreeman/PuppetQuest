using UnityEngine;

public class RopeLight : MonoBehaviour
{
    private LineRenderer _lr;
    public Light Light;

    public Color OffColor;
    public Color OnColor;

    private void Start()
    {
        _lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        var c = Light.intensity < .01f ? OffColor : OnColor;
        _lr.startColor = _lr.endColor = c;
    }
}
