using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public float MouseSpeed = 8f;
    public float PlayerSpeed = 4f;
    public float WalkSpeed = 2f;
    public Transform PlayerBody;
    public Transform World;

    public LayerMask CollisionLayers;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Mouse X");
        var vertical = Input.GetAxisRaw("Mouse Y");
        var input = new Vector3(horizontal, vertical, 0);
        transform.position += input * MouseSpeed * Time.deltaTime;

        var playerGoal = transform.position;
        playerGoal.y = -5 + (transform.position.y) / 5f;
        var canMoveRight = !Physics.Raycast(PlayerBody.transform.position + Vector3.up, Vector3.right, out RaycastHit hit, 1.25f, CollisionLayers);
        playerGoal.x = canMoveRight || playerGoal.x < 0 ? playerGoal.x : 0;
        PlayerBody.position = Vector3.Lerp(PlayerBody.position, playerGoal, PlayerSpeed * Time.deltaTime);

        var movement = Input.GetAxisRaw("Horizontal");
        movement = canMoveRight || movement < 0 ? movement : 0;
        World.transform.position -= Vector3.right * WalkSpeed * movement * Time.deltaTime;

        Debug.DrawLine(PlayerBody.transform.position + Vector3.up, PlayerBody.transform.position + Vector3.up + Vector3.right, Color.red);
    }
}
