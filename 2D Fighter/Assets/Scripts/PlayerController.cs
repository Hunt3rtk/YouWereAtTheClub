﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {



    public float speed;
    public float jumpForce;
    public float moveInput;
    public float fastFallForce;

    private Rigidbody2D rb;

    private bool facingRight = true;

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public Animator shieldAnimation;
    public Animator playerAnimation;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if(moveInput != 0 && isGrounded == true)
        {
            playerAnimation.SetBool("isRunning", true);
            Debug.Log("Running!");
        }
        else
        {
            playerAnimation.SetBool("isRunning", false);
        }


        //Sheild Stuff
        if (Input.GetKey(KeyCode.DownArrow) && isGrounded == true)
        {
            shieldAnimation.SetBool("isShielding", true);
        }
        else
        {
            shieldAnimation.SetBool("isShielding", false);
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.down * fastFallForce;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }    
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
