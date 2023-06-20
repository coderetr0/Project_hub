using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool porter_du_joueur;
    public string itemName;

    public string GetItemName()
    {
        return itemName;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && porter_du_joueur)
        {

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider accelerateur_de_particule)
    {
        if (accelerateur_de_particule.CompareTag("Player"))
        {
            porter_du_joueur = true;
        }
    }

    private void OnTriggerExit(Collider accelerateur_de_particule)
    {
        if (accelerateur_de_particule.CompareTag("Player"))
        {
            porter_du_joueur = false;
        }
    }
}
