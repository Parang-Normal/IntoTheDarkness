using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int CountdownTime = 3;

    private Text CountdownDisplay;

    private void Start()
    {
        CountdownDisplay = gameObject.GetComponent<Text>();
        CountdownDisplay.text = CountdownTime.ToString();

        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(CountdownTime > 0)
        {
            CountdownDisplay.text = CountdownTime.ToString();

            yield return new WaitForSeconds(1f);

            CountdownTime--;
        }

        CountdownDisplay.text = "Start!";

        yield return new WaitForSeconds(1f);

        GameManager.Instance.BeginGame();


        Destroy(gameObject);
    }
}
