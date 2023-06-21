using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arsenal_du_joueur : MonoBehaviour
{
    public static arsenal_du_joueur kit { get; private set; }
    public GameObject arsenal;
    public List<GameObject> element = new List<GameObject>();
    public List<string> article = new List<string>();

    private void Awake()
    {
        if (kit == null)
            kit = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        Liste_des_outils();
    }

    private void Liste_des_outils()
    {
        foreach (Transform child in arsenal.transform)
        {
            if (child.CompareTag("QuickSlot"))
                element.Add(child.gameObject);
        }
    }

    public void ajouter_outil(GameObject equipement)
    {
        GameObject outil_dispo = Outil_suivant();
        if (outil_dispo == null)
            return;

        equipement.transform.SetParent(outil_dispo.transform, false);
        article.Add(equipement.name.Replace("(Clone)", ""));

        arsenal_du_joueur.Instance.ReCalculateList();
    }

    private GameObject Outil_suivant()
    {
        foreach (GameObject val in element)
        {
            if (val.transform.childCount == 0)
                return val;
        }

        return null;
    }

    public bool val_check()
    {
        int nb = 0;

        foreach (GameObject val in element)
        {
            if (val.transform.childCount > 0)
                nb += 1;
        }

        return nb == 7;
    }
}