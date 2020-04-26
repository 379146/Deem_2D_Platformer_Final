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
    [Range(0f,10f)]
    [SerializeField]
    private float jumpForce;



    private Rigidbody2D playerRigidbody;
    private bool isJumping;
    private bool isFacingRight = true;

    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody2D>();



    }





    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);

        if ((isFacingRight && horizontalInput < 0) || (!isFacingRight && horizontalInput > 0))
        {

            Flip();

        }
        




    }


    void FixedUpdate()
    { 
    
        //to do put physics code in here not update 
    
    }


    private void Flip()
    {

        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;
    
    }

}
