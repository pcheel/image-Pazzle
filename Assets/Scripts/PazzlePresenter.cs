using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazzlePresenter
{
    private IPazzleModel _pazzleModel;
    private IPazzleView _pazzleView;
    private PazzleData _pazzleData;

    public PazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject tilePrefab, IFactory factory)
    {
        _pazzleModel = pazzleModel;
        _pazzleView = pazzleView;
        _pazzleData = pazzleData;
        Enable();
        _pazzleModel.SetPazzleData(pazzleData);
        _pazzleModel.CreateGrid(tilePrefab, factory, _pazzleView.tileParent);
    }

    private void Enable()
    {
        _pazzleModel.OnAspectRatioChangeAction += _pazzleView.SetAspectRatio;
        _pazzleModel.OnGridParametersChangeAction += _pazzleView.SetGridLayoutGroupParameters;
    }
}
