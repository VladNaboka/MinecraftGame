using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraDistance = 10f;
    public float cameraHeight = 5f;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        if (playerTransform != null)
        {
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraHeight, playerTransform.position.z - cameraDistance);
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
            transform.LookAt(playerTransform.position);
        }
    }
}