using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Si le personnage entre en collision avec un obstacle
    void OnTriggerEnter(Collider col)
    {
        GameObject player = GameObject.Find("Player");

        // Termine la partie et passe à l'outro si le joueur arrive à la ligne d'arrivée
        if (col.gameObject.tag == "Finish")
        {

            SceneManager.LoadScene("Outro");
        }
    }
}
