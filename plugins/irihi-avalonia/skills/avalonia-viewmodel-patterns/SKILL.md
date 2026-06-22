---
name: avalonia-viewmodel-patterns
description: >
  Guide for implementing maintainable Avalonia MVVM view models with observable state,
  command patterns, and testable presentation logic for IRIHI Tech applications.
license: MIT
---

# Avalonia ViewModel Patterns

Use this skill when creating or updating Avalonia view models.

## Goals

- Keep UI logic in view models, not in views.
- Favor explicit state and commands.
- Keep view models unit-testable without UI dependencies.

## Practices

1. Use clear model-to-view-model mapping and avoid hidden side effects in setters.
2. Expose command state (`CanExecute`) from business rules, then notify command updates when dependent state changes.
3. Inject service dependencies behind interfaces for easier testing.
4. Keep long-running operations async and expose loading/error state for the view.
