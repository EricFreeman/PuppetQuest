using UnityEngine;

public class GoblinKing : MonoBehaviour
{
    void Update()
    {
        if (Vector3.Distance(transform.position, Camera.main.transform.position) < 14f)
        {
            GameTextController.Instance.BossFightStarted.Play();
            Destroy(this);
        }
    }
}
