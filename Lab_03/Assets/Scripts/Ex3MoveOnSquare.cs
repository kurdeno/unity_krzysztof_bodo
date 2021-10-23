using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex3MoveOnSquare : MonoBehaviour
{
    public float speed = 4.0f;
    Rigidbody rb;
    int turn = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(turn ==0)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 10.0f)
            {
                turn = 1;
                transform.Rotate(0, 270, 0, Space.Self);
            }
                
        }
        if (turn == 1)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.z >= 10.0f)
            {
                turn = 2;
                transform.Rotate(0, 270, 0, Space.Self);
            }

        }
        if (turn == 2)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= 0.0f)
            {
                turn = 3;
                transform.Rotate(0, 270, 0, Space.Self);
            }

        }
        if (turn == 3)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.z <=0.0f)
            {
                turn = 0;
                transform.Rotate(0, 270, 0, Space.Self);
            }

        }
    }
}