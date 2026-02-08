# Workflow Automation Platform

A backend-first **event-driven workflow automation platform** designed for
long-running workflows, reliability, and scalability.

## 🎯 Goals
- Execute long-running workflows reliably
- Apply production-grade backend patterns
- Serve as a long-term learning and potential commercial project

## 🏗 Architecture Overview
- Microservices
- Event-driven communication
- Centralized workflow orchestration (Saga-based)
- CQRS (EF Core for write, Dapper for read)

## 🧰 Technology Stack
- .NET
- AKS
- Azure Service Bus
- Azure Functions
- PostgreSQL
- Redis
- Azure Blob Storage

## 📂 Repository Structure
- `/docs` Architecture, ADRs, planning
- `/src` Application source code
- `/infrastructures` Infrastructure and deployment

## 📑 Documentation
- ADRs: `docs/adr`
- Work Breakdown Structure: `docs/wbs`
- Backlog & Sprints: `docs/backlog`

## 🚧 Project Status
This project is under active development.  
Architecture decisions are tracked using ADRs.