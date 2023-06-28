using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPazzleView
{
    public Transform tileParent{get;}
    public void SetAspectRatio(float newAspectRatio);
    public void SetGridLayoutGroupParameters(Vector2 cellSize, int constraintCount);
}
