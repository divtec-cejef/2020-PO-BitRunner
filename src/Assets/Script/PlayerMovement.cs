using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

    // Variable
    private Vector3 Jump = Vector3.zero;

    [Range(-2, 2)] public float value;
    public float gravity = 20f;

    public const float squat = 0.5f;
    public const float stand = 1.0f;
    public const float delay = 1.0f;
    

    private CharacterController controller;
    public float Speed;

    public float jumpSpeed = 8.0f;

    // Se lance au démarrage du programme
    void Start()
    {
        
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
                return;
            value += 2;

        }

        // Si la touche "a" est pressée
        // Déplace vers la gauche
        if (Input.GetButtonDown("Left"))
        {
            if (value == -2)
                return;
            value -= 2;
        }

        // Si la touche "espace" est pressée
        // Saute
        if (Input.GetButtonDown("Jump") && controller.isGrounded && transform.localScale.y == stand)
        {
            Jump.y = jumpSpeed;
        }

        // Si la touche "s" est pressée
        // S'accroupi
        if (Input.GetButtonDown("Down") && controller.isGrounded)
        {
            transform.localScale = new Vector3(transform.localScale.x, squat, transform.localScale.z);
            StartCoroutine(ExecuteAfterTime(delay));
        }

    }

    // Permet d'effectuer du code après un délai
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        transform.localScale = new Vector3(transform.localScale.x, stand, transform.localScale.z);
    }
}
