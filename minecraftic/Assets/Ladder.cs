using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float climbSpeed = 5f;

    private bool isClimbing = false;
    private Rigidbody playerRigidbody;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Get the player's Rigidbody component
            playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                isClimbing = true;
                // Disable gravity to prevent the player from falling
                playerRigidbody.useGravity = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isClimbing = false;
            // Re-enable gravity
            playerRigidbody.useGravity = true;
        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            // Get the player's input for climbing up/down the ladder
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate the climb velocity based on the input and climb speed
            Vector3 climbVelocity = new Vector3(0f, verticalInput * climbSpeed, 0f);

            // Apply the climb velocity to the player's Rigidbody
            playerRigidbody.velocity = climbVelocity;
        }
    }
}