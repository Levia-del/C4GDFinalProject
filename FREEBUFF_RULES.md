# Freebuff Rules — C4GDFinalProject

This file governs how Buffy (the AI coding agent) operates on this Unity 2D mini-game project.
These rules must be followed without exception.

---

## 1. Prompt Logging — PROMPT_LOG.md

- **After every user prompt**, update `PROMPT_LOG.md` with a new entry.
- Each entry must include:
  - **Date/Time** — Timestamp of the prompt.
  - **Prompt** — The full text of what the user asked.
  - **Achievement** — A brief explanation of what was accomplished in response.
- Append new entries at the top (most recent first).

## 2. Feature Tracking — FEATURES.md

- Every time a gameplay component, system, or significant UI element is completed, update `FEATURES.md`.
- Mark completed items with a `✅` checkmark.
- Each feature entry must include:
  - **Feature name** — Short, descriptive title.
  - **Status** — ✅ (completed) or ⬜ (planned/in progress).
  - **Description** — A brief explanation of how the feature works, its inputs, outputs, and interactions.
- Keep features grouped logically (e.g., "Core Systems", "Minigames", "UI/Screens").

## 3. README.md — Project Documentation

- Maintain a professional `README.md` in the project root.
- Keep the following sections updated as the project evolves:
  - **Title & Badges** — Project name with Unity version and status badges.
  - **Overview** — A concise summary of the game concept.
  - **Full Feature List** — All implemented features with brief descriptions.
  - **Getting Started** — Prerequisites, installation, and how to run the game.
  - **Project Structure** — High-level file/folder layout.
  - **How to Play** — Controls and rules per minigame.
  - **Built With** — Unity version and key packages (DOTween, TextMeshPro).
  - **Credits** — Team/contributor info.

## 4. Documentation Updates

- Any time a feature is added, removed, or significantly changed, update all three files (FEATURES.md, README.md, and PROMPT_LOG.md) to reflect the change.
- Never let documentation become stale — if you're making code changes, update docs in the same session.
