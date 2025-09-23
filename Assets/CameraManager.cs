using UnityEngine;
using UnityEngine.Profiling;

public class CameraManager : MonoBehaviour
{
    InputManager inputManager;

    public Transform targetTransform;
    public Transform cameraPivot;
    private Vector3 cameraVelocity = Vector3.zero;

    public float cameraSpeed = 0.2f;
    public float cameraTurnSpeed = 2f;

    public float lookAngle;
    public float pivotAngle;
    public float minPivot = -35;
    public float maxPivot = 35;

    private void Awake()
    {
        inputManager = FindFirstObjectByType<InputManager>();
        targetTransform = FindFirstObjectByType<PlayerManager>().transform;
    }

    public void HandleCameraMovement()
    {
        FollowTarget();
        RotateCamera();
    }

    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraVelocity, cameraSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        lookAngle += (inputManager.cameraInputX * cameraTurnSpeed);
        pivotAngle -= (inputManager.cameraInputY * cameraTurnSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivot, maxPivot);

        Vector3 rotation = Vector3.zero;
        rotation.y = lookAngle;

        Quaternion targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;

        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }
}
