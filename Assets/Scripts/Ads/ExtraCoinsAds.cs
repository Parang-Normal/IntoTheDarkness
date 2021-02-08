using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ExtraCoinsAds : MonoBehaviour
{
    public AdManager adManager;
    public ShopManager shopManager;

    private void Start()
    {
        adManager.OnAdDone += AdManagaer_OnAdsDone;
    }

    private void AdManagaer_OnAdsDone(object sender, AdFinishEventArgs e)
    {
        if (e.PlacementID == AdManager.SampleRewarded)
        {
            switch (e.AdShowResult)
            {
                case ShowResult.Failed: Debug.Log("Ad Failed"); break;
                case ShowResult.Skipped: Debug.Log("Ad Skipped"); break;
                case ShowResult.Finished: Debug.Log("Ad Finished");
                    PlayerPrefs.SetInt("Player_Coins", PlayerPrefs.GetInt("Player_Coins", 0) + 50);
                    shopManager.UpdateCoins();
                    break;
            }
        }
    }

}
