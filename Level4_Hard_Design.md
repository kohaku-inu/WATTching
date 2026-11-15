# Wattching: Level 4


Companion to the "Level 4 map" board on the concept art canvas; the numbers 1-8 match the map. It builds on Levels 1-3. Every number is a placeholder. Nothing has been playtested, and the screen coverage on the map is a schematic, not a verified geometry.

## 1. What "hard" means here

Hard is not "the same level, tighter". It means the player has to **plan across the whole level** instead of reacting to the next hazard. Levels 1-3 asked "when do I cross?". Level 4 asks "what do I do first, given that I must be back by a fixed time?".

| | Level 1 tutorial | Level 2 easy | Level 3 normal | Level 4 hard |
|---|---|---|---|---|
| New idea | Work, wait then move | The mask | A moving hazard | **A deadline (the roll call)** |
| Hazards | 1 screen | 1 screen | Screen + inspector | **2 screens + inspector + a clock** |
| Perfect mask frees... | n/a | The whole walk | The screen only | **One of two screens only** |
| Safe route | One | One | Several | **None fully safe; hops between shelters** |
| Margin for error | about 2 s | none with no matches, about 14 s with a perfect mask | about 1 s (rough estimate) | **a few hundred ms per hop, but slack on the total clock** |
| Length | about 6 min | about 8 min | about 10 min | about 12 min |
| Failure | Reprimand | Reprimand | Reprimand | Reprimand, with the swap saved |

## 2. The new idea: the roll call

- **Bell:** about 40 s after the last roar, a bell rings and a lamp on the wall lights. Both are diegetic cues, so no text is needed.
- **Supervisor:** after the bell, she walks down the west wall to the desk row (map 8). She reaches your desk about 8 s later, so the check is at about 48 s.
- **The check:** if you are at your desk, nothing happens. If not, the suspicion meter fills by three quarters (placeholder).
- **It counts the desk, not your sight.** The archive hides you from the meter, but not from the clock. That is the tension: the safest place in the level is also the one you must leave in time.

This is the readable version of the "being away from your place raises suspicion" idea, as a single event instead of a slow drift.

## 3. The hazards

- **T1:** the same pendulum as before. It locks on the crowd for 6 s after the last roar, plus 5 s per matched roar, so 6 / 11 / 16 s.
- **T2 (new, but the same idea as T1):** a second screen on the north wall towards the east. It sweeps all the time and never locks. It is offset from T1 by about 2 s, so the east lane is covered for about 6 s of every 8 s, leaving a gap of about 2 s once T1 is back to sweeping.
- **The inspector:** the same loop, cone and pauses as Level 3 (about 31.5 s per loop). She starts walking when the horn ends.
- **Two shelter pillars** on the east side, so the lane is crossed in two hops of about 1.5-2 s, each fitting the 2 s gap.

## 4. Flow (about 12 minutes, placeholder)
<img width="3000" height="1520" alt="Level 4 map@2x" src="https://github.com/user-attachments/assets/8e79f231-6145-4f3f-8c7d-a2d44b17268a" />  

| Beat | Player does | What it teaches |
|---|---|---|
| **1. Work** (map 1) | Hold to work. | Cover, as before. |
| **2. Horn and Hate** (map 2) | Two roars. | The mask, under three watchers instead of one. |
| **3. The plan** | The afterglow starts. The player picks a line. | Planning: window, inspector, and the bell to come. |
| **4. Hop 1** (map 3) | Follow behind the inspector, reach the first shelter. | Level 3's skill, now with T2 in the way. |
| **5. Hop 2** | Cross to the second shelter, then to the door. | Waiting for the 2 s gap. |
| **6. Swap** (map 7) | Hold 5 s at the locker. | The same action. |
| **7. Return** | Walk back across the hall. | The same crossing, now against the clock. |
| **8. The check** (maps 8, 1) | Be at your desk when the supervisor arrives. | The deadline. |

## 5. Time budget

At an assumed 80-100 px/s: to the first shelter about 6.5 s, the lane and the door about 3 s, the swap 5 s, and the walk back about 11-12 s. That is about **30 s of pure walking and swapping**, against a check at about 48 s. The remaining **slack is about 18 s**, and the waiting at shelters, for the inspector's corner, and for T2's gaps has to come out of it. That is intentionally tight, but it hasn't been tested.

## 6. Failure and fairness

- **A missed check:** three quarters of the meter. A full meter is a reprimand, and it is never a game over (TBD).
- **Checkpoint:** once you have done the swap, a reprimand restarts you from the archive door, not from the desk. A hard level should not make the player redo the part they already mastered.
- **Cues are diegetic:** the bell, the wall lamp, and the supervisor's visible walk. There is no countdown number.
- **No new input:** movement and hold-to-act only.

## 7. Known risks

1. **The clock may reward rushing over reading.** If players run the whole level without waiting at the shelters, the deadline is working against the Level 1 lesson. The slack figure is the control for this.
2. **Three watchers plus a clock may exceed the player working memory.** This is the main concern with the whole level.
3. **Screen coverage is untested.** T2 must be placed so the combined gap with T1 is really about 2 s, and a pillar must really shadow a beam. The map only shows the intent.
4. **The supervisor's walk** has to be clear from anywhere in the room, or the check feels like a surprise.
5. **Visible suspicion meter on a hard level** may make the level easier than intended, because players can read their own risk. Hiding it here would break the rule of changing only one thing per level.

## 8. Open decisions

1. **Cost of a missed check:** three quarters, or a flat reprimand? The first is gentler, the second is clearer.
2. **Bell timing:** 40 s gives about 18 s of slack. Tighter makes it harder, but the numbers are guesses.
3. **Two roars or three:** two is used, to keep the pace.
4. **Should the inspector react to the bell?** In this version she doesn't. Adding reactive enemies to level are still TBD.

## 9. Playtest questions

1. Do players understand the bell as a deadline without text?
2. Do they plan the return before they leave the archive, or discover the deadline too late?
3. How many players use the shelters for two hops, and how many try one run?
4. Where do reprimands happen: at the lane, in the return, or at the check?
5. Does the level feel harder because of what the player has to plan, or only because of tighter timing?
6. How long does a first successful run take, and how does it compare to the 12-minute target?
