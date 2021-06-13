using UnityEngine;

public class WoodBlockerSecret : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) < 3.8f)
        {
            GameTextController.Instance.SecretWoodsText();
            Destroy(this);
        }
    }
}
