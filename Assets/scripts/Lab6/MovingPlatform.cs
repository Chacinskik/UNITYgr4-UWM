using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] public List<Vector3> positions;
    public float speed = 5f;
    private bool isRunning = false;
    private bool isAtDestination = false;
    private int positionsLength;
    private int goTowardsIndex = 0;

    void Update()
    {
        if (isRunning)
        {
            var step = speed * Time.deltaTime;
            if (!isAtDestination)
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[goTowardsIndex], step);
                if (Vector3.Distance(transform.position, positions[goTowardsIndex]) <= 0.01f)
                {
                    if (goTowardsIndex < (positionsLength-1))
                    {
                        goTowardsIndex += 1;
                    }
                    if (goTowardsIndex == positionsLength-1)
                    {
                        isAtDestination = true;
                    }
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[goTowardsIndex], step);
                if (Vector3.Distance(transform.position, positions[goTowardsIndex]) <= 0.01f)
                {
                    if (goTowardsIndex > 0)
                    {
                        goTowardsIndex -= 1;
                    }
                    if (goTowardsIndex == -1)
                    {
                        isRunning = false;
                    }
                }
            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ex.3 Player uruchomi³ platformê.");
            isRunning = true;
            isAtDestination = false;
            goTowardsIndex = 0;
            positionsLength = positions.Count;
        }
    }
}
