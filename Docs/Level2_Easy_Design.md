
# Wattching: Level 2 

Companion to the "Level 2 map" board on the concept art canvas; the numbers 1-5 match the map. It builds on `Wattching_Level1_Design.md`. "Two Minutes Hate" is a term from the novel, so the rights check from the formal elements file still applies.

## 1. What this level adds

**One new idea: the mask.** During a mandatory event, you must look the part, and doing it well buys you an opportunity.

- **Easy, but a step up from the tutorial.** It is a bit longer (about 8 minutes, placeholder), and it explains less: after the first roar there is no extra prompt.
- **No new button.** The mask uses the same hold-to-act input as working and swapping. Holding at the marked spot during a roar means "mask". Hold meaning depends on where you stand, as it already does in Level 1.
- **No new meter.** The visible suspicion meter from Level 1 carries the cost of a missed roar. The Composure meter is not introduced yet.
- **No new hazard.** It is still one telescreen, with the same sweep.

## 2. Why this idea, and how it supports the pillars

The first design pillar is "Conformity is the weapon". Level 1 told the player that working is safe. Level 2 shows the other half: playing your role well *creates* the opening. A convincing mask makes the room look at the screen, and the screen looks at the crowd.

## 3. The Hate

- **Length:** about 35 s (compressed from the novel's two minutes, for pace; placeholder).
- **Structure:** three **roars** of about 3 s each, separated by lulls of about 8 s.
- **Cues, in the fiction, not in text:**
  - The enemy face on the screen swells and shakes.
  - The crowd noise rises.
  - The clerks around you raise their arms. You raise yours only while you hold.
- **Matching a roar:** hold at least 2 s inside the roar window. Holding in the lulls does nothing (no penalty in this level).
- **A miss:** the suspicion meter fills by a third. A match fills nothing.

## 4. The afterglow (the reward)

When the last roar ends, the screen holds a closing slogan and its beam **locks on the crowd** instead of sweeping.

| Roars matched | Window |
|---|---|
| 0 | 6 s |
| 1 | 11 s |
| 2 | 16 s |
| 3 | 21 s |

- **Why it works as a reward:** the walk to the archive door is about 7 s (assuming 80-100 px/s over about 600 px). With no matches the window is too short, with one match it is enough, and with more it is comfortable.
- **While the beam is locked,** the south strip and the east lane are free, so no timing is needed.
- **Visible cue:** the beam stops moving, and the telescreen's frame dims slightly. A thin tell, so the player does not need a countdown.
- **When the window ends,** the beam resumes its sweep, exactly as in Level 1.

## 5. Flow (about 8 minutes, placeholder)
<img width="3000" height="1520" alt="Level 2 map@2x" src="https://github.com/user-attachments/assets/8c2ed691-61f4-4e4a-b101-76369f6e8ad8" />  

| Beat | Player does | What it teaches |
|---|---|---|
| **1. Work** (map 1) | Hold to work at the desk for about 20 s. | A short reminder of Level 1. |
| **2. Horn** | Everyone stops and walks to the floor. The notebook line: "Keep the original." | A mandatory event changes the room. |
| **3. Take your spot** (map 2) | Walk to the chalk mark at the edge of the crowd. | You are part of the crowd. |
| **4. Roar 1** | Hold when the screen roars. | The mask. The cues are the most obvious here. |
| **5. Roar 2 and 3** | Same, with no prompt. | Practice. A miss costs a third of the meter. |
| **6. Afterglow** (maps 3-4) | Walk the south strip and the east lane to the door. | The reward for conformity. |
| **7. Swap** (map 5) | Hold 5 s at the ledger locker, inside the silent archive. | The sabotage, the same as Level 1. |
| **8. Return** | Walk back to your spot or desk. | Repeats the crossing from Level 1 if the beam has resumed. |

## 6. Failure and recovery

- **Missed every roar:** the window is 6 s, so the player cannot reach the door in time. They can still finish with Level 1's wait-then-move once the beam resumes, which makes the level winnable by the old skill alone.
- **Full meter:** a reprimand and a return to your spot. It is never a game over, as in Level 1.

## 7. Accessibility note

A rhythm cue that relies on sound excludes some players. The roars are therefore shown visually (the face on the screen, the raised arms) as well as by sound. I recommend an option for longer roar windows. I have not tested any of this.

## 8. Open decisions

1. **Hate length:** 35 s keeps the pace, while the novel's two minutes would be more faithful but slower.
2. **Should mask quality lengthen the window?** It makes conformity the thing that creates the opportunity, But the risk is that players who miss a roar feel punished twice, once by the meter and once by the shorter window.
3. **Overacting:** holding in a lull has no penalty ?
4. **Level 2 in the same room as Level 1:** it reuses the hall to save work and to teach the player that a familiar space can change. It might feel repetitive, and a different room would cost more to build.
5. **The numbers** (3 roars, 3 s windows, 6 s base window, 5 s per match) are placeholders with no playtest data behind them.

## 9. Playtest questions

1. Do players understand "hold during the roar" without text?
2. Do they notice that a good mask gives them a longer window?
3. Do players who miss a roar understand why the window is short?
4. Does the afterglow cue (beam stops, frame dims) register?
5. Does the level feel like a step up from Level 1, or just a repeat?
