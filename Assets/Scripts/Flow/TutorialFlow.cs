using System;
using System.Collections;
using UnityEngine;

// Runs the tutorial's steps and decides when the level is won or lost.
// It knows nothing about the UI: the UI listens to its events.
public class TutorialFlow : MonoBehaviour
{
    [SerializeField] private HoldAction desk;
    [SerializeField] private HoldAction locker;
    [SerializeField] private SuspicionMeter suspicion;
    [SerializeField] private int recordsToRewrite = 3;
    [SerializeField, Tooltip("Reprimands before arrest (game over). 0 = never, as in the tutorial design doc.")]
    private int reprimandsBeforeArrest = 3;
    [SerializeField, Tooltip("Seconds between the last action and the end screen")]
    private float endDelay = 2f;

    public event Action<TutorialStep> StepChanged;
    public event Action<int, int> RecordRewritten;   // (done, total)
    public event Action<bool> LevelEnded;            // true = won, false = arrested

    public TutorialStep Step { get; private set; }

    private int recordsDone;
    private bool hasEnded;

    private void OnEnable()
    {
        desk.Completed += OnDeskWorkDone;
        locker.Completed += OnSwapDone;
        suspicion.Reprimanded += OnReprimanded;
    }

    private void OnDisable()
    {
        desk.Completed -= OnDeskWorkDone;
        locker.Completed -= OnSwapDone;
        suspicion.Reprimanded -= OnReprimanded;
    }

    private void Start() => SetStep(TutorialStep.Work);

    private void OnDeskWorkDone()
    {
        if (Step == TutorialStep.Work)
        {
            recordsDone++;
            RecordRewritten?.Invoke(recordsDone, recordsToRewrite);
            if (recordsDone >= recordsToRewrite)
                SetStep(TutorialStep.Swap);
        }
        else if (Step == TutorialStep.Return)
        {
            SetStep(TutorialStep.Done);
            StartCoroutine(EndLevel(won: true));
        }
        // During Swap, working is still allowed as cover but advances nothing.
    }

    private void OnSwapDone()
    {
        if (Step == TutorialStep.Swap)
            SetStep(TutorialStep.Return);
    }

    private void OnReprimanded(int reprimandCount)
    {
        if (reprimandsBeforeArrest > 0 && reprimandCount >= reprimandsBeforeArrest)
            StartCoroutine(EndLevel(won: false));
    }

    private void SetStep(TutorialStep step)
    {
        Step = step;
        locker.IsAvailable = step == TutorialStep.Swap;
        StepChanged?.Invoke(step);
    }

    private IEnumerator EndLevel(bool won)
    {
        if (hasEnded)
            yield break;
        hasEnded = true;
        suspicion.enabled = false;   // no reprimand while the ending plays out

        yield return new WaitForSeconds(endDelay);

        Time.timeScale = 0f;         // freeze physics and the telescreens behind the end screen
        LevelEnded?.Invoke(won);
    }
}
