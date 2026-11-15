using UnityEngine;

// PHYSICS REQUIREMENT COVERED HERE:
//   4. Raycast - line of sight. The cone says "could I see you", the ray says "is anything in the way".
//      That ray is WHY the shelter pillar and the archive walls hide you: no extra code needed.
//
// Setup: the object's blue arrow (local +Z, "forward") must point SOUTH, into the hall, at Play start.
public class Telescreen : MonoBehaviour
{
    [Header("Sweep (design doc: +-40 deg, 4 s per side)")]
    [SerializeField] private float sweepAngle = 40f;
    [SerializeField] private float secondsPerSide = 4f;

    [Header("Vision (design doc: 28 deg beam, ~330 px = 6.6 units)")]
    [SerializeField] private float viewAngle = 28f;      // FULL width of the cone
    [SerializeField] private float range = 6.6f;
    [SerializeField] private LayerMask sightMask = ~0;   // ~0 = "every layer" (bitwise NOT of 0, like in C)

    [Header("References (drag from the Hierarchy)")]
    [SerializeField] private PlayerController player;
    [SerializeField] private SuspicionMeter suspicion;
    [SerializeField] private LineRenderer beamLine;      // optional: draws the cone in the Game view

    private Quaternion startRotation;

    // "get; private set;" = anyone can read it, only this class can change it.
    public bool SeesPlayer { get; private set; }

    private void Start()
    {
        startRotation = transform.rotation;   // remember "straight south"
    }

    private void Update()
    {
        Sweep();

        SeesPlayer = CanSee(player.transform);

        // The core rule of the game in one line: being SEEN is fine, being seen OFF-TASK is not.
        if (SeesPlayer && !player.IsOnTask)
            suspicion.ReportSeen();

        DrawBeam();
    }

    private void Sweep()
    {
        // Sin goes -1 -> 1 -> -1 smoothly, and slows down at the ends exactly like a pendulum.
        // Period of Sin is 2*PI. Multiplying time by PI/secondsPerSide makes one full cycle
        // last 2*secondsPerSide = 8 s, i.e. 4 s on each side.
        float t = Time.time * Mathf.PI / secondsPerSide;
        float angle = Mathf.Sin(t) * sweepAngle;

        // Quaternion * Quaternion = "apply this rotation on top of that one". Rotate around Y (up axis).
        transform.rotation = startRotation * Quaternion.Euler(0f, angle, 0f);
    }

    private bool CanSee(Transform target)
    {
        Vector3 eye = transform.position;
        Vector3 toTarget = target.position - eye;

        // Step 1 - cone check, done on the flat floor plane (ignore height difference).
        Vector3 flatToTarget = new Vector3(toTarget.x, 0f, toTarget.z);
        Vector3 flatForward = new Vector3(transform.forward.x, 0f, transform.forward.z);

        if (flatToTarget.magnitude > range)
            return false;
        if (Vector3.Angle(flatForward, flatToTarget) > viewAngle / 2f)   // half each side of center
            return false;

        // Step 2 - RAYCAST: shoot an invisible ray from the screen toward the player.
        // 'out hit' = C# way to return a second value (like passing a pointer in C).
        // QueryTriggerInteraction.Ignore: trigger zones (desk, locker) are invisible areas; they must not block sight.
        if (Physics.Raycast(eye, toTarget.normalized, out RaycastHit hit,
                            toTarget.magnitude + 0.5f, sightMask, QueryTriggerInteraction.Ignore))
        {
            // The FIRST thing the ray hit. If it's the player -> seen. If it's a pillar/wall -> hidden.
            return hit.transform == target;
        }
        return false;
    }

    // Draws the cone as a triangle outline so the player can READ the hazard (design doc, risk #2).
    private void DrawBeam()
    {
        if (beamLine == null)
            return;

        Vector3 eye = transform.position;
        eye.y = 0.05f;   // just above the floor so it's visible from a top-down camera

        Vector3 flatForward = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;
        Vector3 leftEdge = Quaternion.Euler(0f, -viewAngle / 2f, 0f) * flatForward * range;
        Vector3 rightEdge = Quaternion.Euler(0f, viewAngle / 2f, 0f) * flatForward * range;

        beamLine.positionCount = 3;
        beamLine.loop = true;
        beamLine.SetPosition(0, eye);
        beamLine.SetPosition(1, eye + leftEdge);
        beamLine.SetPosition(2, eye + rightEdge);

        // Red ONLY when the screen is actually raising suspicion (seen AND off-task).
        // Seen while working stays gray: the design doc says the beam passes over you "harmlessly".
        bool dangerous = SeesPlayer && !player.IsOnTask;
        Color c = dangerous ? Color.red : Color.gray;
        beamLine.startColor = c;
        beamLine.endColor = c;
    }

    // Scene-view only helper (not in the build): select the telescreen to see its range.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
