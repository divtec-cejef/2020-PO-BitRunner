using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Collision : MonoBehaviour
{

    // Constantes
    const float delayFreeze = 1;
    const float delay = 2;
    const float delayOP = 3;

    // Vitesse du personnage en colision
    const float freezeSpeed = -5.0f;
    const float lowSpeed = -1.0f;
    const float basicSpeed = 5.0f;
    const float highSpeed = 10.0f;
    const float veryHighSpeed = 20.0f;

    // Variables
    private int alreadyUsed = 0;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    // Si le personnage entre en collision avec un obstacle ou un bonus
    void OnTriggerEnter(Collider col)
    {
        GameObject player = GameObject.Find("Player");

        // Diminue la vitesse du personnage quand il rentre dans un obstacle
        if (col.gameObject.tag == "Obstacle" && player.GetComponent<followCube>().Speed != veryHighSpeed)
        {
            player.GetComponent<followCube>().Speed = lowSpeed;
            anim.SetTrigger("walk");
            StartCoroutine(ExecuteAfterTime(delay));
            Destroy(col.gameObject);
        }

        // Augmente la vitesse du personnage quand il rentre dans un bonus
        if (col.gameObject.tag == "Bonus" && player.GetComponent<followCube>().Speed != veryHighSpeed)
        {
            player.GetComponent<followCube>().Speed = highSpeed;
            StartCoroutine(ExecuteAfterTime(delay));
            Destroy(col.gameObject);
        }

        // Gêle la position du personnage quand il rentre dans un freeze
        if (col.gameObject.tag == "Freeze" && player.GetComponent<followCube>().Speed != veryHighSpeed)
        {
            player.GetComponent<followCube>().Speed = freezeSpeed;
            anim.SetTrigger("stop");
            StartCoroutine(ExecuteAfterTime(delayFreeze));
            Destroy(col.gameObject);
        }

        // Augmente grandement la vitesse du personnage quand il rentre dans un bonusJaune (jaune)
        // Immunise le personnage contre les autres objets (obstacle/bonus) durant la durée de l'effet
        if (col.gameObject.tag == "BonusJaune")
        {
            player.GetComponent<followCube>().Speed = veryHighSpeed;
            StartCoroutine(ExecuteAfterTime(delayOP));
            Destroy(col.gameObject);
        }

        // Permet d'effectuer du code après un délai
        IEnumerator ExecuteAfterTime(float time)
        {
            alreadyUsed++;
            yield return new WaitForSeconds(time);
            if (alreadyUsed == 1)
            {
                player.GetComponent<followCube>().Speed = basicSpeed;
            }
            alreadyUsed--;
        }
    }
}