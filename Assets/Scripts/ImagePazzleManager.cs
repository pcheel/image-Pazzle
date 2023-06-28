using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePazzleManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _pazzleViewPrefab;
    [SerializeField] private GameObject _tilePrefab;
    [Header("Dependencies")]
    [SerializeField] private Transform _pazzleViewParent;
    [SerializeField] Sprite _image;

    private IFactory _factory;
    private PazzleLoader _pazzleLoader;
    private PazzlePresenter _pazzlePresenter;

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void CreatePazzle(PazzleData pazzleData)
    {
        IPazzleModel pazzleModel = _factory.CreatePazzleModel();
        IPazzleView pazzleView = _factory.CreatePazzleView(_pazzleViewPrefab, _pazzleViewParent);
        _pazzlePresenter = _factory.CreatePazzlePresenter(pazzleModel, pazzleView, pazzleData, _tilePrefab, _factory);
    }
    private void Start() 
    {
        // _pazzleLoader = _factory.CreatePazzleLoader();
        // PazzleData pazzleData = _pazzleLoader.LoadPazzleData();
        PazzleData pazzleData = new PazzleData();
        pazzleData.image = _image;
        pazzleData.size = 6;
        CreatePazzle(pazzleData);
    }
    private void Awake() 
    {
        _factory = CreateFactory();
    }
}
