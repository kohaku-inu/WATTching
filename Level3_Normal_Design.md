# Wattching: Level 3


Companion to the "Level 3 map" board on the concept art canvas; the numbers 1-6 match the map. It builds on `Wattching_Level1_Design.md` and `Wattching_Level2_Design.md`. Every number below is a placeholder. None has been playtested, and the map has not been run in an engine.

## 1. What "normal" means here

Normal is not "harder numbers". It is a change in what the player has to do:

- **Level 1 (tutorial):** one skill at a time, told by the space.
- **Level 2 (easy):** one new skill, no new prompts, a generous reward.
- **Level 3 (normal):** one new hazard, and the player must **combine** skills they already have. Nothing is explained again, and the safe path is no longer the only visible one.

| | Level 1 tutorial | Level 2 easy | Level 3 normal |
|---|---|---|---|
| New idea | Work as cover, wait then move | The mask | **A moving hazard (the inspector)** |
| Hazards | 1 sweeping telescreen | Same | Same screen **plus** a patrolling inspector |
| Skills used together | 1 | 2 | **4** (work, mask, wait-then-move, follow-behind) |
| Length | about 6 min | about 8 min | about 10 min |
| Margin for error (crossing window) | about 2 s of slack | none with no matches (falls back on the tutorial skill), about 14 s with a perfect mask | about 1 s of slack (rough estimate, to be re-checked) |
| Failure cost | A reprimand | A reprimand | A reprimand |
| Safe route | One | One | Several, each with a trade-off |

The margin shrinks from generous to tight, the number of things to track grows from one to three (screen, inspector, window), and the player has to choose a line instead of following the marked one.

## 2. What the level adds

**One new idea: a hazard that moves on its own schedule.** Level 1's telescreen is a pendulum fixed on the wall. The inspector walks, so she is a hazard you must read *in space*, not just in time.

- **Route:** a rectangle around the middle of the hall (about 500 x 240 px), walked clockwise from the south-west corner. Dotted line and arrowheads on the map.
- **Cone:** a flashlight cone about 95 px long and 105 px wide, pointing where she walks. **Behind her is safe.** That rule is the whole lesson.
- **Corner pauses:** 1.5 s at each corner while she turns. The pause is the tell, readable from across the room.
- **Pace:** about 60 px/s, slower than the player (80-100 px/s). This matters, see section 7.
- **Loop time:** about 31.5 s (S strip 8 s, lane 4.5 s, top 8.5 s, west leg 4.5 s, plus four 1.5 s pauses).
- **Cost of being caught:** the cone fills half the meter at once (the screen needs about 5 s for a full meter). That is a bigger, faster penalty than the screen, which is how the player learns she is the more dangerous one.

## 3. Cast and map

| # | Place | Role |
|---|---|---|
| 1 | Your desk | Start. Hold to work until the horn. |
| 2 | Your spot | The same Hate mark as Level 2. Two roars (not three). |
| 3 | Shelter pillar | A wait point on the south-east corner of her loop. It sits 15 px off her south leg, so check it is truly out of her cone. |
| 4 | The inspector | Walks the loop, pauses at corners. |
| 5 | The screen (T1) | Sweeps as before, locks on the crowd during the afterglow. |
| 6 | Ledger locker | Hold 5 s. The archive is a safe room, so waiting inside costs nothing. |

**The crowd:** during the Hate, the clerks leave their desks and assemble under T1 (the faint dots on the map), as in Level 2. The screen watches them, then locks on them in the afterglow. When the afterglow starts they return to their desks, which clears the middle of the hall for the inspector's top leg (y = 330). The map shows the crowd faintly, because it overlaps that leg only during the Hate, when she isn't walking yet.

## 4. The Hate and the afterglow (changed from Level 2)

- **Two roars** instead of three (about 2 x 3 s with an 8 s lull). A shorter event keeps the level from dragging on a third pass.
- **Matching rule and cue are unchanged.** Hold at least 2 s inside the roar.
- **Afterglow** (the screen locked on the crowd): **6 s base, plus 5 s per matched roar, so 6 / 11 / 16 s.** This is the same formula as Level 2, with a cap lowered from 21 s to 16 s.
- **Why a smaller cap:** in Level 2 a perfect mask made the whole walk free. Here it should not, because the inspector is still out there.

## 5. Flow (about 10 minutes, placeholder)
<img width="3000" height="1520" alt="Level 3 map@2x" src="https://github.com/user-attachments/assets/f58d1801-42fa-4465-87fe-73de86a6a136" />  

| Beat | Player does | What it teaches |
|---|---|---|
| **1. Work** (map 1) | Hold to work at the desk. | The cover from Level 1. |
| **2. The first sighting** | The inspector enters at the south-west corner and starts her loop. | She is new, and visibly different from the screen. |
| **3. Horn and spot** (map 2) | Walk to the mark and mask the two roars. | The mask from Level 2, now under a second watcher. |
| **4. Afterglow, start of loop** | The screen locks. The inspector is at the start of her loop. The player lets her get ahead. | **Patience**: the opening is not the same as the right moment. |
| **5. Follow-behind** (map 3-4) | Go down and east along the south strip **behind** her cone, wait at the shelter while she turns the north-east corner. | Behind her is safe. Her corner pause is the signal. |
| **6. Cross** | Up the east lane to the door once she has turned west on the top leg. | Timing against a moving hazard. |
| **7. Swap** (map 6) | Hold 5 s at the ledger locker. | Same as before. |
| **8. Return** | Back through the hall, whichever way you pick. | Repeats the read-the-inspector skill without a prompt. |

The map shows one worked line. In the timeline, her top leg begins about 15.5 s after the last roar, which is when the lane is behind her. That is inside the window only with two matches (16 s) or the beam's gap.

## 6. Failure and the safety net

- **Screen sees you off-task:** the meter fills in about 5 s, as in Level 1.
- **Inspector's cone:** half the meter at once. Leaving the cone drains it at the same rate as before.
- **Full meter:** a reprimand and a restart from your spot. It is never a game over (Temporary).

## 7. Known risks

1. **Overtaking.** The player moves faster than the inspector, so following behind her means catching up and walking into her cone, unless the player holds back. This is a design feature (patience), but if players overtake without noticing, the level feels unfair. Options: a short follow-distance cue, or matching her pace in the corridors.
2. **The shelter is close to her path.** At 15 px from her south leg, it must block her cone for the safe spot to be real. I have not verified the cone geometry.
3. **Window versus route.** With 0 or 1 matches (6 or 11 s), the player is not through the lane before the afterglow ends. They fall back on the beam's gap and their Level 1 skill, which keeps the level winnable but adds a second hazard at the worst moment.
4. **Corner pauses assume the player can read them.** If the inspector's turn animation is not clear, the pause is invisible and the level is a guessing game.
5. **Three things to track** (screen, inspector, window) may exceed what a first-time player holds in their head. This is the main concern with calling it "normal".

## 8. Open decisions

1. **Carry-over was cut.** Test whether the half-meter jump from the cone is enough of a penalty, and revisit consequences that follow the player once the suspicion meter is full.
2. **Ring visibility:** still visible here. If the full game hides suspicion, this is the level to start fading it. I would not do it in the same level as a new hazard.
3. **Roars:** two or three? Two keeps the pace, three keeps parity with Level 2.
4. **Does the inspector hunt?** In this level she does not react to the player. A reactive inspector is a good idea for a later level, and a reactive one in Level 3 would stack too much on one new element.
5. **Pace and cone size** are guesses. They decide whether the level feels fair.

## 9. Playtest questions

1. Do players learn "behind her is safe" without text?
2. Do they wait for the corner pause, or try to run past?
3. Do they overtake her while following, and do they understand why they were caught?
4. Does the 6 / 11 / 16 s afterglow feel like a reward, or like a countdown?
5. How many reprimands does a typical player take, and where?
6. Does the level feel like a step up from Level 2 (more to track, tighter margin), or just longer?

Measure completion time, reprimands per player, and where on the map the first one happens.
