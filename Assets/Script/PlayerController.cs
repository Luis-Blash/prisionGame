using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer spr;
    private Rigidbody2D rb2d;
    private Animator anim;
    //publicas
    public float maxSpeed;
    public float speed;
    public bool grounded;
    public float jumpPower;
    public bool jump;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));// para indicar si es izquierda derecha (abs)
        anim.SetBool("Ground", grounded);
        anim.SetBool("Jump", jump);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(grounded) { jump = true;}
        }
    }

    void FixedUpdate()
    {
        Vector3 fixedVelocity = rb2d.velocity;
        fixedVelocity.x *= 0.75f;

        if (grounded) { rb2d.velocity = fixedVelocity; }

        float h = Input.GetAxis("Horizontal"); //movimiento por tecla

        rb2d.AddForce(Vector2.right * speed * h);
        // clamp es funcion matematica, para reducir el velocidad limite de un minimo y maximo
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }



        if (h < 0) { spr.flipX = false; }
        else if (h > 0) { spr.flipX = true; }
    }

    /*
     void OnCollisionStay2D(Collision2D col)
     {
         // suelo
         if (col.gameObject.tag == "Ground")
         {
             grounded = true;
         }
     }

     void OnCollisionExit2D(Collision2D col)
     {
         //suelo
         if (col.gameObject.tag == "Ground")
         {
             grounded = false;
         }
     }
     */
}
