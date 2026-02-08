# Contributing Guidelines

## Branching Strategy
We use a simplified Git Flow:

- `main`: stable branch
- `develop`: active development
- `feature/*`: new features
- `fix/*`: bug fixes
- `chore/*`: maintenance tasks

## Commit Message Convention

Format:
- `<type>: <short description>`

Types:
- feat: new feature
- fix: bug fix
- chore: tooling / infra
- docs: documentation
- refactor: code refactoring
- test: adding tests

Example:
- feat: add workflow execution aggregate

## Pull Requests
- One logical change per PR
- Must pass CI