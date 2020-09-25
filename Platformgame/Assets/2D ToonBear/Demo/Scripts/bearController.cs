using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//This Script is intended for demoing and testing animations only.


public class bearController : MonoBehaviour {

	private float HSpeed = 10f;
	//private float maxVertHSpeed = 20f;
	private bool facingRight = true;
	private float moveXInput;

    //Used for flipping Character Direction
	public static Vector3 theScale;

	//Jumping Stuff
	public Transform groundCheck;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private float groundRadius = 0.15f;
	private float jumpForce = 14f;

	private Animator anim;

	// Use this for initialization
	void Awake ()
	{
//		startTime = Time.time;
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate ()
	{

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("ground", grounded);


	}

	void Update()
	{

        moveXInput = Input.GetAxis("Horizontal");

        if ((grounded) && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("ground", false);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.y, jumpForce);
        }


        anim.SetFloat("HSpeed", Mathf.Abs(moveXInput));
        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


        GetComponent<Rigidbody2D>().velocity = new Vector2((moveXInput * HSpeed), GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetButtonDown("Fire1") && (grounded)) { anim.SetTrigger("Punch"); }

        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Sprint", true);
            HSpeed = 14f;
}
        else
        {
            anim.SetBool("Sprint", false);
            HSpeed = 10f;
        }

        //Flipping direction character is facing based on players Input
        if (moveXInput > 0 && !facingRight)
            Flip();
        else if (moveXInput < 0 && facingRight)
            Flip();
    }
    ////Flipping direction of character
    void Flip()
	{
		facingRight = !facingRight;
		theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
