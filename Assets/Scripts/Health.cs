using UnityEngine;

public class Health : MonoBehaviour
{
    public DamageNumber DamageNumber;
    public int TotalHealth = 30;
    [HideInInspector]
    public int CurrentHealth;
    public float SpeedDamageMultiplier = 7.5f;

    public MeshRenderer MR;
    private Material _mat;

    private float _lastHitTime;

    public GameObject DeathParticle;

    private void Start()
    {
        _mat = MR.material;
        CurrentHealth = TotalHealth;
    }

    private void Update()
    {
        var color = Time.time - _lastHitTime < .15f ? Color.red : Color.white;
        _mat.SetColor("_BaseColor", color);

        if (CurrentHealth <= 0)
        {
            var dust = Instantiate(DeathParticle, transform.position, Quaternion.identity);
            dust.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Sword" && PlayerHandController.LastPlayerMovement > .1f)
        {
            var damage = Mathf.RoundToInt((PlayerHandController.LastPlayerMovement + .1f) * SpeedDamageMultiplier);
            CameraScreenShake.Instance.Shake();
            _lastHitTime = Time.time;
            CurrentHealth -= damage;
            var dm = Instantiate(DamageNumber, collision.gameObject.transform.position, Quaternion.identity);
            dm.Init(damage);
        }
    }
}
