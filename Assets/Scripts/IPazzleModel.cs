using UnityEngine;
using System;

public interface IPazzleModel 
{
    public Action<float> OnAspectRatioChangeAction {get;set;}
    public Action<Vector2, int> OnGridParametersChangeAction {get;set;}
    public Action OnWinAction {get;set;}
    public void SetPazzleDataAndFactory(PazzleData pazzleData, IFactory factory);
    public void CreateGrid(GameObject tilePrefab, Transform tileParent);
    public void SliceImage(GameObject imageCellViewPrefab, Transform parent);
    public void CheckWin();
}
