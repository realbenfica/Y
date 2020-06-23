using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jen : MonoBehaviour
{
    //float horizontalMove = 0f;
    public float walkSpeed = 5f;
    public float runSpeed = 15f;
    public float jumpSpeed = 15f;
    public float climbSpeed = 5f;
    //public Vector2 deathKick = new Vector2(25f, 25f);

    // State
    //bool isAlive = true;

    // Cached component references
    Animator myAnimator;
    Rigidbody2D myRigidBody;
    //PolygonCollider2D myBodyCollider;
    //BoxCollider2D myFeet;
    //float gravityScaleAtStart;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        //myBodyCollider = GetComponent<PolygonCollider2D>();
        //gravityScaleAtStart = myRigidBody.gravityScale;
        //myFeet = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Walk();
        Jump();
        Run();
        FlipSprite();
        //if (!isAlive) { return; }
        //ClimbLadder();
        //Die();
    }

    private void Walk()
    {
        float controlThrow = Input.GetAxisRaw("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * walkSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        //bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", true);
        if (controlThrow == 0)
        {
            myAnimator.SetBool("isWalking", false);
        }
    }

    private void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            myAnimator.SetBool("isWalking", false);
            myAnimator.SetBool("isRunning", true);

            float controlThrow = Input.GetAxisRaw("Horizontal");
            Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
            myRigidBody.velocity = playerVelocity;

        } else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (!myRigidBody.IsTouchingLayers(LayerMask.GetMask("Background"))) { return; }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
            myAnimator.SetTrigger("jump");
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    //private void ClimbLadder()
    //{
    //    if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
    //    {

    //        myRigidBody.gravityScale = gravityScaleAtStart;
    //        return;
    //    }

    //    float controlThrow = Input.GetAxi   sRaw("Vertical");
    //    Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
    //    myRigidBody.velocity = climbVelocity;
    //    myRigidBody.gravityScale = 0f;


    //    bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;

    //}

    //private void Die()
    //{
    //    if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
    //    {
    //        isAlive = false;

    //        myRigidBody.velocity = deathKick;
    //    }
    //}
}
