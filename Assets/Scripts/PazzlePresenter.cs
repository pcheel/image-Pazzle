using UnityEngine;

public class PazzlePresenter
{
    private IPazzleModel _pazzleModel;
    private IPazzleView _pazzleView;
    private PazzleData _pazzleData;

    public PazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject generalCellPrefab, GameObject imageCellPrefab, IFactory factory)
    {
        _pazzleModel = pazzleModel;
        _pazzleView = pazzleView;
        _pazzleData = pazzleData;
        Enable();
        _pazzleView.SetImage(pazzleData.image);
        _pazzleModel.SetPazzleDataAndFactory(pazzleData, factory);
        _pazzleModel.CreateGrid(generalCellPrefab, _pazzleView.generalCellParent);
        _pazzleModel.SliceImage(imageCellPrefab, _pazzleView.imageCellParent);
    }

    private void Enable()
    {
        _pazzleModel.OnAspectRatioChangeAction += _pazzleView.SetAspectRatio;
        _pazzleModel.OnGridParametersChangeAction += _pazzleView.SetGridLayoutGroupParameters;
    }
}
