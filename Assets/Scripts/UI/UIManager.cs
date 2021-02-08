using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public BundleManager loader;

    private GameObject UIPrefab;
    // Start is called before the first frame update
    void Start()
    {
        AssetBundle tex = loader.LoadBundle("uitexture");
        UIPrefab = loader.GetAsset<GameObject>("ui", "MainMenu");
        Instantiate(UIPrefab);
    }

    
}
