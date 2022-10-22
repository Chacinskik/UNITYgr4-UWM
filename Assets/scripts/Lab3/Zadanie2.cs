using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    public float speed = 5;
    public float distanceTravelled = 0;
    public bool is_forward = true;
    public Vector3 direction = Vector3.right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        distanceTravelled += speed/50;
        if (distanceTravelled >= 10)
        {
            distanceTravelled = 0;
            if (is_forward)
            {
                direction = Vector3.left;
                is_forward = false;
            }
            else
            {
                direction = Vector3.right;
                is_forward = true;
            }
        }
    }
}
