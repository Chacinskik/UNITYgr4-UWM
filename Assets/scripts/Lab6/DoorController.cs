using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float doorSpeed = 10f;
    private bool isRunning = false;
    private bool isAtDestination = false;
    private Vector3 startPosition;
    [SerializeField] public Transform endPosition;
    public float distance;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isRunning)
        {
            var step = doorSpeed * Time.deltaTime;
            if (!isAtDestination)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition.position, step);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPosition, step);
            }


            if (Vector3.Distance(transform.position, endPosition.position) <= 0.01f)
            {
                isAtDestination = true;
                doorSpeed = 2f;
            }
            if (Vector3.Distance(transform.position, startPosition) <= 0.01f)
            {
                isRunning = false;
                isAtDestination = false;
                Debug.Log("Player zamkn¹³ drzwi.");
                doorSpeed = 10f;
            }
            distance = Vector3.Distance(transform.position, endPosition.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ex.2 Player otworzy³ drzwi.");
            isRunning = true;
        }
    }
}