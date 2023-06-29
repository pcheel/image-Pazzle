using UnityEngine;
using System;

public interface IImageCellView
{
    public Vector2 position {get;}
    public Action OnEndOfDragAction {get;set;}
    public void Initialize(Sprite image, Vector2 size, Vector2 position);
}
