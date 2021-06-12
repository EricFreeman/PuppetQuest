using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Sword")
        {
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            //Debug.Log(rb.velocity.magnitude);
            //Debug.Log("impact: " + collision.relativeVelocity.magnitude);
        }
    }
}
