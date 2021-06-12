using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public int Amount;
    public TMP_Text Text;
    private Vector3 dir;

    public void Init(int amt)
    {
        Amount = amt;
        Text.text = Amount.ToString();
        Text.color = Color.Lerp(Color.white, Color.red, Amount / 10f);
        dir = Random.insideUnitSphere.normalized;
        dir.y = Mathf.Abs(dir.y) + 2f;
    }

    void Update()
    {
        transform.position += Physics.gravity * Time.deltaTime;
        transform.position += dir * Time.deltaTime;
        dir = Vector3.MoveTowards(dir, Vector3.zero, .1f * Time.deltaTime);
    }
}
