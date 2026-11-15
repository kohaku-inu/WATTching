# Code notes (learning companion)

The course rule says comments should be short and used only where they help, so the long teaching comments moved here. Read this next to the scripts.

## C# compared with C / Java / Python

| C# | Meaning | Closest thing you know |
|---|---|---|
| `[SerializeField] private float speed = 2f;` | Private to code, editable in the Inspector | private field + config file |
| `public bool CanMove { get; set; }` | Property: field with built-in getter/setter | Java `getX()/setX()` |
| `public bool IsAlarmed => SeesPlayer && !x;` | Read-only property computed on every read | a getter method |
| `{ get; private set; }` | Anyone reads, only this class writes | public getter, private setter |
| `public event Action<int> Reprimanded;` | List of functions to call when something happens | Java listeners, C function pointers |
| `x += Handler;` / `x -= Handler;` | Subscribe / unsubscribe | `addListener` / `removeListener` |
| `Reprimanded?.Invoke(3);` | Call all subscribers, only if there are any | `if (x != null) x(3);` |
| `out RaycastHit hit` | Extra return value | passing a pointer in C |
| `TryGetComponent(out PlayerMovement m)` | "Does it have one? If yes, give it to me in m" | |
| `step switch { A => ..., _ => ... }` | Switch that returns a value | Python `match` |
| `$"{name} hit at {speed:F1}"` | String interpolation | Python f-strings |
| `IEnumerator` + `yield return` | Coroutine: a method that pauses and resumes | Python generators |
| `~0` | All bits set = "every layer" | same as C |
| `const float X = 0.7f;` | Named constant | `#define` / `static final` |

## Unity lifecycle order (per object)
`Awake` (create/cache things) → `OnEnable` (subscribe, enable input) → `Start` (first-frame setup) → every frame: `Update` → `LateUpdate` → … → `OnDisable` (unsubscribe).
Every object's `Awake`/`OnEnable` runs **before** any object's `Start`. That's why `TutorialFlow.Start()` can raise `StepChanged` and the UI, subscribed in `OnEnable`, already hears it.

## Per script: the lines worth understanding

**PlayerMovement**
- `controller.Move(velocity * Time.deltaTime)`: deltaTime makes speed "per second", not "per frame".
- `GroundedStickVelocity = -1f`: a CharacterController has no gravity; a small constant downward push keeps `isGrounded` reliable.
- `Teleport`: disable → move → enable, otherwise the controller overwrites the new position.
- The Input System `2DVector` composite turns 4 keys into one Vector2 and normalizes diagonals.

**PlayerPusher**
- `OnControllerColliderHit` is called by Unity, matched by name only. A typo means it silently never runs.
- `hit.normal.y > 0.7` = we're standing on it. (The old bug used `moveDirection.y`, which includes gravity.)
- `AddForce(... * Time.deltaTime, ForceMode.Impulse)` each contact frame = a steady force at any frame rate.

**TelescreenSweep**: `Mathf.Sin(time * PI / secondsPerSide)` swings −1…1 with a period of 2 × secondsPerSide, slowing at the ends like a pendulum.

**TelescreenVision**
- Cheap checks first (distance, angle), then `Physics.Raycast`. The first thing the ray hits decides: the player means seen, a wall or pillar means hidden.
- `QueryTriggerInteraction.Ignore`: trigger zones are invisible and must not block sight.

**TelescreenBeamView**: draws in `LateUpdate`, so it uses the rotation the sweep set this frame.

**SuspicionMeter**
- `ReportSeen()` only sets a flag; `LateUpdate` (after every `Update`) reads it once. Two screens seeing you = still one "seen".
- `SetValue` raises `ValueChanged` only when the value actually changes.

**NoisyObject**: `collision.relativeVelocity` = impact strength. A contact normal pointing up = landing on the floor, ignored.

**HoldAction**: `OnTriggerStay` re-detects the player after a teleport, when Unity can skip `OnTriggerEnter`.

**TutorialFlow**: `Time.timeScale = 0` freezes physics and `deltaTime`, but `Update` and input keep running.

**EndOfLevelChoice**
- `WasPressedThisFrame()` needs a new press. `IsPressed()` would restart instantly if E is still held from the desk.
- `Time.timeScale = 1f` before reloading: timeScale is global and survives a scene load.
