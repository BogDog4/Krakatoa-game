using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        // Set the camera position to be a smoothed out version of the player's position
        Vector3 targetPosition = player.position;
        targetPosition.z = transform.position.z; // Keep the camera's z position unchanged
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}