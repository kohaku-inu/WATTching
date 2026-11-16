# WATTching

**Oceania, 1984.** You are a clerk at the Ministry of Truth. Do your job, stay out of the telescreen's sight, and quietly sabotage the regime from inside.

This repository contains the **tutorial level**: one room, one telescreen, and the full core loop of *work as cover → wait → cross → sabotage → return*.

▶ **Play in the browser:** [itch.io page](https://kohaku-inu.itch.io/wattching)  ·  **Design docs:** [`Docs/`](Docs/)

---

## How to play

1. **Work:** hold **E** at your desk to rewrite 3 records. Working is your cover: the telescreen ignores you while you work.
2. **Swap:** a slip arrives. Sneak to the archive (east door) and hold **E** at the locker for 5 s.
3. **Return:** go back to your desk and work once more to restore your cover.

The telescreen sweeps like a pendulum. Its cone turns **red** when it sees you off-task, and your suspicion meter fills. Hide behind the pillar, wait for the beam to swing away, then cross. Don't slam the mail cart into walls: the noise is suspicious too.

**Win:** finish the swap and return to work. **Lose:** get reprimanded 3 times and you are arrested.

| Action | Keyboard | Gamepad |
|---|---|---|
| Move | WASD / Arrow keys | Left stick |
| Work / swap (hold) | E | A / Cross |
| Play again (end screen) | E | A / Cross |
| Quit (built game only) | Esc | |

## How to run the project

- **In the browser:** the itch.io link above (no install needed).
- **In Unity:**
  1. Clone the repo: `git clone https://github.com/kohaku-inu/WATTching.git`
  2. Open the folder in **Unity Hub** with **Unity 6.3 LTS (6000.3.25f1)**. Packages, including the Input System, install automatically on the first open.
  3. Open `Assets/Scenes/TutorialScene` and press **Play**. Click inside the Game view once so it receives keyboard input.

## Class relationships

Scripts are grouped by responsibility in `Assets/Scripts/`: `Player/`, `Hazards/`, `Interaction/`, `Systems/`, `Flow/`, `UI/`. Tuning data lives in `Assets/Data/`.

**Events (sender → receiver).** Game scripts announce what happened; receivers subscribe. The sender never knows who is listening.

```mermaid
flowchart LR
    HA[HoldAction<br/>desk + locker]
    SM[SuspicionMeter]
    TF[TutorialFlow]

    HA -- "Completed" --> TF
    HA -- "ProgressChanged" --> HPB[HoldProgressBar]
    SM -- "ValueChanged" --> SB[SuspicionBar]
    SM -- "Reprimanded" --> RD[ReturnToDeskOnReprimand]
    SM -- "Reprimanded" --> TF
    SM -- "Reprimanded" --> ML[MessageLabel]
    TF -- "StepChanged" --> OL[ObjectiveLabel]
    TF -- "StepChanged<br/>RecordRewritten" --> ML
    TF -- "LevelEnded" --> ES[EndScreen]
    TF -- "LevelEnded" --> EC[EndOfLevelChoice]

    classDef ui fill:#eef6ff,stroke:#4a78b5
    class HPB,SB,ML,OL,ES ui
```
<sub>Blue = UI scripts (`Assets/Scripts/UI/`). They only receive; nothing in the game logic references them.</sub>

**Direct references (caller → called).** Used only where one game script commands or reads another.

```mermaid
flowchart LR
    TS[(TelescreenSettings<br/>ScriptableObject)]
    TSW[TelescreenSweep] -- "reads" --> TS
    TV[TelescreenVision] -- "reads" --> TS
    TBV[TelescreenBeamView] -- "reads IsAlarmed" --> TV
    TV -- "ReportSeen()" --> SM[SuspicionMeter]
    NO[NoisyObject] -- "AddInstant()" --> SM
    TV -- "reads IsOnTask" --> PC[PlayerCover]
    HA[HoldAction] -- "sets IsOnTask" --> PC
    HA -- "sets CanMove" --> PM[PlayerMovement]
    RD[ReturnToDeskOnReprimand] -- "Teleport()" --> PM
    TF[TutorialFlow] -- "sets IsAvailable" --> HA
```

`PlayerPusher` has no arrows because it talks to Unity's physics only: it calls `AddForce` on any Rigidbody the player walks into. A full UML class diagram with fields and methods is in [`Docs/ARCHITECTURE.md`](Docs/ARCHITECTURE.md) ([image](Docs/UML_class_diagram.png)).

**Rules the code follows:** game code never references UI code; every event subscription in `OnEnable` is removed in `OnDisable`; each class has one responsibility, describable in one sentence without "and".

## Architecture decisions

**1. Events from game to UI, instead of direct references.**
*Chosen:* game scripts raise C# events (`SuspicionMeter.ValueChanged`, `TutorialFlow.StepChanged`, …) and UI scripts subscribe to them.
*Alternative:* `SuspicionMeter` holds a reference to the slider and updates it directly.
*Why:* the game logic works and can be tested with no UI in the scene, and the UI can be redesigned, or a second display added, without touching game code. An early version did use direct references and was refactored.

**2. Several small components instead of one large class.**
*Chosen:* the telescreen is three components: `TelescreenSweep` (rotation), `TelescreenVision` (detection) and `TelescreenBeamView` (drawing). The player is likewise split into `PlayerMovement`, `PlayerPusher` and `PlayerCover`.
*Alternative:* one `Telescreen` class that does all three.
*Why:* each part can change alone. A different movement pattern replaces only the sweep, and a moving guard could reuse `TelescreenVision` unchanged.

**3. A ScriptableObject for telescreen tuning, instead of numbers on each object.**
*Chosen:* sweep angle, timing, cone width and range live in a `TelescreenSettings` asset.
*Alternative:* `[SerializeField]` fields on every telescreen.
*Why:* a "type" of telescreen becomes a reusable asset. Changing the asset updates every screen that uses it, and a new difficulty needs no code. Values that belong to a single object (walk speed, hold time) stay as Inspector fields.

## Adding a new hazard or item

| Change | Files that change | Why only those |
|---|---|---|
| **A faster / wider telescreen** | None. Create a new `TelescreenSettings` asset in `Assets/Data/` and assign it to a duplicated telescreen | Numbers are data. Every telescreen reports to the same `SuspicionMeter`, which merges any number of observers, and the UI only listens to the meter |
| **A patrolling inspector** (new enemy type) | **New:** `Hazards/InspectorPatrol.cs` (movement only). Reuse `TelescreenVision` on the same object for sight | Seeing and reporting already exist as their own component; only the new behavior (moving) is new code |
| **A new noisy object** (e.g. a chair) | None. Add a `Rigidbody` + `NoisyObject` to any object | `NoisyObject` doesn't know what it is attached to |
| **A new hold-to-use station** | None for the action itself: add a trigger + `HoldAction`. **Changes:** `TutorialFlow.cs` (if it is part of the level's steps) and `TutorialStep.cs` (if it adds a new step) | `HoldAction` is generic. Only the level rules decide what completing it means |

## Singletons and static state

**No singletons and no static variables of our own.** References are assigned in the Inspector, and notifications go through events.

The code does use two of Unity's built-in static APIs:
- `Time.timeScale` (in `TutorialFlow` and `EndOfLevelChoice`) freezes the game behind the end screen. It is global by design and survives a scene reload, so `EndOfLevelChoice` resets it to 1 before restarting.
- `SceneManager.LoadScene` reloads the level on "play again".

`const` fields (e.g. `StandingOnThreshold`) are named constants, not shared state.

## Physics features used

| Feature | Where |
|---|---|
| CharacterController | `PlayerMovement` |
| Rigidbody + AddForce | Mail cart and archive door, pushed by `PlayerPusher` |
| Raycast | `TelescreenVision`: walls and the pillar block the telescreen's sight |
| Collision | `NoisyObject.OnCollisionEnter`: `relativeVelocity` decides whether an impact is loud |
| Joint | Archive door: `HingeJoint` with a spring and limits |

## AI review  

**Review of the code against the diagrams.** Every event declaration, every subscription and every cross-class call in `Assets/Scripts/` was listed by searching the code, then compared with the two diagrams above.

| Finding | Result |
|---|---|
| All 7 events and their 12 subscriptions match the events diagram | ✔ No deviation |
| Every `+=` in `OnEnable` has a matching `-=` in `OnDisable` | ✔ No deviation |
| No game-logic script references a UI script | ✔ No deviation |
| `TutorialFlow` switches off `SuspicionMeter` at the end of the level (`suspicion.enabled = false`) | ✘ Missing from the direct-references diagram. **Fixed:** edge added. The code was right: no reprimand should happen while the ending plays |
| `Application.Quit` is a static Unity API in use | ✘ Missing from the static-state list. **Fixed:** added |

**Deviations from the design docs** (`Docs/Level1_Tutorial_Design.md`):
- **Lose condition:** the doc says the tutorial is never a game over; the course requires a working loss. `TutorialFlow.reprimandsBeforeArrest` (default 3) adds an arrest screen. Setting it to 0 restores the doc's rule.
- Not implemented yet: the faint "next beam" preview, sound, the red notebook gaining saturation after the swap, and the optional epilogue. See the plan below.

**Bugs found during AI-assisted development (all fixed):**
- Pushing never worked: the "standing on it" check used `moveDirection.y`, which includes the gravity push, so every push was skipped. Now it uses the surface normal.
- The door wouldn't turn: hinge limits defaulted to 0°–0°, and the door rubbed against both walls.
- The cart wouldn't move: floor friction (~59 N) was stronger than the push (40 N). It now has a low-friction "wheels" Physics Material.
- The desk zone sometimes stopped responding after a teleport: Unity can skip `OnTriggerEnter`. `OnTriggerStay` now re-detects the player.
- The beam turned red while the player was working (visual only): red now means "raising suspicion", not just "sees".

**Limit of this review:** it was done by the same AI that wrote the code, so it is not independent. **Plan:** before the final submission, run a second review in a fresh AI session that has seen only this README and `Assets/Scripts/`, and record its findings in the usage log.

## Known limitations and bugs

| # | Issue | Impact | Plan to fix |
|---|---|---|---|
| 1 | **"Esc to quit" does nothing in the browser.** Browsers ignore `Application.Quit` | The end screen shows a control that doesn't work on itch.io | Hide the Esc hint and skip the quit check when `Application.platform == RuntimePlatform.WebGLPlayer` |
| 2 | **The sweep doesn't restart with the level.** `TelescreenSweep` uses `Time.time`, which counts from app start, not level start | After "play again" the beam starts at a different point in its swing | Use `Time.timeSinceLevelLoad`, which resets on every scene load (one-line change) |
| 3 | **The drawn beam passes through walls.** Only the drawing: the Raycast is blocked correctly | The cone looks like it reaches into the archive, which is safe | Cast a fan of rays and build the cone from the hit points, so the drawn beam stops at walls |
| 4 | **Detection uses one ray to the player's center** | A player half-hidden behind the pillar counts as fully hidden | Cast 2–3 rays (head, left and right shoulder); seen if any of them hits the player |
| 5 | **A missing Inspector reference gives an unclear `NullReferenceException`** | Hard to debug when setting up a new scene | Add `OnValidate` checks that log which slot is empty, on which object |
| 6 | **Physics values are hand-tuned, not play-tested** (push 40 N, wheel friction 0.05, door spring 2, clang at 1.5 m/s) | The cart may feel too light or too heavy; the clang may trigger too easily or too rarely | Play-test with 3–5 players, adjust in the Inspector (no code change needed) |
| 7 | **Hold progress resets when E is released** | Letting go for a moment loses all progress | Open question in the design doc (§8). Decide after play-testing whether to keep or pause progress |
| 8 | **No sound** (the telescreen hum, the archive's silence, the cart's clang) | Missing feedback the design relies on | `NoisyObject` already has an optional `AudioSource` slot. Add an audio pass next |
| 9 | **Key bindings are set in code** | Players can't rebind keys | Move the bindings to an Input Actions asset; the scripts would read actions from it |
| 10 | **No automated tests** | Regressions are found only by playing | Add Edit Mode tests for `SuspicionMeter` (fill/drain/reprimand) and `TutorialFlow` (step order, win/lose), which have no physics dependencies |

**Not a bug, but easy to mistake for one:** in the Unity editor, keyboard input reaches the game only while the **Game view** has focus. Click inside it after using the Inspector or Console.

