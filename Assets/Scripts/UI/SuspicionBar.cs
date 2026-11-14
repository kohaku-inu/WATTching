using UnityEngine;
using UnityEngine.UI;

// Shows the suspicion meter as a bar, hidden until the player is first noticed (design doc).
// Put this on an always-active object (e.g. the Canvas), not on the slider it hides:
// a deactivated object's script stops listening and could never show the bar again.
public class SuspicionBar : MonoBehaviour
{
    [SerializeField] private SuspicionMeter meter;
    [SerializeField] private Slider slider;

    private bool revealed;

    private void OnEnable() => meter.ValueChanged += Show;
    private void OnDisable() => meter.ValueChanged -= Show;

    private void Start() => slider.gameObject.SetActive(false);

    private void Show(float value)
    {
        if (value > 0f)
            revealed = true;
        slider.gameObject.SetActive(revealed);
        slider.value = value;
    }
}
