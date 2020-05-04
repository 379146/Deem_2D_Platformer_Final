using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]


public class PlayerController : MonoBehaviour
{

    [Header("Ground Movement")]
    [Tooltip("Movement speed in tiles per second, one tile = one meter per second")]
    [SerializeField]
    private float speed;


    [Header("Air Movement")]
    [Tooltip("The upward force when a player jumps")]
    [Range(0f, 10f)]
    [SerializeField]
    private float jumpForce;



    private Rigidbody2D playerRigidbody;
    private bool isFacingRight = true;
    private bool isOnGround = true;
    new private Collider2D collider;
    private RaycastHit2D[] hits = new RaycastHit2D[16];
    private float groundDistanceCheck = .05f;
    private Animator animator;
    private float horizontalInput = 0;
    private bool isJumpPressed = false;

    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();

        collider = GetComponent<Collider2D>();

        animator = GetComponent<Animator>();

    }





    void Update()
    {

        horizontalInput += Input.GetAxis("Horizontal");
        isJumpPressed = isJumpPressed || Input.GetButtonDown("Jump");


    }

    private void ClearInputs()
    {

        horizontalInput = 0;
        isJumpPressed = false;
    
    }


    void FixedUpdate()
    {


        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);

        if ((isFacingRight && horizontalInput < 0) || (!isFacingRight && horizontalInput > 0))
        {

            Flip();

        }


        int numHits = collider.Cast(Vector2.down, hits, groundDistanceCheck);
        isOnGround = numHits > 0;


        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        Vector2 rayDirection = Vector2.down * groundDistanceCheck;
        //Debug.DrawRay(rayStart, rayDirection, Color.red, 1f);


        if (isJumpPressed && isOnGround)
        {

            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }


        animator.SetFloat("xSpeed", Mathf.Abs(playerRigidbody.velocity.x));
        animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
        animator.SetBool("isOnGround", isOnGround);

        ClearInputs();

    }


    private void Flip()
    {

        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;
    
    }

}
