# AGENTS.md — Goalkeeper VR (U.RealGoalKeeper)

## Project Context
- **Engine**: Unity 6 (6000.0.67f1), Universal Render Pipeline (URP).
- **Platform**: Meta Quest VR. Meta XR SDK `83.0.4` is installed via Package Manager.
- **DoTween**: DoTween + DoTweenPro are present under `Assets/Plugins/Demigiant/`.
- **No npm/build tools**: This is a standard Unity project. Do not look for `package.json`, CI workflows, or build scripts.

## Architecture Skills (`.agents/skills/`)
The project defines custom architectural conventions in `.agents/skills/`:
- `ufolder` — Folder hierarchy rules.
- `ufeature` — Feature module pattern (Model, Handler, logic classes).
- `uservice` — Global service pattern.
- `uui` — UI naming and `BaseButtonAttendant` usage.

**Critical**: When a task mentions terms starting with `u` (e.g., `ufeature`, `uservice`), load the corresponding skill.

## Reality vs. Skill Definitions
The skills describe an ideal architecture, but the current codebase diverges in important ways:
- **No Zenject**: Despite `ufolder` mentioning `Installers/` and Zenject, the project does **not** contain Zenject. Dependency injection is manual or via the `Singleton<T>` pattern from `B_Extensions`.
- **Existing Features use MonoBehaviour controllers**: The existing `Form` feature uses `FormController` (MonoBehaviour), not the strict Handler/Model/Logic separation from `ufeature`. Follow the skill for **new** features unless the user explicitly asks to match existing legacy patterns.
- **Legacy scripts live outside `Features/`**: Several scripts (e.g., `GameEventBus`, `ScoreManager`, `BallVR`) are directly under `Assets/Code/Scripts/`, not inside `Features/`.

## Custom Plugin: `B_Extensions`
Located at `Assets/ExternalAssets/B_Extension/`. **Do not modify** anything under `Assets/ExternalAssets/`.
Key utilities used across the codebase:
- `B_Extensions.Singleton<T>` — Generic singleton MonoBehaviour base class.
- `ICopy<T>` — Interface for models; implement `Copy()` with `MemberwiseClone()`.
- `BaseButtonAttendant` — Base class for UI buttons. Access the Unity `Button` via `buttonComponent`, and `Toggle` via `toggleComponent`. Example: `buttonComponent.AddListener(...)`.

## Folder Rules (`ufolder`)
- `Assets/Code/Scripts/Features/` — Feature-specific logic.
- `Assets/Code/Scripts/Services/` — Global services (currently empty; create here).
- `Assets/Level/Scenes/` — Scene files.
- `Assets/Level/Prefabs/` — Prefabs.
- `Assets/ExternalAssets/` — Read-only third-party plugins.
- Do **not** create new root folders under `Assets/` without asking.

## UI Conventions (`uui`)
- UI scripts live inside the Feature folder: `Features/[Name]/UI/`.
- Naming: `[Type][Feature][Purpose]`, e.g., `CardBoss`, `ButtonClaimReward`, `ScreenWinBoss`.
- Prefer inheriting from `BaseButtonAttendant` for buttons instead of raw `MonoBehaviour` + `Button` references.

## Global Event Bus
- `GameEventBus` (Singleton) already exists in `Assets/Code/Scripts/GameEventBus.cs`.
- It exposes static `Subscribe` / `Unsubscribe` / `Publish` methods keyed by `StateGameType` enum (`Start`, `End`, `Practicing`).

## Product Requirements & Specs
- Check `.agents/PRD.md` for high-level product requirements.
- Feature plans go in `.agents/specs/` following the existing naming convention: `N_Descripción.md`.

## .meta Files
Unity `.meta` files under `Assets/` are tracked by git (`!/[Aa]ssets/**/*.meta` in `.gitignore`). When creating or moving assets, ensure `.meta` files are handled correctly.
