# US3.2 – SharedKernel & Building Blocks

## 1. User Story

**As a** backend developer / system architect
**I want** a SharedKernel containing core domain abstractions
**So that** all services share consistent domain rules, reduce duplication, and avoid early technical debt.

---

## 2. Scope

### In Scope

* SharedKernel project initialization
* Core domain abstractions
* Cross-cutting primitives used across services

### Out of Scope

* Business-specific domain logic
* Infrastructure-specific implementations
* Messaging / Outbox logic (handled in later US)

---

## 3. Design Principles

* Domain-first, framework-agnostic
* No dependency on ASP.NET Core
* Minimal but extensible abstractions
* Safe for reuse across all microservices

---

## 4. Project Structure

```
FlowForge.SharedKernel/
├─ Abstractions/
│  ├─ Entity.cs
│  ├─ AggregateRoot.cs
│  ├─ ValueObject.cs
│  └─ DomainEvent.cs
│
├─ Primitives/
│  ├─ Result.cs
│  ├─ Error.cs
│  └─ Guard.cs
│
└─ FlowForge.SharedKernel.csproj
```

---

## 5. Core Components Description

### 5.1 Entity

* Base class for all entities
* Strongly typed `Id`
* Equality by identity

### 5.2 AggregateRoot

* Inherits from `Entity`
* Holds domain events
* Controls aggregate consistency

### 5.3 ValueObject

* Immutable
* Equality by value
* No identity

### 5.4 DomainEvent

* Represents something that *has happened* in the domain
* Used for internal domain communication

---

## 6. Result & Error Handling

### Result<T>

* Encapsulates success / failure
* Avoids exception-driven flow
* Explicit error propagation

### Error

* Code + message
* Can be extended with metadata

---

## 7. Acceptance Criteria

* [ ] SharedKernel project builds successfully
* [ ] No dependency on Web / Infrastructure packages
* [ ] Can be referenced by any service
* [ ] Base abstractions cover common domain needs

---

## 8. Tasks Breakdown

### Task 1 – Create SharedKernel Project

* .NET Class Library
* Target framework aligned with solution

### Task 2 – Implement Domain Abstractions

* Entity
* AggregateRoot
* ValueObject
* DomainEvent

### Task 3 – Implement Primitives

* Result<T>
* Error
* Guard utilities

### Task 4 – Add Unit Test Project (Optional)

* Validate equality rules
* Validate Result behavior

---

## 9. Deliverables

* Project: `FlowForge.SharedKernel`
* Commit: `feat(us3.2): add shared kernel abstractions`

---

## 10. Risks & Notes

* Over-generalization too early
* Keep API surface minimal
* Evolve only when multiple services require it

---

## 11. Definition of Done (DoD)

* Code compiles
* Clean public API
* Ready to be consumed by Identity Service
