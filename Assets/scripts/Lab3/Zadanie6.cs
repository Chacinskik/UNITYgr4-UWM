using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    // Smooth towards the x axis of the target

    public Transform target;
    float smoothTime = 0.3f;
    float xVelocity = 0.0f;

    void FixedUpdate()
    {
        float newPosition = Mathf.SmoothDamp(transform.position.x, target.position.x, ref xVelocity, smoothTime);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
    }
}
