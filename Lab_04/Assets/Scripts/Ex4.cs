using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    public float sensitivity = 200f;
    private float mouseYMove = 0;
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
        float mouseXMove = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        mouseYMove = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        //Debug.Log(mouseYMove + " " + transform.rotation.eulerAngles.x);
        player.Rotate(Vector3.up * mouseXMove);
        if(mouseYMove>0 && ((transform.rotation.eulerAngles.x<=90)||(transform.rotation.eulerAngles.x > 315)))
        {
            transform.Rotate(new Vector3(-mouseYMove, 0f, 0f),Space.Self);
            if (transform.rotation.eulerAngles.x <315)
            {
                //transform.eulerAngles = new Vector3(315, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }
        else if(mouseYMove < 0 && ((transform.rotation.eulerAngles.x < 45) || (transform.rotation.eulerAngles.x > 270)))
        {
            transform.Rotate(new Vector3(-mouseYMove, 0f, 0f),Space.Self);
            if (transform.rotation.eulerAngles.x >= 45)
            {
                //transform.eulerAngles = new Vector3(45, transform.eulerAngles.y, transform.eulerAngles.z);
            }
        }

    }

    public static float Wrap(float value, float max, float min)
    {
        max -= min;
        if (max == 0)
            return min;
        return value - max * (float)Mathf.Floor((value - min) / max);
    }
}