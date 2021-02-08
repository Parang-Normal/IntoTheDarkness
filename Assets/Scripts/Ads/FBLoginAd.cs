using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class FBLoginAd : MonoBehaviour
{
    public AdManager adManager;
    public FBManager fbManager;

    private void Start()
    {
        adManager.OnAdDone += AdManagaer_OnAdsDone;
    }

    private void AdManagaer_OnAdsDone(object sender, AdFinishEventArgs e)
    {
        if (e.PlacementID == AdManager.SampleInterstitial)
        {
            switch (e.AdShowResult)
            {
                case ShowResult.Failed: Debug.Log("Ad Failed"); break;
                case ShowResult.Skipped: 
                    Debug.Log("Ad Skipped");
                    fbManager.Login();
                    break;
                case ShowResult.Finished:
                    Debug.Log("Ad Finished");
                    fbManager.Login();
                    break;
            }
        }
    }
}
