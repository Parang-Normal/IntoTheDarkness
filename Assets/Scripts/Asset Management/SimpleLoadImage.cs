using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleLoadImage : MonoBehaviour
{
    public BundleManager loader;

    public Image holder;

    // Start is called before the first frame update
    void Start()
    {
        LoadPLayer();
        //Sprite Im = loader.GetAsset<Sprite>("texture", "Attack1");
        //holder.sprite = Im;
    }

    public void LoadPLayer()
    {
        AssetBundle tex = loader.LoadBundle("texture");
        AssetBundle anim = loader.LoadBundle("attack");
        //AssetBundle tex2 = loader.LoadBundle("Attack2");
        //AssetBundle tex3 = loader.LoadBundle("Attack3");
        //AssetBundle tex4 = loader.LoadBundle("Attack4");
       
        GameObject player = loader.GetAsset<GameObject>("prefab", "Enemy");
        Instantiate(player);
        if (player != null)
        {
            Debug.Log("loaded prefab");
        }

    }
}
