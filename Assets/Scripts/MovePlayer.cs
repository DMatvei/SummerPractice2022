using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Значения для бега
    public float speed = 1f;

    public bool isRight = true;

    // общие значения

    private Rigidbody2D rigidbody2;

    private Animator animator;


    //Значения для прыжка

    public float jumpForce = 2f;

    public bool isGrounded;

    public Transform groundCheck;

    private float groundRadius = 0.2f;

    public LayerMask whatIsGround;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	private void Update()
	{
        //прыжок через пробел
		if (isGrounded && Input.GetKeyDown(KeyCode.Space) && !Input.GetKeyDown(KeyCode.W))
		{
            animator.SetBool("Ground", false);

            rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
		}

        // прыжок через W
        /*if (isGrounded && Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Ground", false);

            rigidbody2.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }*/

       


    }


	private void FixedUpdate()
	{
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        animator.SetBool("Ground", isGrounded);

        animator.SetFloat("Vertical Speed", rigidbody2.velocity.y);
        if (!isGrounded) return;

        float moveX = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        rigidbody2.velocity = transform.TransformDirection(new Vector3(moveX, rigidbody2.velocity.y, 0));
        //transform.Translate(Vector2.right * speed * moveX * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(moveX));

        if (moveX < 0 && isRight)
        {
            Flip();
        }
        if (moveX > 0 && !isRight)
        {
            Flip();
        }
    }

	private void Flip()
	{
        isRight = !isRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z); 
	}
}
