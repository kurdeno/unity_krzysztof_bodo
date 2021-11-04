using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex6 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    [SerializeField] private LayerMask wallLayerMask;
    BoxCollider boxCollider;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        if(IsTouched())
        {
            Debug.Log("You touched a wall");
        }
    }

    private bool IsTouched()
    {
        return Physics.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, Vector3.forward,gameObject.transform.rotation, wallLayerMask);
    }
}