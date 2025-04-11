using UnityEngine;

public class VRPlayerCollision : MonoBehaviour
{
    private Vector3 lastSafePosition;

    void Start()
    {
        lastSafePosition = transform.position;
    }

    void Update()
    {
        // Store the last safe position
        lastSafePosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            // Move the player back to the last safe position
            transform.position = lastSafePosition;
        }
    }
}
