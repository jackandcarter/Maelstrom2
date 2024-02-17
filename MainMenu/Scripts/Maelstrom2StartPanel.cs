using UnityEngine;

public class Maelstrom2StartPanel : MonoBehaviour
{
    void Update()
    {
        // Deactivate the panel when clicked outside
        if (Input.GetMouseButtonDown(0) && !RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
        {
            gameObject.SetActive(false);
        }
    }
}
