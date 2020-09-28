using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Chrono : MonoBehaviour
{
    public Text timerText;
    public float startTime;

    // Démarre le timer
    void Start()
    {
        startTime = Time.time;
    }

    // Modifie la valeur du timer
    void Update()
    {
        TextChange();
    }

    // Change le texte en fonction du temps écoulé depuis le début de la partie
    public void TextChange()
    {

        float score = Time.time - startTime;

        string minutes = ((int)score / 60).ToString();

        string seconds = (score % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

    }
}
