using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement_du_joueur : MonoBehaviour
{

private CharacterController controller;

public float vitesse = 11f;

public float gravité = -8.81f * 2;

public float hauteur_du_saut = 9f;

public Transform detect_sol;

public float detect_distance = 0.4f;

public LayerMask detector;

private Vector3 velocity;

private bool isGrounded;

private void Start()
{
    controller = GetComponent<CharacterController>();
}

private void Update()
{
    isGrounded = Physics.CheckSphere(detect_sol.position, detect_distance, detector);

    if (isGrounded && velocity.y < 0)
    {
        velocity.y = -2f;
    }

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = transform.right * x + transform.forward * z;

    controller.Move(move * vitesse * Time.deltaTime);

    if (Input.GetButtonDown("Jump") && isGrounded)
    {
        velocity.y = Mathf.Sqrt(hauteur_du_saut * -2f * gravité);
    }

    velocity.y += gravité * Time.deltaTime;

    controller.Move(velocity * Time.deltaTime);
}
}
