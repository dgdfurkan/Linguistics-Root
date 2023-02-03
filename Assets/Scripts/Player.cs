using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 12f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 deathKick = new Vector2(25f, 25f);

    private bool isAlive = true;

    [SerializeField] private Rigidbody2D myRigidBody;
    [SerializeField] private Animator myAnimator;
    [SerializeField] private CapsuleCollider2D myBodyCollider2D;
    [SerializeField] private BoxCollider2D myFeet;
    private float myGravityScaleAtStart;


    // Start is called before the first frame update
    void Start()
    {
        //myRigidBody = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
        //myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        //myFeet = GetComponent<BoxCollider2D>();
        myGravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            return;
        }

        Run();
        FlipSprite();
        Jump();
        ClimbLadder();
        Die();
    }

    private void Run()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        ///myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    private void Jump()
    {

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void ClimbLadder()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            ///myAnimator.SetBool("Climbing", false);
            myRigidBody.gravityScale = myGravityScaleAtStart;

        }
        else
        {
            float controlThrow = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
            myRigidBody.velocity = climbVelocity;
            myRigidBody.gravityScale = 0f;

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            ///myAnimator.SetBool("Climbing", playerHasVerticalSpeed);
        }
    }

    private void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Obstacles")))
        {
            isAlive = false;
            ///myAnimator.SetTrigger("Dying");
            myRigidBody.velocity = deathKick;
            //FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}