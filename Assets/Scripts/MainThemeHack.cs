using UnityEngine;

public class MainThemeHack : MonoBehaviour
{
    public GameObject DirectionalLight;

    private AudioSource _as;

    public float Max = .8f;

    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        if (DirectionalLight.activeSelf && !_as.isPlaying)
        {
            _as.Play();
            GameTextController.Instance.Intro();
        }

        if (_as.isPlaying)
        {
            _as.volume = Mathf.Lerp(_as.volume, Max, Time.deltaTime * 1);
        }

        if (_as.volume == Max)
        {
            Destroy(this);
        }
    }
}
