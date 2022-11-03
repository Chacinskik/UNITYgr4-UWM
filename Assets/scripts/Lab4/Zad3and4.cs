using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3and4 : MonoBehaviour
{
    // ruch wok� osi Y b�dzie wykonywany na obiekcie gracza, wi�c
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    public float mouseYTotalMoved = 0f;
    public float sensitivity = 800f;

    void Start()
    {
        // zablokowanie kursora na �rodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy warto�ci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotacj� wok� osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamer� dla lokalnych koordynat�w
        // -mouseYMove aby unikn�� ofektu mouse inverse

        //zablokowanie obrotu g�ra-d� powy�ej 90 stopni
        if (mouseYTotalMoved > -90f && mouseYTotalMoved < 90f)
        {
            transform.Rotate(new Vector3(-mouseYMove, 0f, 0f), Space.Self);
            mouseYTotalMoved += -mouseYMove;
        }
        if (mouseYTotalMoved > 90f && mouseYMove>0f)
        {
            transform.Rotate(new Vector3(0f, 0f, 0f), Space.Self);
            mouseYTotalMoved += -mouseYMove;
        }
        if (mouseYTotalMoved < -90f && mouseYMove < 0f)
        {
            transform.Rotate(new Vector3(0f, 0f, 0f), Space.Self);
            mouseYTotalMoved += -mouseYMove;
        }
    }
}
