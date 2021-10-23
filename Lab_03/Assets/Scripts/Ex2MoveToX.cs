using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2MoveToX : MonoBehaviour
{
    public float speed = 2.0f;
    Rigidbody rb;
    bool turn = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(turn)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x >= 10.0f)
                turn = false;
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x <= 0.0f)
                turn = true;
        }
    }
}