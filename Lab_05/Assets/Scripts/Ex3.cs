using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex3 : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 14f;
    private bool isRunningAhead = true;
    private bool isRunningBack = false;
    private float startPosition;
    private float endPosition;
    public List<(float, float)> coordinates;
    private int header;
    private bool stop = false;
    private Vector3 direction; 

    void Start()
    {
        var x = transform.position.x;
        var z = transform.position.z;
        header = 1;
        direction = transform.forward;
        coordinates = new List<(float, float)>()
        {
            (x,z),
            (x,z+10),
            (x+10,z+10),
            (x+10,z+20)
        };
        endPosition = transform.position.z + distance;
        startPosition = transform.position.z;

    }

    void Update()
    {
        
        if(!stop && isRunning)
        {
            Debug.Log("X  " + Mathf.Abs(transform.position.x - coordinates[header].Item1) + " " + Mathf.Abs(transform.position.z - coordinates[header].Item2) + " | " + transform.position.x + " " + transform.position.z);
            if (Mathf.Abs(transform.position.x - coordinates[header].Item1) <= 0.1 && Mathf.Abs(transform.position.z - coordinates[header].Item2) <= 0.1)
            {
                header++;
                if (Mathf.Abs(transform.position.x - coordinates[header].Item1) > Mathf.Abs(transform.position.z - coordinates[header].Item2) && (transform.position.x - coordinates[header].Item1) > 0)
                {
                    Debug.Log("1----------------------------------------- " + header);
                    elevatorSpeed = -Mathf.Abs(elevatorSpeed);
                    direction = transform.right;
                }
                if (Mathf.Abs(transform.position.x - coordinates[header].Item1) > Mathf.Abs(transform.position.z - coordinates[header].Item2) && (transform.position.x - coordinates[header].Item1) < 0)
                {
                    Debug.Log("2-----------------------------------------  " + header + " " + (transform.position.x - coordinates[header].Item1) + " " + (transform.position.z - coordinates[header].Item2));
                    elevatorSpeed = Mathf.Abs(elevatorSpeed);
                    direction = transform.right;
                }
                if (Mathf.Abs(transform.position.x - coordinates[header].Item1) < Mathf.Abs(transform.position.z - coordinates[header].Item2) && (transform.position.z - coordinates[header].Item2) > 0)
                {
                    Debug.Log("3----------------------------------------- " + header);
                    elevatorSpeed = -Mathf.Abs(elevatorSpeed);
                    direction = transform.forward;
                }
                if (Mathf.Abs(transform.position.x - coordinates[header].Item1) < Mathf.Abs(transform.position.z - coordinates[header].Item2) && (transform.position.z - coordinates[header].Item2) < 0)
                {
                    Debug.Log("4----------------------------------------- " + header);
                    elevatorSpeed = Mathf.Abs(elevatorSpeed);
                    direction = transform.forward;
                }
                if (header >= coordinates.Count)
                {
                    stop = true;
                }
            }
        }

        if (!stop && isRunning)
        {
            Vector3 move = direction * elevatorSpeed * Time.deltaTime;
            //Debug.Log(header + " " + direction + " " + transform.position.x + " " + transform.position.z);
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszed³ na windê.");
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
            isRunning = false;
        }
    }
}

