using System;
using UnityEngine;

// Tracks how suspicious the regime is of the player, from 0 (calm) to 1 (reprimand).
public class SuspicionMeter : MonoBehaviour
{
    [SerializeField] private float secondsToFill = 5f;    // while seen off-task (design doc)
    [SerializeField] private float secondsToDrain = 10f;  // while unseen (design doc)
    [SerializeField, Range(0f, 1f)] private float valueAfterReprimand = 0.5f;

    public event Action<float> ValueChanged;
    public event Action<int> Reprimanded;   // argument: how many reprimands so far

    public float Value { get; private set; }

    private bool seenThisFrame;
    private int reprimandCount;

    // Called by every observer that sees the player; several in one frame still count once.
    public void ReportSeen() => seenThisFrame = true;

    public void AddInstant(float amount) => SetValue(Value + amount);

    // LateUpdate runs after all Updates, so every observer has reported for this frame.
    private void LateUpdate()
    {
        float ratePerSecond = seenThisFrame ? 1f / secondsToFill : -1f / secondsToDrain;
        seenThisFrame = false;
        SetValue(Value + ratePerSecond * Time.deltaTime);

        if (Value >= 1f)
            Reprimand();
    }

    private void Reprimand()
    {
        reprimandCount++;
        SetValue(valueAfterReprimand);
        Reprimanded?.Invoke(reprimandCount);
    }

    private void SetValue(float newValue)
    {
        newValue = Mathf.Clamp01(newValue);
        if (Mathf.Approximately(newValue, Value))
            return;
        Value = newValue;
        ValueChanged?.Invoke(Value);
    }
}
