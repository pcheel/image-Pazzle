using UnityEngine;

public interface IPazzleView
{
    public Transform generalCellParent{get;}
    public Transform imageCellParent{get;}
    public void SetAspectRatio(float newAspectRatio);
    public void SetImage(Sprite image);
    public void SetGridLayoutGroupParameters(Vector2 cellSize, int constraintCount);
}
