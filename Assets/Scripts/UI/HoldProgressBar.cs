using UnityEngine;
using UnityEngine.UI;

// Shows how far along the current hold action is. Optional; one bar can serve several zones.
// Like SuspicionBar, place it on an always-active object, not on the slider itself.
public class HoldProgressBar : MonoBehaviour
{
    [SerializeField] private HoldAction[] sources;
    [SerializeField] private Slider slider;

    private void OnEnable()
    {
        foreach (HoldAction source in sources)
            source.ProgressChanged += Show;
    }

    private void OnDisable()
    {
        foreach (HoldAction source in sources)
            source.ProgressChanged -= Show;
    }

    private void Start() => slider.gameObject.SetActive(false);

    private void Show(float progress)
    {
        slider.gameObject.SetActive(progress > 0f);
        slider.value = progress;
    }
}
