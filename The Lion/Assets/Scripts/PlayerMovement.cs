using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 30f;
    public Animator animator;

    float horizontalMove = 0f;
    float initialRunSpeed;
    bool jump = false;
    bool crouch = false;
    private GameController gameController;

    private void Awake()
    {
        initialRunSpeed = runSpeed;
        gameController = FindObjectOfType<GameController>();
    }


    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("playerSpeed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch") || Input.GetAxisRaw("Vertical") < 0)
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch") || Input.GetAxisRaw("Vertical") >= 0)
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool boolIsCrouching)
    {
        animator.SetBool("isCrouching", boolIsCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    //This will allow player to kill enemies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //Kill the enemy
            other.GetComponentInParent<Enemy>().Death();
        }
        if(other.CompareTag("King"))
        {
            other.GetComponentInParent<Enemy>().Death();
            gameController.WinGame();
        }
        
    }

    public void PausePlayerControl()
    {
        runSpeed = 0f;
    }

    public void ResumePlayerControl()
    {
        runSpeed = initialRunSpeed;
    }

}
