using UnityEngine;

// Pushes Rigidbodies the player walks into (a CharacterController doesn't push anything by itself).
[RequireComponent(typeof(CharacterController))]
public class PlayerPusher : MonoBehaviour
{
    private const float StandingOnThreshold = 0.7f;   // surface normal.y above this = a floor/top, not a side

    [SerializeField] private float pushForce = 40f;   // Newtons while touching

    // Unity calls this on every component of this GameObject when controller.Move() hits a collider.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic || hit.normal.y > StandingOnThreshold)
            return;

        Vector3 direction = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);
        if (direction.sqrMagnitude < 0.0001f)
            return;

        // Called every frame of contact: impulse * deltaTime = a steady force, independent of frame rate.
        body.AddForce(direction.normalized * pushForce * Time.deltaTime, ForceMode.Impulse);
    }
}
