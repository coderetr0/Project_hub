using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Inventaire_du_joueur : MonoBehaviour
{
 
   public static Inventaire_du_joueur kit { get; private set; }
 
    public GameObject interface_ecran_dinventaire;
    public bool inventaire_ouvert_fermer;
 
    private void Awake()
    {
        if (kit == null)
        {
           kit = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
 
    private void Start()
    {
        inventaire_ouvert_fermer = false;
    }
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventaire_ouvert_fermer = !inventaire_ouvert_fermer;
            interface_ecran_dinventaire.SetActive(inventaire_ouvert_fermer);
        }
    }
}
