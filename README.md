# ⚔️ Slash Bash 🎮

**Slash Bash** is a **fast-paced, top-down 1v1 fighter** where players engage in intense battles using unique characters with specialized attacks and combos. Designed for **local multiplayer**, the game features strategic combat mechanics, dynamic arenas, and fluid animations.

## 🚀 Key Features

- 🎭 **9 Unique Fighters** – Each character has **distinct fighting styles, abilities, and combo-based attacks**.
- 🎨 **Dynamic Arenas** – Hand-drawn **stunning environments** enhance the combat experience.
- 🕹️ **Skill-Based Combat** – Master **button combos** to unleash devastating **special moves**.
- 🎮 **Local Multiplayer** – **Optimized for controllers**, relive the fun of classic **couch gaming**.

## 🛠️ Development Techniques

### 🎭 **Character and Input System**
- **Finite State Machine (FSM) Implementation** – Controls **Idle, Attack, Block**, and transition logic.
- **Controller Input Mapping** – Supports **joystick movement, XYAB attacks, right shoulder for blocking**.
- **Auto-Save System** – Ensures **character selection persists** between battles.

### 🔥 **Skill & Attack Execution**
1. 🎮 **Player Input Handling** – Detects button presses to initiate **attack sequences**.
2. ⚡ **State Machine Transition** – Switches character to **Attack1, Attack2**, etc.
3. 🎨 **Dynamic Resource Loading** – Loads the **correct character animations and effects**.
4. 🎯 **Projectile System**:
   - Loads **bullet configurations**.
   - Generates **bullet prefabs** with speed, lifespan, and visual effects.
   - Positions bullets at the correct **spawn locations** with timing logic.
5. 💥 **Collision Handling** – Detects **hits and applies damage**.
6. 🧹 **Cleanup System** – **Removes bullets** after the **animation ends**.

### 🎮 **Quick Start Guide**
1. 🔌 **Connect Two Controllers** – Designed for **local multiplayer battles**.
2. 🏆 **Enter Character Selection Scene** – Choose a fighter (**auto-saves selection**).
3. ⚔️ **Start Battle Scene** – Your **previously selected character** loads in.
4. 🎭 **Use Controls**:
   - 🕹️ **Joystick** – Move your fighter.
   - ❌🟡🔵🟢 **XYAB** – Perform **different attacks**.
   - 🛡️ **Right Shoulder** – Activate **block**.

## 🎨 **Customization: Modify Skills**
- **Easily tweak skills** via **scriptable objects**.
- Adjust:
  - 🏃 **Animation Speed**
  - 💥 **Hit Effects**
  - 🎯 **Projectile Parameters**
  - ⏳ **Timing for Attacks**

---

🔥 Get ready to **slash, bash, and dominate** the battlefield! Let the best fighter win! 🏆🎮⚡
