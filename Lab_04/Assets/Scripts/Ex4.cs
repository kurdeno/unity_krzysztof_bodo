using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        // aby w UnityEditor ponownie pojawi� si� kursor (w�a�ciwie deaktywowac kursor w trybie play)
        // wciskamy klawisz ESC
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
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