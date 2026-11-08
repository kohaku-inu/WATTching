# Wattching: Tutorial Level ("The Slip", working title)

Companion to the "Tutorial map" board on the concept art canvas; the numbers 1-5 match the map. The levels are organized by difficulty (tutorial, easy, normal, hard), not by number.

## 1. Design intent

A tutorial should ask for one new idea at a time. This level teaches two verbs, with one hazard and one rule, and leaves everything else to later levels (section 7).

| Element | In the tutorial |
|---|---|
| Length | **One day, about 6 minutes, no flat** |
| Routes | **One route** |
| Hazards | **One telescreen that sweeps like a pendulum. No other hazard.** |
| NPC pressure | None (no informants, patrols or supervisors on the floor) |
| Events | None (the Two Minutes Hate and the Composure meter arrive in the easy level and later) |
| Tools | None. The player carries one slip. |
| Suspicion | **One visible meter, one rule** |
| Locations | **5 numbered locations** |

## 2. Tutorial rules

1. **Two verbs only:** *work* (hold to work at a desk) and *wait, then move* (cross when the telescreen looks away). The third action, *swap the slip*, is the same hold input as work.
2. **Two inputs only:** move, and hold-to-act.
3. **One hazard** with one readable behavior.
4. **One objective on screen at a time**, as a short line at the edge of the screen, in the notebook's red: "Swap the document in the archive." It names the goal, not the controls. The space and a hold icon teach those.
5. **No failure spiral.** A mistake costs a few seconds and a reprimand, never the game.
6. **Every instruction is taught by the space:** the safe strip, the shelter and the door are placed so the correct path is also the visible one.

## 3. Flow (about 6 minutes, placeholder)

| Beat | Player does | What it teaches | How it is taught |
|---|---|---|---|
| **1. Work** (map 1) | Hold to rewrite three records at the desk. | Doing the job is the cover. Being seen working is safe. | T1's beam passes over clerks who keep working. Nothing happens to them. The beam also passes over you at your desk, harmlessly. |
| **2. The order** | A slip arrives. The objective line appears at the screen edge: "Swap the document in the archive." | The goal, stated once, in one line. | The line is red, the only color on screen, and stays until the swap is done. |
| **3. Walk the strip** (map 2) | Walk along the south wall. | Some places are out of reach. | The strip is outside the beam's range. The beam never touches it. |
| **4. Wait** (map 3) | Stop at the shelter pillar and watch two sweeps. | The beam has a rhythm. | The faint beam on the map shows where it will point next, and the sweep is slow enough to read. |
| **5. Cross** (map 4) | Move about 150 px while the beam points away, and enter the door. | Timing. Being seen off-task fills the meter. | The meter appears the first time the player is seen off-task. |
| **6. Swap** (map 5) | Hold 5 s at the ledger locker. | Sabotage is a quiet, held action, and the archive is safe. | The telescreen hum drops to silence inside the archive, a first taste of relief. |
| **7. Return** | Walk back and resume work at the desk. | Sabotage needs a return to cover. | The way back repeats beat 4, so the skill is tested once more. |

## 4. The telescreen (placeholder numbers)

- **Behavior:** swings from one side to the other, headings about 40 degrees either side of straight south, with a beam width of about 28 degrees.
- **Timing:** 4 s per side, so an 8 s cycle. These are tuning numbers, not tested ones.
- **Range:** about 330 px, shorter than the distance to the south strip, so the strip is never covered.
- **The crossing:** the door side of the hall is exposed only when the beam points right. The crossing is about 150 px and takes roughly 1.5-2 s (at an assumed walking speed of 80-100 px/s), so it fits in the 4 s gap. Only the last part of it, roughly 80 px, falls inside the beam's range. This is intentionally forgiving.
- **Desk work inside the beam** is safe and shows the rule by example.

## 5. Suspicion in the tutorial

The full game hides suspicion and shows it through the character. A tutorial has to explain the rule first, so in the tutorial only there is a **visible meter**.

- Seen off-task in the beam: the meter fills in about 5 s.
- Out of sight: it drains in about 10 s.
- Full meter: the supervisor reprimands you, the screen cuts to your desk, and the meter resets to half. A second full meter restarts the crossing from the desk. It is never a game over.

Later levels fade the meter out and move to the diegetic version (heartbeat, vignette, hand tremor). That change is itself a design decision, listed in section 8.

## 6. Feedback and ending

- **Color:** only the notebook and the objective line are red. After the swap, its red gains a little saturation, which is the first hint of the color arc. The lamp stays gray (it warms at 75% Power in the progression board).
- **Sound:** telescreen hum everywhere, dropping to silence in the archive.
- **End card:** Power 100% to 96% (placeholder), and the notebook gets its first entry. An optional 10 s epilogue shows the notebook being hidden.

## 7. Difficulty ladder

Each level adds one idea to what the player already knows. Levels are identified by difficulty, so the order can change without renaming anything.

| Difficulty | New idea | Built from |
|---|---|---|
| **Tutorial** (this document) | Work as cover, wait then move | One screen, one route |
| **Easy** | **The mask:** the Two Minutes Hate, and looking the part (the Composure meter waits for a later level) | Mask mechanic, mandatory event |
| **Normal** | **A moving hazard:** the inspector's patrol and timing | P1 loop, inspector cone, corner pauses |
| **Hard** | **A deadline:** the roll call, two screens plus the inspector, and a fixed time to be back at your desk | Bell, supervisor, second screen |

Ideas not yet assigned to a difficulty, in a suggested order:

| New idea | Built from |
|---|---|
| **Home and Composure:** the flat, the blind alcove, hiding the notebook, and the Composure meter that drains while you carry something | Flat, stash, inspection |
| **Learn and Build:** overhearing, collecting parts, a forged tool | Roster board, keypad code, pass, ink pad |
| **Routes and evidence:** several ways in, each leaving a trace | Routes A-C, power cut, maintenance |
| **Informants:** reading NPCs without trust | I1, the tell, a decoy |

This is a suggested order, not a tested one.

## 8. Open decisions

1. **Visible meter in the tutorial only?** I recommend yes. The risk is that moving to hidden suspicion later feels like a loss of information. Test it.
2. **Is "hold to work" the right verb?** It makes the cover feel active, but it could become annoying if it is repeated for three records. The alternative is automatic work while standing at the desk.
3. **Six minutes:** a placeholder target. I have no data on how long a first-time player will spend waiting at the shelter.
4. **Reprimand rule:** a second full meter restarts the crossing. Whether that is forgiving enough is a playtest question.
5. **Perspective** is still assumed to be top-down.
6. **Objective line in later levels:** keep it, or fade it out like the visible meter? It names the goal but not the controls, so players may still need a hint for the verbs.

## 9. Playtest questions

Measure completion time, number of reprimands, and how long players wait at the shelter.

1. Do players understand the sweep without text?
2. Do they wait at the shelter, or rush the crossing?
3. Do they understand why working at the desk is safe?
4. Does the objective line at the screen edge register, and do players head for the archive without prompting?
