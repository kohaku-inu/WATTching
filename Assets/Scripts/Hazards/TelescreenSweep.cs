using UnityEngine;

// Swings the telescreen left and right like a pendulum.
public class TelescreenSweep : MonoBehaviour
{
    [SerializeField] private TelescreenSettings settings;

    private Quaternion startRotation;

    private void Start()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        // Sin has a period of 2*PI; this makes one side take SecondsPerSide, slowing at the ends.
        float phase = Time.time * Mathf.PI / settings.SecondsPerSide;
        float angle = Mathf.Sin(phase) * settings.SweepAngle;
        transform.rotation = startRotation * Quaternion.Euler(0f, angle, 0f);
    }
}
