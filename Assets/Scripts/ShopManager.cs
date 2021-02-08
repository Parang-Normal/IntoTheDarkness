using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text Coins;
    public Image Button1;
    public Image Button2;
    public Image Button3;

    private int cost;

    private void Start()
    {
        UpdateCoins();

        Button1.sprite = AssetLoader.Instance.BulletSprite1;
        Button2.sprite = AssetLoader.Instance.BulletSprite2;
        Button3.sprite = AssetLoader.Instance.BulletSprite3;
    }

    public void UpgradeWeapon(int weapon)
    {
        switch (weapon)
        {
            case 1:
                cost = PlayerPrefs.GetInt("Player_Coins") - 100;

                if (cost >= 0)
                {
                    PlayerPrefs.SetInt("Player_Coins", cost);
                    PlayerPrefs.SetInt("Arrow1_Amp", PlayerPrefs.GetInt("Arrow1_Amp", 0) + 2);
                }
                else
                {
                    Debug.Log("Not enough coins");
                }
                break;

            case 2:
                cost = PlayerPrefs.GetInt("Player_Coins") - 150;

                if(cost >= 0) 
                { 
                    PlayerPrefs.SetInt("Player_Coins", cost);
                    PlayerPrefs.SetInt("Arrow2_Amp", PlayerPrefs.GetInt("Arrow2_Amp", 0) + 3);
                }
                else
                {
                    Debug.Log("Not enough coins");
                }
                break;

            case 3:
                cost = PlayerPrefs.GetInt("Player_Coins") - 200;

                if(cost >= 0)
                {
                    PlayerPrefs.SetInt("Player_Coins", cost);
                    PlayerPrefs.SetInt("Arrow3_Amp", PlayerPrefs.GetInt("Arrow3_Amp", 0) + 4);
                }
                else
                {
                    Debug.Log("Not enough coins");
                }
                break;
        }

        UpdateCoins();
    }

    public void UpdateCoins()
    {
        Coins.text = "Coins: " + PlayerPrefs.GetInt("Player_Coins", 0).ToString();
    }
}
