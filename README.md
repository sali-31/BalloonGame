# Balloon Burst (2D Unity Game)

Balloon Burst is a fast-paced 2D arcade game where you control Goku, shoot pins, pop balloons for points, and avoid distractors across three levels. Smaller balloons are worth more points — can you beat the high score?

## 🎮 Play
https://sali31.itch.io/dragon-ball-balloon-burst

## 🕹️ Controls
- **Move:** Arrow Keys 
- **Shoot Pin:** **Space** 
- **Pause/Resume: **esc**

## ⭐ Scoring
- Score increases when you **pop balloons**.
- **Smaller balloon = more points**, larger balloon = fewer points.
- If the balloon grows too large, the level restarts.
- High score saves between runs.

## 🧩 Levels
The game has **3 levels**, each harder than the last:
- **Level 1:** Basic gameplay + one distractor
- **Level 2:** More distractors
- **Level 3:** Faster gameplay + smaller balloon + multiple distractors

## 🔥 Difficulty Modes
Difficulty is selected from the **Settings** menu.

- **Easy:**saibaman in level 1** **frieza in level 2** **faster balloon + 2 distractors**
- **Normal:** Adds **Beerus** as an extra distractor in every level
- **Hard:** Adds **Beerus + SuperBuu** as extra distractors in every level

## 🏆 High Scores
- Saves the **top scores** across runs
- Accessible from the main menu
- Displays scores in descending order

## 🔊 Audio
- Background music plays across the game
- Pop sound plays when a balloon is popped
- **Master volume** is controlled from the Settings slider and saved

## ✨ Animations
- **Shoot recoil:** Goku does a quick squash/stretch + small bob when firing.
- **Score Bounce:** Score bounces everytime it increases.

## 🛠️ Built With
- **Unity (2D)**
- **TextMeshPro** for UI text
- WebGL-ready build

## 📁 Scripts (from /Assets)
These are the main scripts in this project:

- `GameManager.cs` — score handling, UI score display, level transitions, high score recording
- `GameSettings.cs` — persistent settings (difficulty + volume) using PlayerPrefs
- `SettingsMenu.cs` — slider/dropdown UI to change and save settings
- `MainMenu.cs` — main menu navigation and starting the game
- `UIManager.cs` — opens/closes Instructions / Settings / High Scores panels
- `MusicManager.cs` — background music that persists across scenes
- `HighScoreManager.cs` — saves/loads top scores
- `HighScoresUI.cs` — displays high scores in the menu
- `PlayerMovement.cs` — player movement controls
- `PlayerShoot.cs` — pin shooting and triggering recoil
- `PinMovement.cs` — pin movement direction/speed
- `PopOnContact.cs` — pin collision with balloon/distractors + scoring + SFX
- `BalloonMovement.cs` — balloon movement logic
- `BalloonGrowth.cs` — balloon growth over time
- `BalloonSpawner.cs` — balloon spawning logic (if used in your levels)
- `DistractorMove.cs` — distractor movement
- `DifficultyDistractor.cs` — enables extra distractors based on difficulty
- `FireRecoil.cs` — recoil animation effect when firing
- `ScoreBounce.cs` — bounce animation effect on score UI text
- `PauseMenu.cs` — pause/resume + return-to-menu logic
- `AudioBoostrap.cs` / `AudioStateDebug.cs` — audio helpers/debug
---
## 👤 Author
**Sehar Ali**
