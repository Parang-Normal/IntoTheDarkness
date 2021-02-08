using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System;

public class FBManager : MonoBehaviour
{
    public AdManager adManager;
    public GameObject UploadPanel;
    public Text ScoreText;
    public Text UploadText;
    public GameObject DoneButton;

    private void Start()
    {
        adManager.OnAdDone += AdManager_OnAdDone;    
    }

    private void AdManager_OnAdDone(object sender, AdFinishEventArgs e)
    {
        if (e.PlacementID == AdManager.SampleRewarded)
        {
            switch (e.AdShowResult)
            {
                case ShowResult.Failed: Debug.Log("Ad failed"); break;
                case ShowResult.Skipped: Debug.Log("Ad is skipped"); break;
                case ShowResult.Finished:
                    Debug.Log("Ad is finished properly");
                    Login();
                    break;
            }
        }
    }

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(OnInitDone, OnFBHide);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    public void OnInitDone()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("FB Initialized");
        }
        else
        {
            Debug.LogError("FB Not Initialized");
        }
    }

    public void OnFBHide(bool shown)
    {
        if (shown)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void Login()
    {
        if (FB.IsInitialized)
        {
            if (!FB.IsLoggedIn)
            {
                List<string> permission = new List<string>() { "public_profile", "email" };
                FB.LogInWithReadPermissions(permission, OnFBLoginDone);
            }
            else
            {
                Debug.Log("User is already logged in");
            }
        }
    }

    public void OnFBLoginDone(ILoginResult res)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Logged in!");
            Upload();
        }
        else
        {
            if (res.Cancelled)
            {
                Debug.Log("Login cancelled!");
            }
            Debug.LogError("Error logging in: " + res.Error);
        }
    }

    public void Upload()
    {
        StartCoroutine(UploadPhotoRoutine());
    }

    public void OnUploadDone(IGraphResult res)
    {
        if (string.IsNullOrEmpty(res.Error))
        {
            Debug.Log("Upload Done");
            UploadText.text = "Upload Done";
            DoneButton.SetActive(true);
        }
        else
        {
            Debug.LogError("Error " + res.Error);
            UploadText.text = "Error " + res.Error;
            DoneButton.SetActive(true);
        }
    }

    IEnumerator UploadPhotoRoutine()
    {
        adManager.HideBannerAd();
        UploadPanel.SetActive(true);
        ScoreText.text = PlayerManager.Instance.Score.ToString();
        yield return new WaitForEndOfFrame();
        Texture2D screen = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] screen_byte = screen.EncodeToPNG();

        WWWForm form = new WWWForm();
        form.AddBinaryData("image", screen_byte, "score.png");
        form.AddField("caption", "Game Score");

        string fb_url = "me/photos";
        FB.API(fb_url, HttpMethod.POST, OnUploadDone, form);
        
        Debug.Log("Uploading");
        UploadText.text = "Uploading...";
    }
}
