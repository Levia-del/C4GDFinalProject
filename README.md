# 🎮 C4GD Final Project — Mini-Game Collection

> **Unity 2022.3.62f3** | **2D URP** | **C#**

A chaotic collection of rapid-fire mini-games built in Unity. Survive randomized trivia, dodge falling projectiles, and test your reflexes — each mistake costs a heart, and three strikes send you to the Death Screen.

---

## ✨ Full Feature List

### Core Systems
- **Procedural Level Sequencing** — Levels are drawn randomly from a pool of three mini-games without immediate repeats, keeping each playthrough fresh.
- **Persistent Health System** — 3 hearts tracked across all scenes via a singleton UI manager. Health depletes on failures and persists until game over.
- **Persistent Audio Manager** — Singleton audio system playing background music and SFX with `DontDestroyOnLoad` cross-scene persistence.
- **Difficulty Scaling** — Mini-game difficulty increases as the player progresses (more questions, faster projectiles, harder trivia).

### Mini-Games
- **Trivia (Questions)** — Two-choice trivia with three difficulty tiers (easy/medium/hard). Questions range from silly to existential. A 5-second timer adds pressure. Correct answers advance; wrong answers cost 1 HP.
- **Dodge** — Survival mini-game where the player dodges falling projectiles across 3 lanes. Speed and spawn rate scale with level. Smooth DOTween lane-snapping with squash-and-stretch feedback.
- **Button (Reaction Time)** — A randomized reaction test. Wait for the "Go!" signal — the button is disabled until then. Once active, the button pulsates with a breathing scale animation and flashes random vibrant colors. You have a shrinking reaction window (5s → 1s minimum based on level) to click. Click in time for "Got it!"; miss for "Too Slow!" and a lost heart. Effects instantly stop on click or timeout.

### Screens
- **Start Screen** — Title with a pulsing sine-wave animation and a start button.
- **Transition Screen** — Shows contextual instructions for the upcoming mini-game before auto-loading.
- **Death Screen** — Game-over screen with a restart button.

### Visual Effects
- DOTween-powered player animations (smooth lane snaps, squash/stretch, punch).
- Spinning projectile visuals during descent.
- Animated title with sine-wave breathing effect.

---

## 🚀 Getting Started

### Prerequisites
- **Unity Hub** — [Download here](https://unity.com/download)
- **Unity Editor** — Version `2022.3.62f3` (the project uses this specific version)
- **Git** — For cloning the repository

### Installation

```bash
# Clone the repository
git clone https://github.com/Levia-del/C4GDFinalProject.git

# Open in Unity Hub
# 1. Launch Unity Hub
# 2. Click "Open" → "Add project from disk"
# 3. Select the `C4GDFinalProjectU` folder
# 4. Open the project (Unity will import assets automatically)
```

### How to Run
1. Open the project in Unity Editor.
2. In the Project window, navigate to `Assets/Scenes/`.
3. Double-click `StartScreen.unity` to load the starting scene.
4. Press the **Play** button in the Unity Editor toolbar.

---

## 🎯 How to Play

| Mini-Game | Controls | Objective |
|-----------|----------|-----------|
| **Trivia** | `A` = Left answer, `D` = Right answer | Choose the correct answer before the timer runs out. |
| **Dodge** | `A` = Move left, `D` = Move right | Dodge falling projectiles for the duration. |
| **Button** | Press the on-screen button | React as fast as possible when "Go!" appears. |
| **General** | Survive! | Lose all 3 hearts and it's game over. |

---

## 📁 Project Structure

```
C4GDFinalProjectU/
├── Assets/
│   ├── Animation/           # Unity animation controllers (.controller, .anim)
│   ├── Plugins/             # Third-party plugins (DOTween)
│   ├── Prefabs/             # Reusable prefabs (AudioManager, Hearts, Projectiles, etc.)
│   ├── Resources/           # DOTween settings asset
│   ├── Scenes/              # All game scenes
│   │   ├── StartScreen.unity
│   │   ├── Transition.unity
│   │   ├── Questions.unity
│   │   ├── Dodge.unity
│   │   ├── Button.unity
│   │   ├── DeathScreen.unity
│   │   └── Button.unity
│   ├── Scripts/             # C# scripts organized by scene/system
│   │   ├── Button/          # ButtonCanvas.cs
│   │   ├── DeathScreen/     # DeathCanvas.cs
│   │   ├── Dodge/           # DodgeCanvas.cs, PlayerController.cs, Projectile.cs
│   │   ├── General/         # AudioManager.cs, LevelsManager.cs, MainGameUI.cs
│   │   ├── Questions/       # QuestionsCanvas.cs
│   │   ├── StartScrn/       # StartScrn.cs, TitleAnim.cs
│   │   └── Transition/      # TransitionCanvas.cs
│   ├── Settings/            # URP 2D renderer settings
│   ├── SFX/                 # Sound effects and music
│   └── Sprites/             # Game sprites and assets
├── ProjectSettings/         # Unity project configuration
└── Packages/                # Package manifest
```

---

## 🛠️ Built With

| Tool | Purpose |
|------|---------|
| **Unity 2022.3.62f3** | Game engine |
| **Universal Render Pipeline (URP) 2D** | 2D rendering |
| **DOTween (Demigiant)** | Tweening animations (lane snaps, punch, scale) |
| **TextMeshPro** | Text rendering with PixelOperator SDF font for consistent pixel-art style |
| **C#** | All game logic |

---

## 👥 Credits

- **Levia-del** — Project lead & development
- **dimspitsikoulis-cmd** — Development
- **gorbmaster** — Development

---

## 📝 License

This project is developed as a final project submission. All assets are original or used under permissive licenses.
