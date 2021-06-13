using UnityEngine;

public class WoodBlockerSecret : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.position) < 4.5f)
        {
            GameTextController.Instance.SecretWoodsText();
            Destroy(this);
        }
    }
}
