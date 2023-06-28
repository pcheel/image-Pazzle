using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory
{
    public PazzleLoader CreatePazzleLoader();
    public IPazzleModel CreatePazzleModel();
    public IPazzleView CreatePazzleView(GameObject pazzleViewGO, Transform parent);
    public PazzlePresenter CreatePazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject tilePrefab, IFactory factory);
    public ITileView CreateTileView(GameObject tileViewGO, Transform parent);
}
