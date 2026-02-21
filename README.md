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
   

## 📊 Logging

   > Log Mechanizm
         Implementation SeriLog based on appsettings.json configuration file. Sending logs to console and SEQ. Masking confidential data.

# <img width="25" height="25" alt="image" src="https://github.com/user-attachments/assets/5236f884-0956-4aff-b614-b28d8013496c" /> General Architecture
[View Clean Architecture Diagram on Miro](https://miro.com/app/board/uXjVG8ul8Cw=/)
