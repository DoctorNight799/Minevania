using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	Vector2 moveVector;
	private Rigidbody2D rb;

	private bool canFlip;
	public float speed = 10.0f;
    public float jumpForce = 5f;

    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		moveVector.x = Input.GetAxis("Horizontal");
		Jump();
		if (moveVector.x > 0 && canFlip)
			Flip();
		if (moveVector.x < 0 && !canFlip)
			Flip();
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }

	void Flip()
	{
		canFlip = !canFlip;
		transform.Rotate(0f, 180f, 0f);
	}

	void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.AddForce(Vector2.up * jumpForce);
	}
}