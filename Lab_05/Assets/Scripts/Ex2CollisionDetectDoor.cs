using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2CollisionDetectDoor : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private float distance ;
    private bool isRunningAhead = true;
    private bool isRunningBack = false;
    private float startPosition;
    private float endPosition;
    Collider other;

    void Start()
    {
        this.distance = GetComponent<MeshRenderer>().bounds.size.x;
        endPosition = transform.position.x + distance;
        startPosition = transform.position.x;
    }

    void Update()
    {
        if (isRunningAhead && transform.position.x >= endPosition)
        {
            var distance = Mathf.Sqrt(
                Mathf.Pow((this.other.transform.position.x - transform.position.x), 2)
                + Mathf.Pow((this.other.transform.position.z - transform.position.z), 2)
                );
            if (distance > 1.5f)
            {
                isRunningBack = true;
                isRunningAhead = false;
                elevatorSpeed = -elevatorSpeed;
                isRunning = true;
            }
            else
            {
                return;
            }
        }
        else if (isRunningBack && transform.position.x <= startPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.other = other;
           if (transform.position.x <= startPosition && isRunningBack)
            {
                isRunningAhead = true;
                isRunningBack = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }
}
