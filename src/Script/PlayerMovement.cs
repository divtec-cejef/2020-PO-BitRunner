using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Variable
    private Vector3 Jump = Vector3.zero;

    [Range(-2, 2)] public float value;
    public float speed = 10f;
    public float gravity = 20f;

    Animator anim;

    public const float squat = 0.5f;
    public const float stand = 1.0f;
    public const float delay = 1.0f;
    CharacterController controller;
    public float Speed;

    public float jumpSpeed = 8.0f;

    // Se lance au démarrage du programme
    void Start()
    {
        anim = GetComponent<Animator>();

        Jump = transform.forward;
        Jump = transform.TransformDirection(Jump);
        Jump *= Speed;

        controller = GetComponent<CharacterController>();

    }

    // Mets à jour à chaque frame
    void FixedUpdate()
    {
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);

    }

    void moveCharacter(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Mets à jour après chaque frame
    void LateUpdate()
    {

        // Défini la gravité et le mouvement du personnage
        Jump.y -= gravity * Time.deltaTime;
        controller.Move(Jump * Time.deltaTime);

        // Si la touche "d" est pressée
        // Déplace vers la droite
        if (Input.GetButtonDown("Right"))
        {
            if (value == 2)
            {
                return;
            }
            value += 2;
            moveCharacter(new Vector3(value, 0, 0));
        }

        // Si la touche "a" est pressée
        // Déplace vers la gauche
        if (Input.GetButtonDown("Left"))
        {
            if (value == -2)
            {
                return;
            }
            value -= 2;
            moveCharacter(new Vector3(value, 0, 0));
        }

        // Si la touche "espace" est pressée
        // Saute
        if (Input.GetButtonDown("Jump") && controller.isGrounded && transform.localScale.y == stand)
        {
            Jump.y = jumpSpeed;
            anim.SetTrigger("jump");
        }

        // Si la touche "s" est pressée
        // S'accroupi
        if (Input.GetButtonDown("Down") && controller.isGrounded)
        {
            StartCoroutine("Shoot");
        }

    }

    //Faire une pause dans le code pour que la hitbox s'adapte au joueur quand il se baisse
    IEnumerator Shoot()
    {
        controller.height = 0.5f;
        StartCoroutine(ExecuteAfterTime(delay));
        anim.SetTrigger("roll");
        yield return new WaitForSeconds(1);
        controller.height = 1.5f;
    }

    // Permet d'effectuer du code après un délai
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        transform.localScale = new Vector3(transform.localScale.x, stand, transform.localScale.z);
    }

    void ChangeAnimatorIdle(string trigger)
    {
        anim.SetTrigger(trigger);
    }
}
