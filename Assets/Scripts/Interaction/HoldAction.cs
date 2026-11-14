using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Completes an action after the player holds the interact button inside this trigger zone.
// Desk: countsAsCover ON (working is safe). Locker: OFF (sabotage).
public class HoldAction : MonoBehaviour
{
    [SerializeField] private float holdSeconds = 2f;
    [SerializeField] private bool countsAsCover = true;

    public event Action Completed;
    public event Action<float> ProgressChanged;   // 0..1, for the UI

    public bool IsAvailable { get; set; } = true;

    private PlayerMovement movement;
    private PlayerCover cover;
    private InputAction interactAction;
    private float progress;

    private void Awake()
    {
        interactAction = new InputAction("Interact", InputActionType.Button);
        interactAction.AddBinding("<Keyboard>/e");
        interactAction.AddBinding("<Gamepad>/buttonSouth");
    }

    private void OnEnable() => interactAction.Enable();
    private void OnDisable() => interactAction.Disable();

    private void OnTriggerEnter(Collider other) => TryCatchPlayer(other);

    // Also catches the player after a teleport, when Unity may skip the Enter event.
    private void OnTriggerStay(Collider other)
    {
        if (movement == null)
            TryCatchPlayer(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement leaving) && leaving == movement)
        {
            StopHolding();
            movement = null;
            cover = null;
        }
    }

    private void Update()
    {
        bool holding = movement != null && IsAvailable && interactAction.IsPressed();

        if (holding)
            ContinueHolding();
        else if (progress > 0f)
        {
            SetProgress(0f);
            StopHolding();
        }
    }

    private void ContinueHolding()
    {
        movement.CanMove = false;
        cover.IsOnTask = countsAsCover;
        SetProgress(progress + Time.deltaTime);

        if (progress >= holdSeconds)
        {
            SetProgress(0f);
            StopHolding();
            Completed?.Invoke();
        }
    }

    private void TryCatchPlayer(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement m) && other.TryGetComponent(out PlayerCover c))
        {
            movement = m;
            cover = c;
        }
    }

    private void SetProgress(float seconds)
    {
        progress = seconds;
        ProgressChanged?.Invoke(progress / holdSeconds);
    }

    private void StopHolding()
    {
        if (movement == null)
            return;
        movement.CanMove = true;
        cover.IsOnTask = false;
    }
}
