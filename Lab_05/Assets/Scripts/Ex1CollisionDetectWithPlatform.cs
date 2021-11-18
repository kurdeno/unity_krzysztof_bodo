using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex1CollisionDetectWithPlatform : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 14f;
    private bool isRunningAhead = true;
    private bool isRunningBack = false;
    private float startPosition;
    private float endPosition;

    void Start()
    {
        endPosition = transform.position.z + distance;
        startPosition = transform.position.z;
    }

    void Update()
    {
        if (isRunningAhead && transform.position.z >= endPosition)
        {
            isRunning = false;
        }
        else if (isRunningBack && transform.position.z <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.forward * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");

            if (transform.position.z >= endPosition)
            {
                isRunningBack = true;
                isRunningAhead = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= startPosition)
            {
                isRunningAhead = true;
                isRunningBack = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            other.gameObject.transform.parent = this.gameObject.transform;
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");
            other.gameObject.transform.parent = null;
        }
    }
}

