using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad3and4 : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;
    public float mouseYTotalMoved = 0f;
    public float sensitivity = 800f;

    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // pobieramy wartoœci dla obu osi ruchu myszy
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // wykonujemy rotacjê wokó³ osi Y
        player.Rotate(Vector3.up * mouseXMove);

        // a dla osi X obracamy kamerê dla lokalnych koordynatów
        // -mouseYMove aby unikn¹æ ofektu mouse inverse

        //zablokowanie obrotu góra-dó³ powy¿ej 90 stopni
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
