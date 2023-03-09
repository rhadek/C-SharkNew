using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    private int i = 0;
    public CharacterController2D controller;
    public Animator animator;
    public AudioSource sword;
    public AudioSource fireballsound;
    public AudioSource spinjitzusound;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                i++;
                if (i % 2 == 0)
                {
                    animator.SetFloat("Spinjitzu", 0);
                    spinjitzusound.Stop();
                    
                }
                else
                {
                    animator.SetFloat("Spinjitzu", 1);
                    spinjitzusound.Play();
                    
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                fireballsound.Play();
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (animator.GetFloat("Spinjitzu") < 0.01)
                {
                    animator.SetFloat("Swording", 1);
                    sword.Play();
                }
                else
                {
                    animator.SetFloat("Swording", 0);
                }
            }
            else
            {
                animator.SetFloat("Swording", 0);
            }
        }
            
        

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
