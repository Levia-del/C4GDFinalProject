# Features

> ✅ = Completed  |  ⬜ = Planned / In Progress

---

## 🎮 Core Systems

- ✅ **AudioManager** — Singleton persistent audio system that plays background music and SFX. Uses `DontDestroyOnLoad` to persist across scenes. Exposes `PlaySFX()` for triggering one-shot sound effects.
- ✅ **LevelsManager** — Singleton that manages level progression. Holds an array of minigame scene names (`Questions`, `Dodge`, `Button`), generates random level sequences (no repeats), tracks the current level number, and handles scene transitions via `LevelComplete()`.
- ✅ **MainGameUI** — Singleton persistent UI manager. Displays health as heart icons (up to 3), updates hearts on level transitions, and triggers the DeathScreen when health reaches 0.

## 🖥️ Screens / UI

- ✅ **StartScreen** — Title screen with a start button. `StartScrn.cs` listens for button clicks and loads the Transition scene. `TitleAnim.cs` adds a subtle pulsing scale animation to the title text.
- ✅ **Transition Screen** — Displays between minigames. Shows instructions for the upcoming level (e.g., "Dodge with A-D or die!"). After a countdown, automatically loads the next minigame.
- ✅ **DeathScreen** — Shown when the player runs out of health. Displays a restart button that returns to the StartScreen.

## 🕹️ Minigames

- ✅ **Questions (Trivia Minigame)** — A two-choice trivia game. Selects a question from easy/medium/hard pools based on the current level number. The player chooses the left (A) or right (D) answer. A 5-second timer adds pressure; running out of time counts as a failure. Correct answers advance the level; wrong answers cost 1 health.
- ✅ **Dodge (Survival Minigame)** — The player controls a character that snaps between 3 horizontal lanes (A = left, D = right). Projectiles fall from above with increasing speed and spawn rate across 3 difficulty tiers (levels 1–2, 3–5, 6+). Survive the timer to win. Colliding with a projectile costs 1 health.
- ✅ **Button (Reaction Minigame)** — A reaction test minigame. The text displays "Wait" for a random duration (3–15 seconds) while the button is disabled. Once the timer expires, the text changes to "Go!" and the button becomes clickable with a pulsating scale animation (DOTween Yoyo loop) and a randomized color flash effect (vibrant colors cycling every 0.3s). The player has a limited reaction window (starts at 5s, decreases with level to 1s minimum) to click the button. Clicking in time shows "Got it!" and advances (effects stop). Missing the window shows "Too Slow!", costs 1 health, and advances (effects stop). Both paths use a 2-second coroutine delay before transitioning through the Transition scene. All visual effects are properly killed and reset on completion.

## 🎨 Visual & Effects

- ✅ **DOTween Animations** — Used for player movement in the Dodge minigame (smooth lane snapping with squash/stretch and punch effects).
- ✅ **Projectile Visuals** — Falling projectiles rotate as they descend for visual feedback.
- ✅ **Title Animation** — Sine-wave pulsing scale effect on the start screen title.

---
