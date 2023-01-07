using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMovement : MonoBehaviour
{
    public BoyController boyControl; 
    public Animator animator;
    public float runSpeed = 50f;
    float horizontalMove = 0f;
     bool jump = false;
     bool crouch = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalB" ) * runSpeed;
        animator.SetFloat("SpeedB", Mathf.Abs(horizontalMove));
         if (Input.GetButtonDown("JumpB"))
        {
            jump = true;
            animator.SetBool("IsJumpingB", true);
        }
        if (Input.GetButtonDown("CrouchB"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("CrouchB"))
        {
            crouch = false;
        } 
    }
    public void OnLanding()
        {
            animator.SetBool("IsJumpingB", false);
        }
    void FixedUpdate() 
    {
         boyControl.Move(horizontalMove * Time.fixedDeltaTime , crouch, jump);
        jump = false; 
    }
}
