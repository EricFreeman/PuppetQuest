using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public float MouseSpeed = 3;

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Mouse X");
        var vertical = Input.GetAxisRaw("Mouse Y");
        var input = new Vector3(horizontal, vertical, 0);
        transform.position += input * MouseSpeed * Time.deltaTime;
    }
}
