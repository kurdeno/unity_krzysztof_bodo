using UnityEngine;
using UnityEngine.Events;

public class EnemyController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 350f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private float m_delayGroundCheck = 0.25f;

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private float timeBeforeGroundCheck = 0f;

	public float A = -3;
	public float B = + 3;
	private string m_side = "right";
	private float radius = 3;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void Update()
	{
		if (!m_Grounded)
		{
			timeBeforeGroundCheck -= Time.deltaTime;
		}
	}

	private void FixedUpdate()
	{
		if (timeBeforeGroundCheck > 0f)
		{
			return;
		}
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

	public void Move(float move)
	{
		bool ifFlip = false;
		//Debug.Log(GameObject.FindGameObjectWithTag("Player").transform.position.x);
		//only control the player if grounded or airControl is turned on
		float distance = transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x;
		//Debug.Log(distance + " " + (GameObject.FindGameObjectWithTag("Player").transform.position.x > A && GameObject.FindGameObjectWithTag("Player").transform.position.x < B));
		if (Mathf.Abs(distance) < radius && (GameObject.FindGameObjectWithTag("Player").transform.position.x > A && GameObject.FindGameObjectWithTag("Player").transform.position.x < B))
		{ 
			if(m_side == "right" && distance>0)
            {
				ifFlip = true;
				move = -move * 1.5f;
				m_side = "left";
			}
			if (m_side == "left" && distance > 0)
			{
				move = -move * 1.5f;
			}
			if (m_side == "left" && distance < 0)
			{
				ifFlip = true;
				move = move * 1.5f;
				m_side = "right";
			}
			if (m_side == "right" && distance < 0)
			{
				move = move * 1.5f;
			}
		}
		else if (m_side == "right")
		{
			if (transform.position.x > B - 0.5)
			{
				ifFlip = true;
				move = -move;
				m_side = "left";
			}
		}
		else
		{
			if (transform.position.x < A + 0.5)
			{
				ifFlip = true;
				m_side = "right";
			}
			else
			{
				move = -move;
			}
		}
		if (ifFlip)
		{
			Flip();
		}
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			// If the input is moving the player right and the player is facing left...	
		}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}