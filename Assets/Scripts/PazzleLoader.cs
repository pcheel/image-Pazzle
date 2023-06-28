using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PazzleLoader
{
    private string _pazzleJsonPath;

    public PazzleLoader()
    {
        _pazzleJsonPath = Application.persistentDataPath + "/PazzleData.json";
    }
    public PazzleData LoadPazzleData()
    {
        string pazzleJson = System.IO.File.ReadAllText(_pazzleJsonPath);
        return JsonUtility.FromJson<PazzleData>(pazzleJson);
    }
}
