using TMPro;
using UnityEngine;

// Shows the current objective line at the screen edge (design doc: one objective at a time, in red).
[RequireComponent(typeof(TMP_Text))]
public class ObjectiveLabel : MonoBehaviour
{
    [SerializeField] private TutorialFlow flow;
    [SerializeField] private string workText = "Rewrite the records.";
    [SerializeField] private string swapText = "Swap the document in the archive.";
    [SerializeField] private string returnText = "Return to your desk.";
    [SerializeField] private string doneText = "Big Brother's Power: 100% -> 96%";

    private TMP_Text label;

    private void Awake() => label = GetComponent<TMP_Text>();
    private void OnEnable() => flow.StepChanged += Show;
    private void OnDisable() => flow.StepChanged -= Show;

    private void Show(TutorialStep step)
    {
        label.text = step switch
        {
            TutorialStep.Work => workText,
            TutorialStep.Swap => swapText,
            TutorialStep.Return => returnText,
            TutorialStep.Done => doneText,
            _ => ""
        };
    }
}
