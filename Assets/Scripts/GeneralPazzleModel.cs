using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralPazzleModel : IPazzleModel
{
    private PazzleData _pazzleData;
    private float _aspectRation;
    private Vector2 _tileSize;
    private const int MAX_IMAGE_SIZE = 1000;

    public Action<float> OnAspectRatioChangeAction {get;set;}
    public Action<Vector2, int> OnGridParametersChangeAction {get;set;}

    public void SetPazzleData(PazzleData pazzleData)
    {
        _pazzleData = pazzleData;
        CalculateAspectRation();
        CalculateGridParameters();
    }
    public void CreateGrid(GameObject tilePrefab, IFactory factory, Transform tileParent)
    {
        for (int i = 0; i < _pazzleData.size; i++)
        {
            for (int j = 0; j < _pazzleData.size; j++)
            {
                // CreateTile(tilePrefab, factory);
                factory.CreateTileView(tilePrefab, tileParent);
            }
        }
    }

    private void CalculateAspectRation()
    {
        _aspectRation = (float)_pazzleData.image.texture.width / _pazzleData.image.texture.height;
        OnAspectRatioChangeAction?.Invoke(_aspectRation);
    }
    private void CalculateGridParameters()
    {
        float scaling;
        int newTileWidth, newTileHeight;
        if (_pazzleData.image.texture.width >= _pazzleData.image.texture.height)
        {
            scaling = (float)MAX_IMAGE_SIZE / _pazzleData.image.texture.width;
            newTileWidth = MAX_IMAGE_SIZE / _pazzleData.size;
            newTileHeight = Mathf.CeilToInt(_pazzleData.image.texture.height * scaling / _pazzleData.size);
        }
        else
        {
            scaling = (float)MAX_IMAGE_SIZE / _pazzleData.image.texture.height;
            newTileHeight = MAX_IMAGE_SIZE / _pazzleData.size;
            newTileWidth = Mathf.CeilToInt(_pazzleData.image.texture.width * scaling / _pazzleData.size);
        }
        _tileSize = new Vector2(newTileWidth, newTileHeight);
        OnGridParametersChangeAction?.Invoke(_tileSize, _pazzleData.size);
    }
    // private void CreateTile(GameObject tilePrefab, IFactory factory)
    // {
    //     factory.Cre
    // }
}
