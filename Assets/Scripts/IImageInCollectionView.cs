using UnityEngine;
using System;

public interface IImageInCollectionView
{
    public Action<Sprite> OnClickOnImageAction {get;set;}
    public void SetImage(Sprite image);
}
