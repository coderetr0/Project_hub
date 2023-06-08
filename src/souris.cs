using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasouris : MonoBehaviour
{

float pos_x_souris;

float pos_y_souris;

private float sensibilite_souris = 70f;

private float rotation_x = 0f;

private float rotation_y = 0f;

private void main_function()
{
     Curseur_souris_activer();
}

private void Update()
{
    pos_x_souris = Input.GetAxis("Mouse X") * sensibilite_souris * Time.deltaTime;
    pos_y_souris = Input.GetAxis("Mouse Y") * sensibilite_souris * Time.deltaTime;
    rotation_x -= pos_y_souris;
    rotation_x = Mathf.Clamp(rotation_x, -90f, 90f);
    rotation_y += pos_x_souris;
    transform.localRotation = Quaternion.Euler(rotation_x, rotation_y, 0f);
}
private void Curseur_souris_activer()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}