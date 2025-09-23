using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform targetTransform;
    private Vector3 cameraVelocity = Vector3.zero;
    public float cameraSpeed = 0.2f;

    private void Awake()
    {
        targetTransform = FindFirstObjectByType<PlayerManager>().transform;
    }
    public void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraVelocity, cameraSpeed);
        transform.position = targetPosition;
    }
}
