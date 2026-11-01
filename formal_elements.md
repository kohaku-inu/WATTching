# *WATTching*
**Genre:** Stealth / Social Infiltration | **Perspective:** TBD (top-down or side-view recommended) | **Platform:** PC (assumed)

---

## 1. Description
Oceania, 1984. You are an Outer Party member at the Ministry of Truth. You rewrite history by day and are expected to love Big Brother by night. You can't fight anyone. You can only blend in, and quietly dismantle the machine from inside it. Get seen once too often, and the game ends the way the book does.

**Core fantasy:** Being a perfect cog while being the sand in the gears.
**Design pillars:**
1. **Conformity is the weapon.** Blending in is not a fail-safe, it is the main mechanic.
2. **No place is safe.** Even home is watched; safe spots must be earned.
3. **Color is hope.** The world's palette is a direct readout of Big Brother's power.

---

## 2. Core Concepts
- **Number:** Single player.
- **Role:** One protagonist (Winston-like; the player may be Winston or an original character in the same world).
- **Player pattern:** Player vs. System. The "opponent" is not a character but the surveillance state itself (AI patrols, telescreens, informants, a hidden global Suspicion model).
- **Decision:** No close circle and no relationship/trust system. The player is alone. NPCs exist only as environmental hazards (coworkers, patrols, informants) and scripted information sources.

## 3. Goals
**Primary (long-term):** Reduce Big Brother's **Power** to zero without ever reaching maximum **Suspicion**.

**Secondary (per-day):**
- Complete assigned Ministry work (to look normal).
- Attend mandatory events (Two Minutes Hate, exercise, rallies).
- Spend remaining "free time" on one of three covert activity types: **Sabotage, Learn, Build**.


- **Challenge:** Staying calm and unnoticed while doing things that, if seen, end you.
- **Play:** Observation, timing, planning, tool-crafting, performing normality.
- **Character:** The player-character is ordinary, frightened, capable of small defiance.
- **Story:** Day-by-day arc: compliance → doubt → first sabotage → network → escalation → the final confrontation.

## 4. Processes (Actions the Player Can Take)
| Category | Actions |
|---|---|
| **Cover (public)** | Work at desk, rewrite records, attend events, chant, applaud, queue, eat in canteen |
| **Sabotage** | Disable a telescreen, misfile or subtly falsify records (rewrite the rewrite), jam a speakwrite, cut a power line, plant doubt in conversations |
| **Learn** | Read hidden documents, decode information, eavesdrop, memorize patrol routes and shift changes |
| **Build** | Craft tools at home from scavenged parts (signal jammer, telescreen blind, forged pass, hidden notebook) |
| **Movement** | Walk, run (suspicious), crouch (suspicious in public, fine in blind spots), hide, wait |
| **Self-control** | Control facial expression and behavior under watch (a "mask" mechanic) |

## 5. Rules
- **Line of Sight:** Telescreens and observers detect you inside defined cones. Being observed while doing a non-cover action adds Suspicion.
- **Behavioral Norms:** Each location has an expected behavior (e.g., during the Two Minutes Hate you *must* look enraged). Deviating adds Suspicion.
- **Facecrime:** Prolonged visible nervousness (from high stress or Suspicion) raises detection chance even when you are doing nothing wrong.
- **Time:** The game runs in days divided into slots (morning work, midday, evening, night). Actions consume slots. Mandatory slots cannot be skipped.
- **Curfew & Routine:** Being out of place at the wrong time is a violation.
- **Informants:** Some NPCs report anomalies. The player does not know which ones.
- **Evidence persists:** Failed sabotage leaves traces that can be found later, so mistakes have long tails, not just immediate penalties.
- **Permadeath of progress:** No manual "retry this moment" save-scumming (design decision to be confirmed; see Open Questions).

## 6. Resources
| Resource | Role | Behavior |
|---|---|---|
| **Suspicion** (hidden/partial) | Lose-state meter | Rises on mistakes, decays slowly with exemplary behavior |
| **Big Brother's Power** | Progress meter, visible via world color | Falls through successful sabotage |
| **Time Slots** | Action economy | Fixed per day |
| **Composure** | Ability to hold the "mask" | Drains under stress, recovers in blind spots |
| **Knowledge** | Unlocks routes, tools, and sabotage targets | Gained from Learn actions |
| **Components** | Crafting inputs | Scavenged; carrying them is risky |

## 7. Conflict
- **Obstacles:** Telescreens, patrols, Thought Police, informants, bureaucratic checkpoints, inspections of your home.
- **Dilemmas:** Do more sabotage now (faster progress) vs. keep Suspicion low (survive longer). Grab a risky document now (knowledge) vs. wait for a safer window (time pressure).
- **Internal conflict:** Composure. The player is fighting their own character's fear.
- **Escalation:** As Big Brother weakens, the regime gets *more* paranoid, not less. Wounded states lash out.

## 8. Boundaries
- **Physical:** A city district (Ministry, Victory Mansions-style housing, streets, prole quarter, a few key interiors).
- **Systemic:** No combat. The player cannot attack, only hide, deceive, sabotage, and flee.
- **Magic circle:** The player accepts that every action has to be justified in-world as either a cover or a hidden act.

## 9. Outcomes
Endings are decided by two numbers at the end state: **Suspicion** (are you free?) and **Big Brother's Power** (how much did you break?). Arrest is always a loss; it is not a partial ending.

- **Good ending (departure from the novel, deliberate):** Power reaches zero while Suspicion stays below the arrest threshold. The regime collapses, palette fully restored.
- **Loss (faithful to the novel):** Suspicion hits max → arrest → Room 101 sequence → bad ending. The only variation is the *epilogue text/palette*, which reflects how much Power you removed before falling.
- **Partial endings (player is never arrested):**
  - *The Crack:* Power is low but not zero by the final day. The regime survives, weakened, and the player slips away or goes underground.
  - *The Cog:* Player kept Suspicion near zero but did too little. They survive as a loyal-looking citizen in a still-gray world.
- **Design note:** The novel's point is that resistance fails, so a winnable game is a deliberate departure. Keeping the Loss ending faithful and the Good ending hard-earned preserves the tone.

---

## 10. Time & Structure
- **Fixed calendar:** The game runs a set number of in-game days. Placeholder: 10-14 days (to be tuned after a vertical slice; the real limit is how many days of content can be filled before the loop feels repetitive).
- **Why fixed:** Creates pressure (no infinite waiting for a perfect run), makes the time-slot economy balanceable, and makes the partial endings (*The Crack*, *The Cog*) possible, since they are defined by the state on the final day.
- **Reactive final event:** The calendar sets the earliest and latest date of the regime's final move (purge / mass inspection / similar). It arrives *sooner* if Suspicion is high or Big Brother's Power has been hit hard. Wounded regimes lash out.
- **Daily structure:** Morning work → midday → evening → night, each a time slot. Mandatory slots cannot be skipped; free slots are spent on Sabotage, Learn, or Build.
- **Risks:** Hard clocks punish experimentation in stealth games, and fixed lengths tend to produce a single "optimal route." Mitigated by the reactive final event and by varying daily mandatory events.

---


## 11. Audiovisual Direction
- **Palette rule:** Game starts nearly monochrome (grays, near-black). Color is introduced as *saturation tied to Big Brother's Power meter*, not as scripted cutscene moments. Begin with a single color (e.g., a muted red or the green of a plant) and expand.
- **Sound:** Constant telescreen hum, propaganda loops. The sound mix also degrades as BB's power falls (static, silence, birdsong).
- **UI:** Minimal. Suspicion should be communicated diegetically (heartbeat, vignette, hand tremor) rather than a bar. Needs playtesting for readability.

## 12. Risks & Open Questions
1. **Good ending is decided** (see Outcomes). Open: how hard should it be, and should it be visible from the start that it exists?
2. **Stealth readability:** Stealth games fail when detection feels random. Need clear cone visualization, even in a monochrome style.
3. **Hidden Suspicion meter:** Too hidden feels unfair; too visible removes tension.
4. **Save system:** Permadeath vs. checkpoints. Strict consequences fit the theme but hurt accessibility.
5. **Scope:** A full-day simulation with crafting, NPCs, and sabotage is large. Consider a vertical slice (one day, one building, one sabotage chain).
6. **Rights:** *Nineteen Eighty-Four* is public domain in life+70 countries (e.g., the UK, and I believe Israel) but, as far as I know, still under copyright in the US until 2045. Use of named characters/titles/terms ("Big Brother," "Room 101") needs checking before any commercial release. I'm not a lawyer, so verify.
