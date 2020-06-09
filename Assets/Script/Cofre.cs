using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    public bool open, intro;
    public Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Open", open);
        if (intro)
        {
            if (!open)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    open = true;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        intro = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        intro = false;
    }
}
