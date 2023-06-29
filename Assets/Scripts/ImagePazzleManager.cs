using UnityEngine;
using UnityEngine.SceneManagement;

public class ImagePazzleManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _pazzleViewPrefab;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private GameObject _imageCellPrefab;
    [Header("Dependencies")]
    [SerializeField] private Transform _pazzleViewParent;
    [SerializeField] Sprite _image;
    [SerializeField] private GameObject _winPanel;

    private IFactory _factory;
    private PazzleLoader _pazzleLoader;
    private PazzlePresenter _pazzlePresenter;

    public void ReplayGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit() 
    {
        Application.Quit();
    }
    public void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void CreatePazzle(PazzleData pazzleData)
    {
        IPazzleModel pazzleModel = _factory.CreatePazzleModel();
        IPazzleView pazzleView = _factory.CreatePazzleView(_pazzleViewPrefab, _pazzleViewParent);
        _pazzlePresenter = _factory.CreatePazzlePresenter(pazzleModel, pazzleView, pazzleData, _cellPrefab, _imageCellPrefab, _factory);
        pazzleModel.OnWinAction += ShowWinPanel;
    }
    private void Start() 
    {
        PazzleData pazzleData = LoadPazzleData();
        CreatePazzle(pazzleData);
    }
    private void Awake() 
    {
        _factory = CreateFactory();
    }
    private PazzleData LoadPazzleData() 
    {
        string path = $"{Application.persistentDataPath}/PazzleData.json";
        string pazzleDataJson = System.IO.File.ReadAllText(path);
        return JsonUtility.FromJson<PazzleData>(pazzleDataJson);
    }
}
