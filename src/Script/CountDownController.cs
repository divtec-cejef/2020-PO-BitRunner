using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    // Démarre le script pour l'affichage 3,2,1, GO !
    private void Start()
    {
        StartCoroutine(CountdownToStart()); 
    }

    IEnumerator CountdownToStart()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<followCube>().Speed = -2.5f;
        // Change la couleur du 3,2,1 puis affiche GO
        while (countdownTime > 0)
        {
            if (countdownTime.Equals(3))
            {
                countdownDisplay.color = Color.red;
            }
            if (countdownTime.Equals(2))
            {
                countdownDisplay.color = Color.yellow;
            }

            if (countdownTime.Equals(1))
            {
                countdownDisplay.color = Color.green;
            }


           countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1.2f);

            countdownTime--;
        }

        countdownDisplay.color = Color.green;
        countdownDisplay.text = "GO !";

        player.GetComponent<followCube>().Speed = 8.0f;

        //.instance.BeginGame();

        yield return new WaitForSeconds(1f);

        // Enlève le texte après l'avoir afficher 1 seconde
        countdownDisplay.gameObject.SetActive(false);
    }

}