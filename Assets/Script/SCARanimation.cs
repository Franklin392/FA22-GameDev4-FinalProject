using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCARanimation : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {   //shoot
            //animator.SetFloat("Gun", 2);
            animator.SetTrigger("Shot");
        }
        if (Input.GetKeyDown(KeyCode.R))
            {
            // reload
            //animator.SetFloat("Gun", 1);
            animator.SetTrigger("Rechange");
            Debug.Log("reload");
        }
        //if (Input.GetKey(KeyCode.Mouse1))
        //{
        //    if (Input.GetKey(KeyCode.Mouse0))
        //    {
        //        //animator.SetFloat("Gun", 3);
        //        animator.SetTrigger("Aim");
        //    }
        //}
    }
}
