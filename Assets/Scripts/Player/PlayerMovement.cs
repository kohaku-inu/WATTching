using UnityEngine;
using UnityEngine.InputSystem;

// Moves the player on the floor with a CharacterController.
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const float GroundedStickVelocity = -1f;   // keeps isGrounded reliable

    [SerializeField] private float walkSpeed = 1.8f;    // design doc: ~90 px/s, 1 unit = 50 px
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private InputAction moveAction;
    private float verticalVelocity;

    public bool CanMove { get; set; } = true;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        moveAction = new InputAction("Move", InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w").With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a").With("Right", "<Keyboard>/d");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow").With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow").With("Right", "<Keyboard>/rightArrow");
        moveAction.AddBinding("<Gamepad>/leftStick");
    }

    private void OnEnable() => moveAction.Enable();
    private void OnDisable() => moveAction.Disable();

    private void Update()
    {
        Vector3 direction = CanMove ? ReadDirection() : Vector3.zero;

        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = GroundedStickVelocity;
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = direction * walkSpeed + Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);

        if (direction.sqrMagnitude > 0.01f)
            transform.forward = direction;
    }

    // Moving a CharacterController's transform directly is overwritten next frame, so disable it first.
    public void Teleport(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }

    private Vector3 ReadDirection()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        return Vector3.ClampMagnitude(new Vector3(input.x, 0f, input.y), 1f);   // screen up = world +Z
    }
}
