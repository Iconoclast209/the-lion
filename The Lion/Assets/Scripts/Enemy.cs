using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float moveSpeed = 1;
    public float deathDelayTime = 1;


    private bool isMoving = true;
    private bool isFacingRight = false;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            MoveEnemy();
        }
            
    }

    void MoveEnemy()
    {
        //Move enemy back and forth until it hits a patrol wall, then reverse course
        if(isFacingRight)
        {
            //Move to the right
        
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            
        }
        else
        {
            //Move to the left
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if(isFacingRight)
        {
            FlipSprite();
            isFacingRight = false;
        }
        else
        {
            FlipSprite();
            isFacingRight = true;
        }
    }

    void FlipSprite()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Death()
    {
        Debug.Log("Enemy Killed!");

        //Flip Upside Down
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;

        //Move downwards to meet the ground
        Vector3 newPosition = transform.position;
        newPosition.y -= 0.4f;
        transform.position = newPosition;

        //Stop Movement
        isMoving = false;
        animator.SetBool("possumIsIdle", true);

        //Deactivate rigidbody
        GetComponent<Rigidbody2D>().simulated = false;


        //Disappear
        Invoke("DestroyThisEnemy", deathDelayTime);
    
        
    }

    private void DestroyThisEnemy()
    {
        Destroy(this.gameObject);
    }


}
