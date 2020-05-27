using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public PlayerController player;
    private Rigidbody2D rb2d;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // plataformas movil
        if (col.gameObject.tag == "Platform")
        {
            //rb2d.velocity = new Vector3(0f, 0f, 0f);
            // para hacer que sea hijo de la plataforma
            player.transform.parent = col.transform;
            player.grounded = true;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        // suelo
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = true;
        }

        // plataformas movil
        if (col.gameObject.tag == "Platform")
        {
            // para hacer que sea hijo de la plataforma
            player.transform.parent = col.transform;
            player.grounded = true;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {
        //suelo
        if (col.gameObject.tag == "Ground")
        {
            player.grounded = false;
        }

        // plataforma movil
        if (col.gameObject.tag == "Platform")
        {
            // para volver a ser independiente
            player.transform.parent = null;
            player.grounded = false;
        }
    }
}
