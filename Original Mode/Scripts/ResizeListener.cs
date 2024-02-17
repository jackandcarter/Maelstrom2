using UnityEngine;
using UnityEngine.EventSystems;

public class ResizeListener : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        RectTransform rt = transform.parent.GetComponent<RectTransform>();
        rt.sizeDelta += new Vector2(eventData.delta.x, -eventData.delta.y);
    }
}
