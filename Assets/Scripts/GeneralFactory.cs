using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralFactory : MonoBehaviour, IFactory
{
    public PazzleLoader CreatePazzleLoader()
    {
        return new PazzleLoader();
    }
    public IPazzleModel CreatePazzleModel()
    {
        return new GeneralPazzleModel();
    }
    public IPazzleView CreatePazzleView(GameObject pazzleViewPrefab, Transform parent)
    {
        GameObject pazzleViewGO = Instantiate(pazzleViewPrefab, parent);
        return pazzleViewGO.GetComponent<IPazzleView>();
    }
    public PazzlePresenter CreatePazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject tilePrefab, IFactory factory)
    {
        return new PazzlePresenter(pazzleModel, pazzleView, pazzleData, tilePrefab, factory);
    }
    public ITileView CreateTileView(GameObject tileViewPrefab, Transform parent)
    {
        GameObject tileGO = Instantiate(tileViewPrefab, parent);
        return tileGO.GetComponent<ITileView>();
    }
}
