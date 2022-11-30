using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBooster : MonoBehaviour
{
    public GameObject player;
    public MoveWithCharacterController stats;
    public float jumpHeight;
    public float gravityValue;
    public Vector3 playerVelocity;
    public Vector3 playerVelocityStarting;

    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<MoveWithCharacterController>();
        gravityValue = stats.gravityValue;
        jumpHeight = stats.jumpHeight;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ex.4 Player jumped!!!!.");
            playerVelocity.y += Mathf.Sqrt(jumpHeight*5 * -3.0f * gravityValue);
            stats.playerVelocity.y = playerVelocity.y;
        }
        
    }
}
