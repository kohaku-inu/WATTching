using TMPro;
using UnityEngine;

// Shows short story messages for a few seconds when something happens in the level.
[RequireComponent(typeof(TMP_Text))]
public class MessageLabel : MonoBehaviour
{
    [SerializeField] private TutorialFlow flow;
    [SerializeField] private SuspicionMeter suspicion;
    [SerializeField] private float showSeconds = 2.5f;

    [Header("Texts")]
    [SerializeField, Tooltip("{0} = records done, {1} = total")]
    private string recordFormat = "Record rewritten ({0}/{1})";
    [SerializeField] private string slipArrivedText = "A slip arrives through the tube.";
    [SerializeField] private string swappedText = "Document swapped.";
    [SerializeField] private string firstReprimandText = "Supervisor: \"Back to your desk, comrade.\"";
    [SerializeField] private string laterReprimandText = "Supervisor: \"Again? Back to work.\"";

    private TMP_Text label;
    private float hideTimer;

    private void Awake() => label = GetComponent<TMP_Text>();

    private void OnEnable()
    {
        flow.RecordRewritten += OnRecordRewritten;
        flow.StepChanged += OnStepChanged;
        suspicion.Reprimanded += OnReprimanded;
    }

    private void OnDisable()
    {
        flow.RecordRewritten -= OnRecordRewritten;
        flow.StepChanged -= OnStepChanged;
        suspicion.Reprimanded -= OnReprimanded;
    }

    private void Start() => label.text = "";

    private void Update()
    {
        if (hideTimer <= 0f)
            return;
        hideTimer -= Time.deltaTime;
        if (hideTimer <= 0f)
            label.text = "";
    }

    private void OnRecordRewritten(int done, int total) => Show(string.Format(recordFormat, done, total));

    private void OnStepChanged(TutorialStep step)
    {
        if (step == TutorialStep.Swap)
            Show(slipArrivedText);
        else if (step == TutorialStep.Return)
            Show(swappedText);
    }

    private void OnReprimanded(int count) => Show(count == 1 ? firstReprimandText : laterReprimandText);

    private void Show(string text)
    {
        label.text = text;
        hideTimer = showSeconds;
    }
}
