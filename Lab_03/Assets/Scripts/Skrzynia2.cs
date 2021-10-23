using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skrzynia2 : MonoBehaviour
{
    [HideInInspector]
    public float force = 10.0f;

    [SerializeField]
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y == 0)
        {
            // dzia³amy si³¹ na cia³o A :)
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
