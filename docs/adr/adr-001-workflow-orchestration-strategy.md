# ADR-001: Workflow Orchestration Strategy

**Status:** Accepted
**Date:** 2026-02-08
**Decision Makers:** PM / BO / SA
**Project:** Workflow Automation Platform (Event-Driven Microservices)

---

## 1. Context

The system must execute **long-running workflows** composed of multiple steps that may:

* Run asynchronously
* Fail and retry
* Timeout
* Resume after crash or redeploy
* Scale horizontally

Workflows can be triggered by:

* HTTP requests
* External system events
* Scheduled triggers

The platform is designed as a **learning-first but production-grade backend system**, with potential future commercialization.

Target infrastructure:

* AKS for core services
* Azure Functions for lightweight triggers
* Azure Service Bus for messaging
* Azure Blob Storage for large payloads
* On-prem PostgreSQL (cloud-ready later)

Key non-functional requirements:

* High reliability
* Clear observability and debuggability
* Explicit orchestration logic
* Avoid excessive platform lock-in

---

## 2. Problem Statement

We need a strategy to coordinate workflow execution across distributed services while ensuring:

* Correct execution order
* Failure isolation
* State persistence
* Idempotent behavior
* Ability to reason about execution state at any point in time

The orchestration strategy must balance:

* Architectural clarity
* Learning value (Saga, state machine, distributed systems)
* Realistic enterprise-grade design

---

## 3. Options Considered

### Option A: Choreography-Based Workflow

Each service reacts to events and emits new events to progress the workflow.

**Pros:**

* High decoupling
* Naturally event-driven
* Easy to add new consumers

**Cons:**

* No single source of truth for workflow state
* Very difficult to trace and debug
* Execution order and retries are implicit
* Not suitable for complex long-running workflows

**Decision:** ❌ Rejected

---

### Option B: Azure Durable Functions as Core Orchestrator

Use Azure Durable Functions to manage workflow execution and state.

**Pros:**

* Built-in orchestration
* Automatic state persistence
* Minimal custom code

**Cons:**

* Strong Azure lock-in
* Hides orchestration mechanics (low learning value)
* Limited flexibility for custom retry, idempotency, and event modeling
* Difficult to migrate to self-hosted or SaaS scenarios

**Decision:** ❌ Rejected (Durable Functions may be used only for triggers)

---

### Option C: Centralized Workflow Orchestration Service (Saga-Based)

Introduce a dedicated **Workflow Orchestrator Service** responsible for:

* Holding workflow execution state
* Deciding next steps
* Emitting commands/events
* Handling retries and failures

**Pros:**

* Single source of truth for execution state
* Explicit orchestration logic
* Easy debugging and observability
* Strong learning value (Saga, state machine)
* Suitable for enterprise and SaaS backends

**Cons:**

* Higher implementation complexity
* Requires careful state and concurrency design

**Decision:** ✅ Accepted

---

## 4. Decision

The system will use a **Centralized Orchestration Model** implemented as a **Saga-based Workflow Orchestrator Service**.

The orchestrator is responsible for managing the lifecycle of each workflow execution.

High-level flow:

```
Trigger
  ↓
Workflow Orchestrator
  ↓
Step Execution Services
  ↓
Execution Result Events
  ↓
Workflow Orchestrator (state update)
```

---

## 5. Execution Model

### 5.1 Workflow Execution as an Aggregate

Each workflow execution is treated as a **Saga instance**.

Core attributes:

* ExecutionId
* WorkflowDefinitionId
* WorkflowVersion
* CurrentStep
* ExecutionStatus (Running | Completed | Failed | Suspended)
* StartedAt
* LastUpdatedAt

Each execution is:

* Persisted durably
* Resume-capable
* Idempotent

---

### 5.2 Step Execution

* The orchestrator sends a **Command** to a step execution service
* The execution service performs work and emits a **StepCompleted** or **StepFailed** event
* The orchestrator consumes the event and transitions state

Delivery semantics:

* At-least-once messaging
* Mandatory idempotency at command and event handlers

---

## 6. State Persistence Strategy

* Workflow execution state is persisted in the Orchestrator database
* Messaging uses the **Outbox Pattern** to ensure atomicity between state change and event publication
* Large payloads are stored in **Azure Blob Storage**, referenced by URI

The system does **not** rely on the message broker for state persistence.

---

## 7. Failure Handling

| Scenario               | Handling Strategy                         |
| ---------------------- | ----------------------------------------- |
| Step execution failure | Retry according to policy                 |
| Retry exhausted        | Mark execution as Failed                  |
| Orchestrator crash     | Resume from persisted state               |
| Duplicate messages     | Ignored via idempotency                   |
| Message reordering     | Handled via execution/session identifiers |

---

## 8. Consequences

### Positive Consequences

* Clear execution traceability
* Strong observability
* Explicit and testable orchestration logic
* High learning value for distributed systems
* Suitable foundation for future commercialization

### Trade-offs

* Increased implementation complexity
* Requires careful concurrency and state modeling

These trade-offs are acceptable given the project goals.

---

## 9. Follow-up Decisions Required

* Detailed workflow state machine
* Event naming conventions and contracts
* Azure Service Bus partitioning and session strategy
* Multi-tenancy isolation model
* Versioning strategy for workflow definitions

---

## 10. References

* Saga Pattern
* CQRS
* Outbox Pattern
* Event-Driven Architecture

---

**Next Document:** `WBS-v1.md`
