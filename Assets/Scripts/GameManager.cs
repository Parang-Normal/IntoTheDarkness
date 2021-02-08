using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BundleManager bundleManager;
    public EnemySpawner enemyManager;

    public GameObject GameFinishPanel;
    public GameObject GameOverPanel;
    public Text Timer;
    public int clock = 300;
    public int EnvironmentNumber = 1;

    public int Score { get; private set; }
    public int Clock { get; private set; }

    private GameObject Bg;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Score = 0;
        Clock = clock;

        switch (EnvironmentNumber)
        {
            case 1: Bg = AssetLoader.Instance.Environment1; break;
            case 2: Bg = AssetLoader.Instance.Environment2; break;
            case 3: Bg = AssetLoader.Instance.Environment3; break;
            case 4: Bg = AssetLoader.Instance.Environment4; break;
        }
        Instantiate(Bg);
    }

    public void BeginGame()
    {
        enemyManager.gameObject.SetActive(true);
        StartCoroutine(Countdown());
    }

    public void AddScore(int value)
    {
        Score += value;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    IEnumerator Countdown()
    {
        while (Clock > 0)
        {
            yield return new WaitForSeconds(1);
            Clock--;

            Timer.text = "Timer: " + Clock.ToString();
        }

        if(Clock == 0)
        {
            Gamefinish();
        }
    }

    public void Gameover()
    {
        PauseGame();
        GameOverPanel.SetActive(true);
    }

    public void Gamefinish()
    {
        PauseGame();
        GameFinishPanel.SetActive(true);
        PlayerPrefs.SetInt("Player_Score", PlayerManager.Instance.Score);
        PlayerPrefs.SetInt("Player_Coins", PlayerManager.Instance.Coins);
    }
}
