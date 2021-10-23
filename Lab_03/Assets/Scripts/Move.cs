using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10.0f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        // pobranie wartoœci zmiany pozycji w danej osi
        // wartoœci s¹ z zakresu [-1, 1]
        // kontroler ruchu dla osi jest pobierany z domyœlnych ustawieñ
        // Input Manager (preferences)
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        // tworzymy wektor prêdkoœci
        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;
        // wykonujemy przesuniêcie Rigidbody z uwzglêdnieniem si³ fizycznych
        rb.MovePosition(transform.position + velocity);
    }
}