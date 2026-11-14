using UnityEngine;

// Tuning data for one kind of telescreen. A new kind of screen = a new asset, no code change.
[CreateAssetMenu(fileName = "TelescreenSettings", menuName = "WATTching/Telescreen Settings")]
public class TelescreenSettings : ScriptableObject
{
    [Header("Sweep")]
    [SerializeField, Tooltip("Degrees to each side of the starting direction")]
    private float sweepAngle = 40f;
    [SerializeField] private float secondsPerSide = 4f;

    [Header("Vision")]
    [SerializeField, Tooltip("Full width of the vision cone, in degrees")]
    private float viewAngle = 28f;
    [SerializeField, Tooltip("Units. Design doc: 330 px = 6.6 units")]
    private float range = 6.6f;

    public float SweepAngle => sweepAngle;
    public float SecondsPerSide => secondsPerSide;
    public float ViewAngle => viewAngle;
    public float Range => range;
}
