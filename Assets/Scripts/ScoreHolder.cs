using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHolder : MonoBehaviour
{
    public int score = 0;
    public int shotsMissed = 0;
    public string rank;
    public TextMeshProUGUI scoreCounterText;
    public TextMeshProUGUI shotsMissedText;
    public TextMeshProUGUI rankText;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(ShowRank());
        shotsMissedText.text = "Shots missed: " + shotsMissed.ToString();
        scoreCounterText.text = "Creepy guys killed: " + score.ToString();
    }

    IEnumerator ShowRank()
    {       
        rankText.text = "RANK: " + CalculateRank();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(10f);
        Application.Quit();


    }

    private string CalculateRank()
    {
        if (shotsMissed > score && score < 50)
            return "D";
        else if (score >= 100 && shotsMissed > score)
            return "C";
        else if (score >= 100 && shotsMissed == 0)
            return "***S***";
        else if (score >= 50 && score - shotsMissed > 30)
            return "A";
        else if (score >= 50 && score - shotsMissed < 30)
            return "B";
        else
            return "Mhhm...";
    }

}
