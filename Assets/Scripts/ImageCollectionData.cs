using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ImageCollectionData", menuName = "Data/ImageCollection", order = 51)]
public class ImageCollectionData : ScriptableObject
{
    public List<Sprite> images;
}
