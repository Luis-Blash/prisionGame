using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovible : MonoBehaviour
{
    public Transform target;
    public float speed;

    private Vector3 star, end;
    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            star = transform.position;
            end = target.position;
        }
    }


    void FixedUpdate()
    {
        if (target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, fixedSpeed);
        }

        if (transform.position == target.position)
        {
            // si el target es igual al star ? (si la posicion final es igual al principio)
            target.position = (target.position == star) ? end : star;
        }
    }
}
