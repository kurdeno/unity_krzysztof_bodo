using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex4 : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        // aby w UnityEditor ponownie pojawi³ siê kursor (w³aœciwie deaktywowac kursor w trybie play)
        // wciskamy klawisz ESC
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * Time.deltaTime * 200;
        float limit = 0.7070027f;

        if (transform.position.x < limit && mouseYMove > 0)
        {
            Debug.Log(transform.rotation.x + " " + limit + " " + (transform.position.x < limit).ToString());
            transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
        }
        else if (transform.position.x > -limit && mouseYMove < 0)
        {
            Debug.Log(transform.rotation.x + " " + limit + " " + (transform.position.x < -limit).ToString());
            transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
        }  
    }
}