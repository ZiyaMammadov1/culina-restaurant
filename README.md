# Culina restorant services

>An interview-oriented polyglot microservices architecture


## 📖 Table of Services


- AuthService

---

## ⚙️ Details of Services

1. **AuthService**:
   - With `clean architecture`
   - Based on JSON Web Token`(JWT)`
   - `Authorization` and `Authentication` process

- Domain
   > Core - Rich domain models, Result pattern (railway oriented) approach, factory method design pattern, typesafe provision                with Value object, carrier of domain logic

   > Core error handler - Generic domain error and its various applications
   
- Application
   > Core - Abstract repositories of domain models and use cases that connect domain models to them
   
   > Core error handler - With Result Pattern
   
- Infrastructure
   > Core - Base context. Base models. Profile list that converts rich domain models into entity models.
            İmplementation of Repositories in the Application layer
   

## 📨 Event-Driven Communication

Services communicate asynchronously using **Domain Events** and **Integration Events**.

- Domain Event
   > **Core** — Raised inside the aggregate itself when something meaningful happens. Stays within the service boundary, dispatched in-process via `MediatR`. Created before mapping to DB entity, so events are extracted from the aggregate in the UseCase before passing to the repository — otherwise they'd be lost after mapping.

   > **Dispatch** — UseCase is responsible for dispatching domain events, not the repository. Repository has one job: persistence.

- Integration Event
   > **Core** — Published to external services via `MassTransit` and `RabbitMQ`. Converted from a domain event inside the handler. Minimal, serializable DTO — carries only what other services need.

   > **Flow**
   ```
   User.Create()
     → UserCreatedDomainEvent (in-memory)
     → UseCase extracts events
     → Repository saves to DB
     → MediatR dispatches to handler
     → Handler publishes UserCreatedIntegrationEvent
     → MassTransit → RabbitMQ → next service
   ```



## 📊 Logging
> Log Mechanism

Logging in this project is implemented using **SeriLog**, fully configurable via the `appsettings.json` file. Key features include:

- **Multiple Sinks:** Logs are sent to both the **console** for local debugging and **SEQ** for centralized log management.
- **Structured Logging:** Provides rich, structured log data for easier querying and analysis.
- **Correlation & Context:** Automatically tracks request or operation IDs for better traceability across services.
- **Sensitive Data Masking:** All confidential information (e.g., passwords, API keys) is securely masked to prevent accidental exposure.
- **Flexible Configuration:** Log levels and outputs can be modified dynamically via `appsettings.json` without code changes.

This setup ensures robust monitoring, quick debugging, and compliance with security best practices.

## <img width="25" height="25" alt="image" src="https://github.com/user-attachments/assets/5236f884-0956-4aff-b614-b28d8013496c" /> General Architecture
[View Software Architecture Diagram on Miro](https://miro.com/app/board/uXjVG8ul8Cw=/)

# CI/CD Pipeline

This project uses **Continuous Integration / Continuous Deployment (CI/CD)** automated through GitHub Actions.  

## Pipeline Purpose

- Automatically run **build**, **test**, and **deploy** steps whenever code changes are committed.
- Filter commits with specific tags in the commit message (e.g., `[deploy]`, `[build]`).
- Ensure the application on the server is always up-to-date and functional.

## Usage Instructions

1. Include the relevant tag in your commit message:
   - `[build]` → triggers only the build stage
   - `[deploy]` → triggers both build and deploy stages
2. Secrets (`API_KEY`, `ServerIp`, `Username`, `Password`) are stored securely using GitHub Secrets.
3. Deployment only occurs when pushing to specific branches (`master`).
