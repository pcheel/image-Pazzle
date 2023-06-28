using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPazzleModel 
{
    public Action<float> OnAspectRatioChangeAction {get;set;}
    public Action<Vector2, int> OnGridParametersChangeAction {get;set;}
    public void SetPazzleData(PazzleData pazzleData);
    public void CreateGrid(GameObject tilePrefab, IFactory factory, Transform tileParent);
    // public void CalcutaleGridParameters(PazzleData pazzleData);
}
