using UnityEngine;

// Draws the telescreen's vision cone on the floor, red while it is raising suspicion.
[RequireComponent(typeof(LineRenderer))]
public class TelescreenBeamView : MonoBehaviour
{
    [SerializeField] private TelescreenVision vision;
    [SerializeField] private float heightAboveFloor = 0.05f;
    [SerializeField] private Color calmColor = Color.gray;
    [SerializeField] private Color alarmColor = Color.red;

    private LineRenderer line;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        line.useWorldSpace = true;
        line.loop = true;
        line.positionCount = 3;
    }

    // LateUpdate: after the sweep has rotated the screen this frame.
    private void LateUpdate()
    {
        Transform eye = vision.transform;
        Vector3 origin = new Vector3(eye.position.x, heightAboveFloor, eye.position.z);
        Vector3 forward = Vector3.ProjectOnPlane(eye.forward, Vector3.up).normalized * vision.Settings.Range;
        float halfAngle = vision.Settings.ViewAngle / 2f;

        line.SetPosition(0, origin);
        line.SetPosition(1, origin + Quaternion.Euler(0f, -halfAngle, 0f) * forward);
        line.SetPosition(2, origin + Quaternion.Euler(0f, halfAngle, 0f) * forward);

        Color color = vision.IsAlarmed ? alarmColor : calmColor;
        line.startColor = color;
        line.endColor = color;
    }
}
