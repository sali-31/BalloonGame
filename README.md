# Balloon Game (Balloon Burst)

A simple 2D balloon–popping action game made in Unity for **CISC 3667 – Game Design and Development**.

You play as **Goku on Nimbus** on **Supreme Kai’s Planet**, sliding left and right at the bottom of the screen and firing pins upward to pop a moving, growing balloon. DBZ enemies act as moving blockers that force you to aim and time your shots carefully.

---

## 🎮 Gameplay Overview

- The **balloon** moves horizontally across the sky and slowly **grows** over time.
- If the balloon reaches a **maximum size**, the **current level restarts**.
- You control **Goku on Nimbus** at the bottom of the screen:
  - Move left/right to line up your shot.
  - Fire pins straight upward to hit the balloon.
- **Enemies (Saibaman, Frieza)** move back and forth and can **block your pins**, forcing you to reposition.
- The game has **three levels** and **multiple difficulty settings**:
  - Higher difficulty → faster growth / movement / more blockers.

---

## 🕹 Controls

**In-game controls**

- **Move Left:** `←` or `A`
- **Move Right:** `→` or `D`
- **Shoot Pin:** `Space` or `Left Ctrl`
- **Pause / Main Menu:** `Esc`

**Menus**

- Mouse / trackpad to:
  - Click **Play Game**
  - Click **Settings**
  - Click **Instructions**
  - Click **High Scores**
  - Use **slider** for volume, **dropdown** for difficulty, and buttons to go back.

---

## 🎯 Goals & Scoring

**Goal per level**

- **Pop the balloon** before it reaches its **max size**.
- Avoid letting it grow too large:
  - If the balloon hits max size → level restarts.
  - If you hit it with a pin → level complete, move to the next one.

**Scoring**

- Score is handled in `GameManager`.
- When you pop the balloon, the score added is based on the balloon’s size:

  ```csharp
  int points = Mathf.RoundToInt(100f / balloonSize);
