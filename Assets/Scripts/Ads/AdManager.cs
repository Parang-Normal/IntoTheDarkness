using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public event EventHandler<AdFinishEventArgs> OnAdDone;

    public string GameID
    {
        get
        {
#if UNITY_ANDROID
            return "4002869";
#elif UNITY_IOS
            return "4002868";
#endif
        }
    }

    public const string SampleBanner = "Banner";
    public const string SampleRewarded = "Reward";
    public const string SampleInterstitial = "Interstitial";

    public bool Test;

    private void Start()
    {
        Advertisement.Initialize(GameID, true);
        Advertisement.AddListener(this);
    }

    public void ShowInterstitialAds()
    {
        if (Advertisement.IsReady(SampleInterstitial))
        {
            Advertisement.Show(SampleInterstitial);
        }
        else
        {
            Debug.Log("No ads!");
        }
    }

    public void ShowBannerAd()
    {
        StartCoroutine(ShowBannerAdRoutine());
    }

    public void HideBannerAd()
    {
        if (Advertisement.Banner.isLoaded)
        {
            Advertisement.Banner.Hide();
        }
    }

    IEnumerator ShowBannerAdRoutine()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(SampleBanner);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log($"Done Loading {placementId}");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log($"Ads error: {message}");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log($"Started Ad {placementId}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (OnAdDone != null)
        {
            AdFinishEventArgs args = new AdFinishEventArgs(placementId, showResult);
            OnAdDone(this, args);
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(SampleRewarded))
        {
            Advertisement.Show(SampleRewarded);
        }
        else
        {
            Debug.Log("No ads!");
        }
    }
}
