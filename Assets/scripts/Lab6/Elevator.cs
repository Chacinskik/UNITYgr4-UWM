using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 9.2f;
    private bool isRunningUp = true;
    private bool isRunningDown = false;
    private float downPosition;
    private float upPosition;

    void Start()
    {
        upPosition = transform.position.y + distance;
        downPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        if (isRunningUp && transform.position.y >= upPosition)
        {
            isRunning = false;
        }
        else if (isRunningDown && transform.position.y <= downPosition)
        {
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.up * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
        if (transform.position.y >= upPosition)
        {
            isRunningDown = true;
            isRunningUp = false;
            elevatorSpeed = -elevatorSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ex.1 Player wszed³ na windê.");

            if (transform.position.y <= downPosition)
            {
                isRunningUp = true;
                isRunningDown = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszed³ z windy.");

        }
    }
}