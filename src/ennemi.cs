using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
private Animator animator;

public float vitesse_interaction = 0.2f;

private Vector3 position_a_larret;

private float temps_de_marche;

public float compteur_marche;

private float temps_pause;

public float compteur_pause;

private int marche;

public bool perso_marche;

void Start()
{
    animator = GetComponent<Animator>();
    temps_de_marche = Random.Range(3, 6);
    temps_pause = Random.Range(5, 7);
    compteur_pause = temps_pause;
    compteur_marche = temps_de_marche;
    choix_de_direction();
}
void Update()
{
    if (perso_marche)
    {
        animator.SetBool("isRunning", true);

        compteur_marche -= Time.deltaTime;

        switch (marche)
        {
            case 0:
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                transform.position += transform.forward * vitesse_interaction * Time.deltaTime;
                break;
            case 1:
                transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                transform.position += transform.forward * vitesse_interaction * Time.deltaTime;
                break;
            case 2:
                transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                transform.position += transform.forward * vitesse_interaction * Time.deltaTime;
                break;
            case 3:
                transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                transform.position += transform.forward * vitesse_interaction * Time.deltaTime;
                break;
        }
        if (compteur_marche <= 0)
        {
            position_a_larret = transform.position;
            perso_marche = false;
            transform.position = position_a_larret;
            animator.SetBool("isRunning", false);
            compteur_pause = temps_pause;
        }
    }
    else
    {
        compteur_pause -= Time.deltaTime;

        if (compteur_pause <= 0)
        {
            choix_de_direction();
        }
    }
}

public void choix_de_direction()
{
    marche = Random.Range(0, 4);
    perso_marche = true;
    compteur_marche = temps_de_marche;
}
}
