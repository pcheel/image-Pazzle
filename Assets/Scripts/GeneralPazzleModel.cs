using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneralPazzleModel : IPazzleModel
{
    private PazzleData _pazzleData;
    private IFactory _factory;
    private float _aspectRation;
    private Vector2 _cellSize;
    private List<CellView> _grid;
    private List<IImageCellView> _images;
    private const int MAX_IMAGE_SIZE = 1000;

    public Action<float> OnAspectRatioChangeAction {get;set;}
    public Action<Vector2, int> OnGridParametersChangeAction {get;set;}
    public Action OnWinAction {get;set;}

    public void SetPazzleDataAndFactory(PazzleData pazzleData, IFactory factory)
    {
        _factory = factory;
        _pazzleData = pazzleData;
        CalculateAspectRation();
        CalculateGridParameters();
    }
    public void CreateGrid(GameObject generalCellPrefab, Transform generalCellParent)
    {
        _grid = new List<CellView>();
        for (int i = 0; i < _pazzleData.size; i++)
        {
            for (int j = 0; j < _pazzleData.size; j++)
            {
                CellView cellView = _factory.CreateCellView(generalCellPrefab, generalCellParent);
                _grid.Add(cellView);
            }
        }
    }
    public void CheckWin()
    {
        for (int i = 0; i < _grid.Count; i++)
        {
            if (_grid[i].position != _images[i].position)
            {
                return;
            }
        }
        OnWinAction?.Invoke();
    }
    public void SliceImage(GameObject imageCellViewPrefab, Transform parent)
    {
        int tileWidth = _pazzleData.image.texture.width / _pazzleData.size;
        int tileHeight = _pazzleData.image.texture.height / _pazzleData.size;
        _images = new List<IImageCellView>();
        for (int i = 0; i < _pazzleData.size * _pazzleData.size; i++)
        {
            _images.Add(null);
        }
        for (int i = 0; i < _pazzleData.size; i++)
        {
            for (int j = 0; j < _pazzleData.size; j++)
            {
                Rect cellRect = new Rect(i * tileWidth, j * tileHeight, tileWidth, tileHeight);
                Sprite imageCell = Sprite.Create(_pazzleData.image.texture, cellRect, new Vector2(tileWidth / 2, tileHeight / 2));
                IImageCellView cellView = _factory.CreateImageCellView(imageCellViewPrefab, parent);
                Vector2 cellPosition = RandomImageCellPosition();
                cellView.Initialize(imageCell, _cellSize, cellPosition);
                cellView.OnEndOfDragAction += CheckWin;
                _images[(_pazzleData.size - j - 1) * _pazzleData.size + i] = cellView;
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
        _cellSize = new Vector2(newTileWidth, newTileHeight);
        OnGridParametersChangeAction?.Invoke(_cellSize, _pazzleData.size);
    }
    private Vector2 RandomImageCellPosition()
    {
        int x_left = UnityEngine.Random.Range((int)_cellSize.x - Screen.width, -(int)_cellSize.x - MAX_IMAGE_SIZE)/2;
        int x_right = UnityEngine.Random.Range(MAX_IMAGE_SIZE + (int)_cellSize.x, Screen.width - (int)_cellSize.x)/2;
        int x = UnityEngine.Random.Range(0,2) == 0 ? x_left : x_right;
        int y = UnityEngine.Random.Range((int)_cellSize.y - Screen.height, Screen.height - (int)_cellSize.y)/2;
        return new Vector2(x, y);
    }
}
