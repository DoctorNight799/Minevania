using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	Vector2 moveVector;
	private Rigidbody2D rb;

	private bool canFlip;
	private float xCord;
	public float speed = 10.0f;
    public float jumpForce = 5f;
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		moveVector.x = Input.GetAxisRaw("Horizontal");
		//moveVector.y = Input.GetAxis("Vertical");
		Jump();
		if (moveVector.x > 0 && canFlip)
			Flip();
		if (moveVector.x < 0 && !canFlip)
			Flip();
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }

	private void FixedUpdate()
	{
		
	}
	
	void Flip()
	{
		canFlip = !canFlip;
		transform.Rotate(0f, 180f, 0f);
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.velocity = new Vector2(transform.position.x, jumpForce);
	}
}