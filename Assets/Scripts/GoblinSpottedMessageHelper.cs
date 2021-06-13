using UnityEngine;

public class GoblinSpottedMessageHelper : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 12.5f)
        {
            GameTextController.Instance.GoblinSpotted.Play();
            Destroy(this);
        }
    }
}
