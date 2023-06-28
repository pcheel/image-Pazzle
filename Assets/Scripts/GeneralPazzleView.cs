using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralPazzleView : MonoBehaviour, IPazzleView
{
    [Header("Dependencies")]
    [SerializeField] private AspectRatioFitter _aspectRationFitter;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;

    public Transform tileParent => _gridLayoutGroup.transform;

    public void SetAspectRatio(float newAspectRation)
    {
        _aspectRationFitter.aspectRatio = newAspectRation;
    }
    public void SetGridLayoutGroupParameters(Vector2 cellSize, int constraintCount)
    {
        _gridLayoutGroup.cellSize = cellSize;
        _gridLayoutGroup.constraintCount = constraintCount;
    }

    private void Awake() 
    {

    }
}
