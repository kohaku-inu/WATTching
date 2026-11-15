using UnityEngine;
using UnityEngine.InputSystem;

// PHYSICS REQUIREMENTS COVERED HERE:
//   1. CharacterController  (kinematic character - we move it ourselves, physics doesn't push it)
//   2. AddForce             (the player shoves Rigidbodies it walks into: the cart, the archive door)
//
// RequireComponent = Unity auto-adds a CharacterController when you add this script,
// and refuses to let you remove it. Prevents the classic "NullReferenceException" from a missing component.
//
// Using built in class - character controller - for a precise game-y movement (other ways for movement: transform directly, rigidbody - get pushed)
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 1.8f;   // units/s. Design doc: ~90 px/s, with 1 unit = 50 px
    [SerializeField] private float pushForce = 40f;    // Newtons applied while touching a Rigidbody
    [SerializeField] private float gravity = -9.81f;

    private CharacterController controller;
    private float verticalVelocity;   // CharacterController has NO gravity of its own

    // INPUT SYSTEM: an InputAction = "a meaning" (Move) separated from "which keys" (bindings).
    // Gameplay code asks "what is Move's value?", never "is W pressed?". Rebinding later = no code change.
    private InputAction moveAction;

    // C# PROPERTIES: a field with built-in getter/setter.
    // "{ get; set; }" auto-generates a hidden backing field (in Java we create property and method for get&set ). "= true" is the initial value.
    public bool CanMove { get; set; } = true;    // while player acts (hold E) HoldAction sets false
    public bool IsOnTask { get; set; }           // true = doing your job, so the telescreen ignores you

    // Awake runs once, before Start, when the object is created. Good place to cache components.
    private void Awake()
    {
        controller = GetComponent<CharacterController>();

        moveAction = new InputAction("Move", InputActionType.Value);

        // "2DVector" composite = combine 4 buttons into one Vector2. It also normalizes diagonals.  x = left/right, y = up/down.
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
        moveAction.AddBinding("<Gamepad>/leftStick");   // free gamepad support
    }

    // EDGE CASE: an InputAction does NOTHING until enabled. Forgetting Enable() = "my input reads 0".
    // OnEnable/OnDisable pair = it also stops listening when the player object is disabled or destroyed.
    // => means is just "onEnable is just moveAction.Enable()"
    private void OnEnable()  => moveAction.Enable();
    private void OnDisable() => moveAction.Disable();

    // Update runs every rendered frame.
    private void Update()
    {
        Vector3 input = Vector3.zero;
        if (CanMove)
        {
            // ReadValue<T> = generic method (like Java generics): "give me this action's value as a Vector2".
            Vector2 stick = moveAction.ReadValue<Vector2>();
            // Top-down: screen up/down (y) becomes world forward/back (z).
            input = new Vector3(stick.x, 0f, stick.y);
            // Safety net: keeps length <= 1 (a gamepad stick can report slightly over 1 diagonally).
            input = Vector3.ClampMagnitude(input, 1f);
        }

        // Gravity: keep a small downward push when grounded so isGrounded stays reliable.
        if (controller.isGrounded && verticalVelocity < 0f)
            verticalVelocity = -1f;
        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = input * walkSpeed + Vector3.up * verticalVelocity;

        // THE CharacterController call. Move() slides along walls but never gets pushed back by physics.
        // Multiply by deltaTime so speed is "per second", not "per frame" (60 fps vs 144 fps = same speed).
        controller.Move(velocity * Time.deltaTime);

        // Face the walking direction (only if actually moving, otherwise forward = (0,0,0) -> warning).
        if (input.sqrMagnitude > 0.01f)
            transform.forward = input;
    }

    // Unity calls this automatically whenever controller.Move() bumps into a collider.
    // A CharacterController does NOT push Rigidbodies by itself - this is the standard way to do it.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // Walls/floor have no Rigidbody; kinematic bodies ignore forces. Skip both.
        if (body == null || body.isKinematic)
            return;

        // Don't push things we're standing ON. The surface normal of a floor/top points UP.
        // BUG FIX: the old check used moveDirection.y, but moveDirection includes our constant
        // gravity push (-1), so while walking it was always about -0.5 and EVERY push was skipped.
        if (hit.normal.y > 0.7f)
            return;

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);
        if (pushDirection.sqrMagnitude < 0.0001f)
            return;
        pushDirection.Normalize();   // length 1, so pushForce alone decides the strength

        // This is called every frame we keep touching it. An Impulse of (force * deltaTime) per frame
        // adds up to a steady "force" no matter the frame rate. (Plain ForceMode.Force from Update would
        // push harder on faster PCs.)
        body.AddForce(pushDirection * pushForce * Time.deltaTime, ForceMode.Impulse);
    }

    // EDGE CASE: setting transform.position on a CharacterController often gets overwritten
    // by the controller on the next frame. Disable -> move -> enable is the reliable fix.
    public void Teleport(Vector3 position)
    {
        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }
}
