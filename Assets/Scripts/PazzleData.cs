using UnityEngine;
using System;

[Serializable]
public class PazzleData
{
    public Sprite image;
    public int size;

    public PazzleData(Sprite image, int size) 
    {
        this.image = image;
        this.size = size;
    }
}
