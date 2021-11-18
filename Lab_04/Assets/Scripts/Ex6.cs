using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex6 : MonoBehaviour
{
    // Start is called before the first frame update

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player zderzy³ siê ze œcian¹³.");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zderzy³ siê ze œcian¹³.");
        }
    }
}
