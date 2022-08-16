using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Transform GroundCheck;
	private Rigidbody2D rb;
    Vector2 moveVector;

    public float speed, jumpForce, time_jump, check_radius; 
	public LayerMask ground;
	public bool is_ground;

    private bool canFlip, is_jumping;
    private float time_jump_true;

    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
        Jump();
		if (moveVector.x > 0 && canFlip || moveVector.x < 0 && !canFlip)
			Flip();
    }

	void FixedUpdate()
	{
        //Иначе он когда только начинает прыгать останавливается и только когда на половине прыжка начинает двигаться
        Walk();
    }

	void Flip()
	{
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
		is_ground = Physics2D.OverlapCircle(GroundCheck.position, check_radius, ground);

		if (Input.GetKeyDown(KeyCode.Space) && is_ground)
		{
			is_jumping = true;
			time_jump_true = time_jump;
			rb.velocity = Vector2.up * jumpForce;
		}
		if (Input.GetKey(KeyCode.Space) && is_jumping)
		{
			if (time_jump_true >= 0)
			{
				rb.velocity = Vector2.up * jumpForce;
				time_jump_true -= Time.deltaTime;
			}
			else
				is_jumping = false;
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			is_jumping = false;
		}
    }
}