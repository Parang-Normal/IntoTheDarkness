using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Text TitleText;
    public Text PercentText;
    public Slider ProgressBar;
    public string SceneName;
    public bool OnWake = false;

    private void OnEnable()
    {
        if (OnWake)
        {
            Change();
        }
    }

    public void Change()
    {
        StartCoroutine(LoadScene(SceneName));
    }

    public void Change(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            TitleText.text = "Loading...";
            PercentText.text = Mathf.Round(Mathf.Clamp01(asyncOperation.progress / 0.9f) * 100) + "%";
            ProgressBar.value = Mathf.Clamp01(asyncOperation.progress / 0.9f);

            if (asyncOperation.progress >= 0.9f)
            {
                TitleText.text = "Tap to continue";

                if (Input.touchCount > 0)
                {
                    TitleText.text = "Tapped!";
                    asyncOperation.allowSceneActivation = true;
                }
            }
            

            yield return null;
        }
    }
}
