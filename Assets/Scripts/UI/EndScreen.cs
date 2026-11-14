using TMPro;
using UnityEngine;

// Shows the win or arrest screen when the level ends.
// Place it on an always-active object (e.g. the Canvas); the panel itself starts hidden.
public class EndScreen : MonoBehaviour
{
    [SerializeField] private TutorialFlow flow;
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text text;
    [SerializeField, TextArea(3, 8)]
    private string winText = "Day 1 complete\n\nBig Brother's Power: 100% -> 96%\nThe notebook has its first entry.";
    [SerializeField, TextArea(3, 8)]
    private string loseText = "ARRESTED\n\nYou were noticed once too often.";
    [SerializeField] private string controlsHint = "<size=70%>Press E to play again    Esc to quit</size>";

    private void OnEnable() => flow.LevelEnded += Show;
    private void OnDisable() => flow.LevelEnded -= Show;

    private void Start() => panel.SetActive(false);

    private void Show(bool won)
    {
        panel.SetActive(true);
        text.text = (won ? winText : loseText) + "\n\n" + controlsHint;
    }
}
