using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public const float delay = 10.0f;

    // Récupère le score depuis un fichier externe
    void Start()
    {

        string score = PlayerPrefs.GetString("score");
        float monScore = float.Parse(score)*100;
        int monScoreEntier = (int)monScore;
        string monScoreString = monScoreEntier.ToString();
        scoreText.text = monScoreString;
        StartCoroutine(ExecuteAfterTime(delay));

    }

    // Décompte de temps
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Intro");
    }

}
