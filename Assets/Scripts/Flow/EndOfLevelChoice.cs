using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Carries out the player's choice after the level ends: play again or quit.
public class EndOfLevelChoice : MonoBehaviour
{
    [SerializeField] private TutorialFlow flow;

    private InputAction restartAction;
    private InputAction quitAction;
    private bool levelEnded;

    private void Awake()
    {
        restartAction = new InputAction("Restart", InputActionType.Button, "<Keyboard>/e");
        restartAction.AddBinding("<Gamepad>/buttonSouth");
        quitAction = new InputAction("Quit", InputActionType.Button, "<Keyboard>/escape");
    }

    private void OnEnable()
    {
        flow.LevelEnded += OnLevelEnded;
        restartAction.Enable();
        quitAction.Enable();
    }

    private void OnDisable()
    {
        flow.LevelEnded -= OnLevelEnded;
        restartAction.Disable();
        quitAction.Disable();
    }

    private void OnLevelEnded(bool won) => levelEnded = true;

    private void Update()
    {
        if (!levelEnded)
            return;

        // WasPressedThisFrame needs a NEW press, so E still held from the desk doesn't skip the screen.
        if (restartAction.WasPressedThisFrame())
            Restart();
        else if (quitAction.WasPressedThisFrame())
            Application.Quit();   // only works in a built game
    }

    private void Restart()
    {
        Time.timeScale = 1f;   // timeScale is global and survives a scene reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   // scene must be in Build Profiles
    }
}
