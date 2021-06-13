using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public AudioSource BackgroundSong;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        BackgroundSong.volume = Mathf.Lerp(BackgroundSong.volume, .719f, Time.deltaTime * 3);
    }

    public void TwitterButton()
    {
        Application.OpenURL("https://twitter.com/_ericfreeman");
    }

    public void Close()
    {
        Application.Quit();
    }
}
