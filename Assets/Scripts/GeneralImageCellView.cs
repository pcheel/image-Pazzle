using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class GeneralImageCellView : MonoBehaviour, IImageCellView, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private Image _image;
    private RectTransform _rectTransform;
    private Canvas _canvas;
    private Vector2 _positionBeforeDrag;

    public Vector2 position => _rectTransform.anchoredPosition;
    public Action OnEndOfDragAction {get;set;}

    public void Initialize(Sprite image, Vector2 size, Vector2 position)
    {
        _image.sprite = image;
        _rectTransform.sizeDelta = size;
        _rectTransform.anchoredPosition = position;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _canvas.sortingOrder = 5;
        _positionBeforeDrag = _rectTransform.anchoredPosition;
        _rectTransform.anchoredPosition = CalculateImageCellNewPosition(eventData);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition = CalculateImageCellNewPosition(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvas.sortingOrder = 1;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        foreach (var raycastResult in raycastResults)
        {
            if (raycastResult.gameObject.name == "GeneralCellView(Clone)")
            {
                int n = 0;
                foreach (var raycastResult2 in raycastResults)
                {
                    if (raycastResult2.gameObject.name == "imageCellView(Clone)")
                    {
                        n++;
                        if (n > 1)
                        {
                            _rectTransform.anchoredPosition = _positionBeforeDrag;
                            return;
                        }
                        else 
                        {
                            _rectTransform.anchoredPosition = raycastResult.gameObject.GetComponent<RectTransform>().anchoredPosition;
                        }
                    }
                }
            }
        }
        OnEndOfDragAction?.Invoke();
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponent<Canvas>();
    }
    private Vector2 CalculateImageCellNewPosition(PointerEventData eventData)
    {
        Vector2 newPosition = eventData.position;
        newPosition.x -= Screen.width/2;
        newPosition.y -= Screen.height/2;
        return newPosition;
    }
}
