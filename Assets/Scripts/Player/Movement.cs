using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Transform GroundCheck;
	private Rigidbody2D rb;
	private Animator animator;
    Vector2 moveVector;

    public float speed, jumpForce, timeJump, checkRadius; 
	public LayerMask ground;
	public bool isGround;

    private bool canFlip, isJumping;
    private float timeJumpTrue;

    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		Anim();
        Jump();
		if (moveVector.x > 0 && canFlip || moveVector.x < 0 && !canFlip)
			Flip();
    }

	void FixedUpdate()
	{
        Walk();
    }

	void Anim(){
		animator.SetFloat("Walk?", Mathf.Abs(moveVector.x));
		animator.SetBool("Jump?", isJumping);
		animator.SetBool("Fall?", !isGround);
	}

	void Flip(){
		canFlip = !canFlip;
		transform.Rotate(0f, 180f, 0f);
	}

	void Walk()
	{
        moveVector.x = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

	void Jump()
	{
		//isGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, ground);
		isGround = Physics2D.OverlapBox(GroundCheck.position, GroundCheck.localScale, 0, ground);

		if (Input.GetKeyDown(KeyCode.Space) && isGround)
		{
			isJumping = true;
			timeJumpTrue = timeJump;
			rb.velocity = Vector2.up * jumpForce;
		}
		if (Input.GetKey(KeyCode.Space) && isJumping)
		{
			if (timeJumpTrue >= 0)
			{
				rb.velocity = Vector2.up * jumpForce;
				timeJumpTrue -= Time.deltaTime;
			}
			else
				isJumping = false;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			isJumping = false;
		}
    }
}