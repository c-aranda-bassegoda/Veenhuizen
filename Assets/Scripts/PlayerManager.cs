using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        cameraManager = FindFirstObjectByType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleInput();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleCameraMovement(); 
    }
}
