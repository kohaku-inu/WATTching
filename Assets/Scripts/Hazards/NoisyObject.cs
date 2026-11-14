using UnityEngine;

// Raises suspicion when this object is slammed into something.
[RequireComponent(typeof(Rigidbody))]
public class NoisyObject : MonoBehaviour
{
    private const float FloorNormalThreshold = 0.7f;   // contact normal.y above this = landing on the floor

    [SerializeField] private float loudImpactSpeed = 1.5f;     // m/s
    [SerializeField] private float suspicionPerNoise = 0.3f;   // fraction of the meter
    [SerializeField] private SuspicionMeter suspicion;
    [SerializeField] private AudioSource clangSound;           // optional

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsLoud(collision))
            return;

        suspicion.AddInstant(suspicionPerNoise);
        if (clangSound != null)
            clangSound.Play();
        Debug.Log($"CLANG: {name} hit {collision.collider.name} at {collision.relativeVelocity.magnitude:F1} m/s");
    }

    private bool IsLoud(Collision collision)
    {
        bool hardEnough = collision.relativeVelocity.magnitude >= loudImpactSpeed;
        bool hitByPlayer = collision.collider.GetComponent<PlayerMovement>() != null;   // that's the push itself
        bool landedOnFloor = collision.GetContact(0).normal.y > FloorNormalThreshold;
        return hardEnough && !hitByPlayer && !landedOnFloor;
    }
}
