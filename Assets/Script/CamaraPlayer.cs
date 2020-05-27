using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    public Transform playerTransform;
    public float offsetX;
    public float offsetY;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //almacena la posicion actual de la camara en una variable temporal
        Vector3 temp = transform.position;

        //ponemos la camara en al posicion x sea igual a la posicion del jugador x
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        temp.x += offsetX;
        temp.y += offsetY;
        //fijamos el regreso de la camara temporal en la posicion de la camara actual
        transform.position = temp;
    }
}
