using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class followCube : MonoBehaviour
{
    public const float squat = 0.5f;
    public const float stand = 1.0f;
    public const float delay = 1.0f;

    [Range(-2, 2)] public float valueX;
    public GameObject kinectCube;
    public GameObject playerCube;
    public float Speed;
    public float speedF = 10f;
    
    public float gravity = 20f;
    private CharacterController controller;
    Animator anim;

    public float jumpSpeed = 8.0f;
    private Vector3 Jump = Vector3.zero;

    //Variables pour les mouvements
    private double roll = -3.5;
    private bool animRoll = false;
    private double jump = 1;
    private double left = -2.5;
    private double right = 2.5;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        Jump = transform.forward;
        Jump = transform.TransformDirection(Jump);
        Jump *= Speed;

        controller = GetComponent<CharacterController>();
        kinectCube.transform.position = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        playerCube.transform.position = new Vector3(valueX, transform.position.y, transform.position.z);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    void moveCharacter(Vector3 direction)
    {
        transform.Translate(direction * speedF * Time.deltaTime);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Défini la gravité et le mouvement du personnage
        Jump.y -= gravity * Time.deltaTime;
        controller.Move(Jump * Time.deltaTime);

        //Saut
        if (kinectCube.transform.position.y >= jump && controller.isGrounded && transform.localScale.y == stand)
        {
            Jump.y = jumpSpeed;
            anim.SetTrigger("jump");
            StartCoroutine(ExecuteAfterTime(delay));
            return;
        }

        //S'accroupir
        if (kinectCube.transform.position.y <= roll && controller.isGrounded)
        {
            if (!animRoll)
            {
                anim.SetTrigger("roll");
                animRoll = true;
            }
            StartCoroutine("Shoot");
            return;
        }

        //Ligne droite
        if (kinectCube.transform.position.x >= right)
        {
            if (valueX == 2)
                return;
            valueX += 2;
            moveCharacter(new Vector3(valueX, 0, 0));

        }

        //Ligne gauche
        if (kinectCube.transform.position.x <= left)
        {
            if (valueX == -2)
                return;
            valueX -= 2;
            moveCharacter(new Vector3(valueX, 0, 0));
        }
        
        //Ligne centrale
        if (kinectCube.transform.position.x <= 1.25 && kinectCube.transform.position.x >= -1.25)
        {
            if (valueX == 2 || valueX == -2)
            {
                valueX = 0;
                return;
            }
            moveCharacter(new Vector3(0, 0, 0));

        }

        if(controller.height == 1.5 && animRoll)
        {
            animRoll = false;
        }
        
    }

    //Faire une pause dans le code pour que la hitbox s'adapte au joueur quand il se baisse
    IEnumerator Shoot()
    {
        controller.height = 0.5f;
        StartCoroutine(ExecuteAfterTime(delay));
        yield return new WaitForSeconds(1);
        controller.height = 1.5f;
    }

    // Permet d'effectuer du code après un délai
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        transform.localScale = new Vector3(transform.localScale.x, stand, transform.localScale.z);
    }
}
