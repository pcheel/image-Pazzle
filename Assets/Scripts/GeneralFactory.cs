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
    public PazzlePresenter CreatePazzlePresenter(IPazzleModel pazzleModel, IPazzleView pazzleView, PazzleData pazzleData, GameObject generalCellPrefab, GameObject imageCellPrefab, IFactory factory)
    {
        return new PazzlePresenter(pazzleModel, pazzleView, pazzleData, generalCellPrefab, imageCellPrefab, factory);
    }
    public CellView CreateCellView(GameObject cellViewPrefab, Transform parent)
    {
        GameObject cellViewGO = Instantiate(cellViewPrefab, parent);
        return cellViewGO.GetComponent<CellView>();
    }
    public IImageCellView CreateImageCellView(GameObject imageCellViewPrefab, Transform parent)
    {
        GameObject imageCellViewGO = Instantiate(imageCellViewPrefab, parent);
        return imageCellViewGO.GetComponent<IImageCellView>();
    }
    public IImageInCollectionView CreateImageInCollectionView(GameObject imageInCollectionPrefab, Transform parent) 
    {
        GameObject imageInCollectionGO = Instantiate(imageInCollectionPrefab, parent);
        return imageInCollectionGO.GetComponent<IImageInCollectionView>();
    }
}
