using UnityEngine;
using UnityEngine.EventSystems;

public class EndMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool IsHovering = false;
    public float HoverSize = 1.5f;
    public float LerpSpeed = 10f;

    void Update()
    {
        var goal = IsHovering ? Vector3.one * HoverSize : Vector3.one;
        transform.localScale = Vector3.Lerp(transform.localScale, goal, Time.deltaTime * LerpSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovering = false;
    }
}
