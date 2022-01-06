using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float JumpForce = 400f;							
	[Range(0, .3f)] [SerializeField] private float MovementSmoothing = .05f;	
	[SerializeField] private bool AirControl = false;							
	[SerializeField] private LayerMask WhatIsGround;							
	[SerializeField] private Transform GroundCheck;							

	const float GroundedRadius = .2f;
	private bool isGrounded = true;           
	private Rigidbody2D rigidbody2D;
	private bool FacingRight = true;  
	private Vector3 velocity = Vector3.zero;
	public Animator animator;
	private bool jumping = false;
	private int groundCheckDelay = 1;
	private int timeAfterJump = 0;


	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		if (jumping && !isGrounded) { 
			timeAfterJump++;
		}
		if(timeAfterJump>groundCheckDelay && jumping)
        {
			isGrounded = Grounded();
        }
		if(!jumping)
        {
			isGrounded = Grounded();
		}
	}


	public void Move(float move, bool jump)
	{

		if (isGrounded || AirControl)
		{
			if(isGrounded && jumping)
            {
				jumping = false;
				animator.SetBool("IsJumping", false);
			}
			Vector2 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

			rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, MovementSmoothing);

			if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
		}
		if (isGrounded && jump)
		{
			isGrounded = false;
			timeAfterJump = 0;
			jumping = true;
			rigidbody2D.AddForce(new Vector2(0f, JumpForce));
		}
	}

	

	bool Grounded()
    {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
		if (colliders.Length > 0)
			return true;
		else
			return false;
	}
	private void Flip()
	{
		FacingRight = !FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
