using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex5 : MonoBehaviour
{
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    private CharacterController controller;
    private void Update()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        if(controller!=null)
        {
            controller.Move(playerVelocity * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na platformê.");
            this.controller = other.gameObject.GetComponent <CharacterController>();
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }
}
