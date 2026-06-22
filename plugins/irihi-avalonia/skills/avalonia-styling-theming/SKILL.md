---
name: avalonia-styling-theming
description: >
  Guidance for scalable Avalonia styling and theming across IRIHI Tech products,
  including reusable style resources, dark/light themes, and control consistency.
license: MIT
---

# Avalonia Styling and Theming

Use this skill when designing or refactoring Avalonia styles and themes.

## Goals

- Centralize design tokens and reusable styles.
- Ensure consistent behavior in dark and light themes.
- Avoid one-off local style overrides when shared resources are possible.

## Practices

1. Keep theme resources in shared dictionaries and load them in app-level styles.
2. Separate color tokens from control templates to simplify global visual changes.
3. Validate custom controls under both themes to avoid unreadable states.
4. Prefer style classes and selectors over repetitive per-control property settings.
