# Balloon Game (Balloon Burst)

Simple 2D balloon–popping game made in Unity for **CISC 3667 – Game Design and Development**.

You play as **Goku on Nimbus** on **Supreme Kai’s Planet**, moving left/right at the bottom of the screen and shooting pins upward to pop a moving, growing balloon. DBZ enemies move in the air and can block your shots.

---

## 🎮 Gameplay

- A **balloon** moves horizontally and slowly **grows** over time.
- If the balloon reaches its **max size**, the **level restarts**.
- You control **Goku** at the bottom:
  - Move to line up your shot.
  - Fire pins straight up to pop the balloon.
- Enemies (**Saibaman**, **Frieza**) patrol mid-air and can **block pins**, forcing you to reposition.
- There are **3 levels** with increasing difficulty.

---

## 🕹 Controls

**In-game**

- **Move Left:** `←` or `A`
- **Move Right:** `→` or `D`
- **Shoot Pin:** `Space` or `Left Ctrl`
- **Pause / Main Menu:** `Esc`

**Menus**

- Use mouse / trackpad to:
  - Click **Play Game**
  - Click **Settings** (difficulty + volume)
  - Click **Instructions**
  - Click **High Scores**

---

## 🎯 Goals & Scoring

- **Goal:** Pop the balloon before it grows too large.
- On pop:
  - You **finish the current level** and move to the next one.
  - You gain points based on **how small** the balloon was when popped  
    (smaller balloon → more points).
- After the last level, your **total score** for the run is saved in a **high score table**.

---

## 📈 Difficulty & Levels

**Difficulty (set in Settings menu):**

- **Easy** – slower balloon growth, more forgiving.
- **Normal** – default behavior.
- **Hard** – faster growth / more pressure.

**Levels:**

1. **Level 1** – 1 balloon, 1 distractor (Saibaman). Intro.
2. **Level 2** – 1 balloon, 2 distractors (Saibaman + Frieza).
3. **Level 3** – harder balloon behavior / timing, same enemies. Final test.

---

## 🧠 Main Systems / Scripts

Key scripts (under `Assets/`):

- **Core:**
  - `GameManager` – score, level changing, restart logic.
  - `GameSettings` – difficulty / settings.
  - `HighScoreManager` + `HighScoresUI` – high score saving and display.
- **Player & Pins:**
  - `PlayerMovement` – moves Goku left/right.
  - `PlayerShoot` – spawns and launches pins.
  - `PinMovement` – moves pins upward, destroys off-screen.
- **Balloon & Enemies:**
  - `BalloonMovement` – horizontal motion of the balloon.
  - `BalloonGrowth` – balloon scaling, failure on max size, scoring on pop.
  - `DistractorMove` – enemy patrol movement.
  - `PopOnContact` – collision behavior when pins hit things.
- **UI:**
  - `MainMenu`, `UIManager`, `SettingsMenu`, `PauseMenu` – menus, settings, instructions, pause.

---

## 🛠 How to Run (Unity)

1. Open **Unity Hub**.
2. Click **Open**, select the project folder (the one containing `Assets`, `Packages`, `ProjectSettings`).
3. Open `Assets/Scenes/MainMenu.unity`.
4. Press **Play** in the Unity editor.
5. Choose difficulty, read instructions if needed, then click **Play Game**.

---

## 📦 WebGL Build
- Use a simple HTTP server or Unity’s recommended method to host the build folder.
- Open `index.html` in a modern browser and play the game there.

---

## 📄 Credits

- **Developer:** _Sehar Ali_  
- **Course:** CISC 3667 – Game Design and Development  
- **Engine:** Unity 2022.3.x  
- **Note:** Dragon Ball Z characters and imagery belong to their respective rights holders. This is a non-commercial, educational project.
