using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	public HealthScript health;
	public GameObject healthObj;

	void Strart()
    {
		healthObj = GameObject.Find("Health");
		health = healthObj.GetComponent<HealthScript>();
	}

	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			animator.SetBool("IsJumping", true);
			jump = true;
		}
		if(transform.position.y<=-8.0f)
        {
			health.DeleteLife();
		}
	}

	

	void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}
