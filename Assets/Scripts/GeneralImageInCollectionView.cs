using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class GeneralImageInCollectionView : MonoBehaviour, IImageInCollectionView, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private AspectRatioFitter _aspectRatioFitter;

    public Action<Sprite> OnClickOnImageAction {get;set;}

    public void SetImage(Sprite image)
    {
        _image.sprite = image;
        CalculateAndSetAspectRatio();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickOnImageAction?.Invoke(_image.sprite);
    }

    private void CalculateAndSetAspectRatio()
    {
        _aspectRatioFitter.aspectRatio = (float)_image.sprite.texture.width / _image.sprite.texture.height; 
    }

}
