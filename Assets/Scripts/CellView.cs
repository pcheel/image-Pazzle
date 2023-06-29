using UnityEngine;

public class CellView : MonoBehaviour
{
    private RectTransform _rectTransform;

    public Vector2 position => _rectTransform.anchoredPosition;

    private void Awake() 
    {
        _rectTransform = GetComponent<RectTransform>();
    }
}
