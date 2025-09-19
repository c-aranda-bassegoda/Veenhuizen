using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
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
}
