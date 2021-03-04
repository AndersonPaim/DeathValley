using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeAnim : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ESTADO ANDAR
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }
        //ESTADO CORRER
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(animator.GetBool("isWalking") == true){
                animator.SetBool("isRunning", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
        }
        //ESTADO TIRO
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking", true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
