using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _factoryPrefab;
    [SerializeField] private GameObject _imageInCollectionPrefab;
    [Header("Dependencies")]
    [SerializeField] private ImageCollectionData _imageCollection;
    [SerializeField] private Transform _imagesParent;
    [SerializeField] private GameObject _difficultySelectionPanel;

    private IFactory _factory;
    private Sprite _selectedImage;
    
    public void SelectImageAndShowPanel(Sprite image)
    {
        _selectedImage = image;
        _difficultySelectionPanel.SetActive(true);
    }
    public void CreatePazzleDataAndLoadPazzeScene(int size)
    {
        CreateAndSavePazzleData(size);
        SceneManager.LoadScene("Pazzle");
    }

    private void Awake() 
    {
        _factory = CreateFactory();
    }
    private void Start() 
    {
        CreateImages();
    }
    private IFactory CreateFactory()
    {
        GameObject factoryGO = Instantiate(_factoryPrefab, transform.parent);
        return factoryGO.GetComponent<IFactory>();
    }
    private void CreateImages()
    {
        foreach (var image in _imageCollection.images)
        {
            IImageInCollectionView imageInCollectionView = _factory.CreateImageInCollectionView(_imageInCollectionPrefab, _imagesParent);
            imageInCollectionView.SetImage(image);
            imageInCollectionView.OnClickOnImageAction += SelectImageAndShowPanel;
        }
    }
    private void CreateAndSavePazzleData(int size)
    {
        PazzleData pazzleData = new PazzleData(_selectedImage, size);
        string pazzleDataJson = JsonUtility.ToJson(pazzleData);
        string path = $"{Application.persistentDataPath}/PazzleData.json";
        System.IO.File.WriteAllText(path, pazzleDataJson);
    }
}
