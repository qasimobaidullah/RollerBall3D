using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 10f;  // Adjusted follow speed for smoother behavior
    public float rotationDamping = 2f;  // Rotation smoothing factor
    public Vector3 offset;

    void LateUpdate()
    {
        // Smooth camera movement towards the desired position
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Smooth camera rotation to follow player
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationDamping * Time.deltaTime);
    }
}
