using UnityEngine;

public interface IFactory
{
    public PazzleLoader CreatePazzleLoader();
    public IPazzleModel CreatePazzleModel();
    public IPazzleView CreatePazzleView(GameObject pazzleViewGO, Transform parent);
    public PazzlePresenter CreatePazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject generalCellPrefab, GameObject imageCellPrefab, IFactory factory);
    public CellView CreateCellView(GameObject cellViewGO, Transform parent);
    public IImageCellView CreateImageCellView(GameObject imageCellViewGO, Transform parent);
    public IImageInCollectionView CreateImageInCollectionView(GameObject imageInCollectionPrefab, Transform parent);
}
