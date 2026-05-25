---
applyTo: '**/*.cs'
title: Technical guilelines for C#
description: 'Technical guilelines for C#.'
---

Provide context and coding guidelines that AI should follow when generating code, answering questions, or reviewing changes.

---


# Technical Guidelines :

- Use dependency injection with prefered order : Transients > Scoped.
    - Use singleton if it is the best practice for the implementation.
- Use minimal API
- Follow SOLID principles within each layer.
- Prefer Manual Mappers
- One class per file.
- No method in models.
- Prefered async/await over synchronous methods.