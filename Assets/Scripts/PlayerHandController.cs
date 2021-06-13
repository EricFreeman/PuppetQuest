using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    public float MouseSpeed = 8f;
    public float PlayerSpeed = 4f;
    public float WalkSpeed = 2f;
    public Transform PlayerBody;
    public Transform World;

    public LayerMask CollisionLayers;

    public static float LastPlayerMovement;

    private float _waitForSeconds = 4f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        _waitForSeconds -= Time.deltaTime;
        if (_waitForSeconds > 0)
        {
            return;
        }

        var horizontal = Input.GetAxisRaw("Mouse X");
        var vertical = Input.GetAxisRaw("Mouse Y");
        var input = new Vector3(horizontal, vertical, 0);
        transform.position += input * MouseSpeed * Time.fixedDeltaTime;

        var playerGoal = transform.position;
        playerGoal.y = -5f + (transform.position.y / 5f);

        var playerMovement = Vector3.Lerp(PlayerBody.position, playerGoal, PlayerSpeed * Time.fixedDeltaTime) - PlayerBody.position;

        var canMoveRight = !Physics.Raycast(PlayerBody.position + Vector3.up, Vector3.right, out RaycastHit hit, 2, CollisionLayers);
        var canMoveLeft = !Physics.Raycast(PlayerBody.position + Vector3.up, -Vector3.right, out RaycastHit hit2, 2, CollisionLayers);

        playerMovement.x = canMoveRight || playerMovement.x < 0 ? playerMovement.x : 0;
        playerMovement.x = canMoveLeft || playerMovement.x > 0 ? playerMovement.x : 0;

        PlayerBody.position += playerMovement;

        var movement = Input.GetAxisRaw("Horizontal");
        movement = canMoveRight || movement < 0 ? movement : 0;
        movement = canMoveLeft || movement > 0 ? movement : 0;
        World.transform.position -= Vector3.right * WalkSpeed * movement * Time.fixedDeltaTime;

        LastPlayerMovement = playerMovement.x;

        Debug.DrawLine(PlayerBody.position + Vector3.up, PlayerBody.position + Vector3.up + (Vector3.right * 2), canMoveRight ? Color.green : Color.red);
        Debug.DrawLine(PlayerBody.position + Vector3.up, PlayerBody.position + Vector3.up - (Vector3.right * 2), canMoveLeft ? Color.green : Color.red);
    }
}
