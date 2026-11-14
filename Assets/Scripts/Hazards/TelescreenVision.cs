using UnityEngine;

// Reports the player to the suspicion meter when it sees them off-task.
public class TelescreenVision : MonoBehaviour
{
    [SerializeField] private TelescreenSettings settings;
    [SerializeField] private LayerMask sightMask = ~0;
    [SerializeField] private PlayerCover target;
    [SerializeField] private SuspicionMeter suspicion;

    public TelescreenSettings Settings => settings;
    public bool SeesPlayer { get; private set; }
    public bool IsAlarmed => SeesPlayer && !target.IsOnTask;

    private void Update()
    {
        SeesPlayer = CanSee(target.transform);
        if (IsAlarmed)
            suspicion.ReportSeen();
    }

    // Cone check first (cheap), then a Raycast so walls and pillars block the view.
    private bool CanSee(Transform other)
    {
        Vector3 toTarget = other.position - transform.position;
        Vector3 flatToTarget = Vector3.ProjectOnPlane(toTarget, Vector3.up);
        Vector3 flatForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up);

        if (flatToTarget.magnitude > settings.Range)
            return false;
        if (Vector3.Angle(flatForward, flatToTarget) > settings.ViewAngle / 2f)
            return false;

        // Triggers are ignored: invisible zones (desk, locker) must not block sight.
        bool hitSomething = Physics.Raycast(transform.position, toTarget.normalized, out RaycastHit hit,
                                            toTarget.magnitude + 0.5f, sightMask, QueryTriggerInteraction.Ignore);
        return hitSomething && hit.transform == other;
    }

    private void OnDrawGizmosSelected()
    {
        if (settings == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, settings.Range);
    }
}
