using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  
	[SerializeField] private LayerMask m_WhatIsGround;                         
	public Animator animator;

	const float k_GroundedRadius = .2f; 
	private bool m_Grounded;            
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 m_Velocity = Vector3.zero;

	public float A = -3;
	public float B = +3;
	private string m_side = "right";
	private float radius = 5;
	private float delay = 0f;

	private ScoreScript scoreScript;
	private GameObject scoreText;
	bool isDying = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		scoreText = GameObject.Find("ScoreText");
		scoreScript = scoreText.GetComponent<ScoreScript>();
	}

	public void Move(float move)
	{
		if (!isDying)
		{
			if (transform.position.y <= -8.0f)
			{
				Destroy(gameObject);
				scoreScript.scoreValue += 15;
			}
			bool ifFlip = false;
			float distance = transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x;
			if (Mathf.Abs(distance) < radius && (GameObject.FindGameObjectWithTag("Player").transform.position.x > A && GameObject.FindGameObjectWithTag("Player").transform.position.x < B))
			{
				if (m_side == "right" && distance > 0)
				{
					ifFlip = true;
					move = -move * 2.5f;
					m_side = "left";
				}
				if (m_side == "left" && distance > 0)
				{
					move = -move * 2.5f;
				}
				if (m_side == "left" && distance < 0)
				{
					ifFlip = true;
					move = move * 2.5f;
					m_side = "right";
				}
				if (m_side == "right" && distance < 0)
				{
					move = move * 2.5f;
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
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
		}
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals("Player") == true && !isDying)
		{
			isDying = true;
			animator.SetBool("IsDying", true);
			Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
				scoreScript.scoreValue += 15;
		}
	}
}
