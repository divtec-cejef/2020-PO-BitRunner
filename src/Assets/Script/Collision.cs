using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Collision : MonoBehaviour
{

    // Constantes
    const float delay = 2;
    const float lowSpeed = -1.0f;
    const float basicSpeed = 5.0f;
    const float highSpeed = 8.0f;

    // Si le personnage entre en collision avec un obstacle ou un bonus
    void OnTriggerEnter(Collider col)
    {
        GameObject player = GameObject.Find("Player");

        // Diminue la vitesse du personnage quand il rentre dans un obstacle
        if (col.gameObject.tag == "Obstacle")
        {
            player.GetComponent<PlayerMovement>().Speed = lowSpeed;
            StartCoroutine(ExecuteAfterTime(delay));
        }

        // Augmente la vitesse du personnage quand il rentre dans un bonus
        if (col.gameObject.tag == "Bonus")
        {
            player.GetComponent<PlayerMovement>().Speed = highSpeed;
            StartCoroutine(ExecuteAfterTime(delay));
        }

        // Permet d'effectuer du code après un délai
        IEnumerator ExecuteAfterTime(float time)
        {
            yield return new WaitForSeconds(time);

            player.GetComponent<PlayerMovement>().Speed = basicSpeed;
        }
    }
}
