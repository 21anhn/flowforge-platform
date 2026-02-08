# US3.3 – Identity Service Skeleton

## 1. User Story

**As a** platform developer
**I want** a skeleton Identity Service
**So that** authentication & authorization can be integrated consistently across the platform.

---

## 2. Scope

### In Scope

* Identity service skeleton
* Clean Architecture layering
* Configuration, logging, health check

### Out of Scope

* Actual auth provider integration (Azure AD / Keycloak)
* Token issuance logic

---

## 3. Service Structure

```
FlowForge.Identity/
├─ FlowForge.Identity.Api/
├─ FlowForge.Identity.Application/
├─ FlowForge.Identity.Domain/
├─ FlowForge.Identity.Infrastructure/
└─ FlowForge.Identity.sln (optional)
```

---

## 4. Architecture Notes

* Reference `FlowForge.SharedKernel`
* No cross-service dependencies
* Infrastructure depends on Application & Domain

---

## 5. Acceptance Criteria

* [ ] Identity service builds successfully
* [ ] `/health` endpoint available
* [ ] Logging emits structured logs
* [ ] Configuration loaded via appsettings + env

---

## 6. Tasks Breakdown

* Create projects for each layer
* Wire dependencies
* Add health checks
* Add logging configuration

---

## 7. Deliverables

* Service skeleton committed
* Ready for US4 (Auth integration)

---

## 8. Definition of Done (DoD)

* Service starts without error
* Clean Architecture respected
