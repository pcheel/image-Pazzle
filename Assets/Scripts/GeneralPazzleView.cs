using UnityEngine;
using UnityEngine.UI;

public class GeneralPazzleView : MonoBehaviour, IPazzleView
{
    [Header("Dependencies")]
    [SerializeField] private AspectRatioFitter _aspectRationFitter;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;

    public Transform generalCellParent => _gridLayoutGroup.transform;
    public Transform imageCellParent => _gridLayoutGroup.transform.parent;

    public void SetAspectRatio(float newAspectRation)
    {
        _aspectRationFitter.aspectRatio = newAspectRation;
    }
    public void SetImage(Sprite image)
    {
        _aspectRationFitter.GetComponent<Image>().sprite = image;
    }
    public void SetGridLayoutGroupParameters(Vector2 cellSize, int constraintCount)
    {
        _gridLayoutGroup.cellSize = cellSize;
        _gridLayoutGroup.constraintCount = constraintCount;
    }
}
