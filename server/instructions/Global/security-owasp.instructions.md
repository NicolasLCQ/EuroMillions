---
applyTo: '*'
description: "Comprehensive secure coding instructions based on OWASP Top 10 and industry best practices."
---
# OWASP Guidelines

## Table of Contents
1. [Objective](#objective)
2. [General Principles](#general-principles)
3. [Best Practices for OWASP Top 10 2025](#best-practices-for-owasp-top-10-2025)
    - [A01: Broken Access Control](#a01-broken-access-control)
    - [A02: Security Misconfiguration](#a02-security-misconfiguration)
    - [A03: Software Supply Chain Failures](#a03-software-supply-chain-failures)
    - [A04: Cryptographic Failures](#a04-cryptographic-failures)
    - [A05: Injection](#a05-injection)
    - [A06: Insecure Design](#a06-insecure-design)
    - [A07: Authentication Failures](#a07-authentication-failures)
    - [A08: Software and Data Integrity Failures](#a08-software-and-data-integrity-failures)
    - [A09: Logging & Alerting Failures](#a09-logging--alerting-failures)
    - [A10: Mishandling of Exceptional Conditions](#a10-mishandling-of-exceptional-conditions)
4. [References](#references)
5. [Traceability and Documentation](#traceability-and-documentation)

---

## Objective
This file provides detailed instructions for generating secure code based on the OWASP Top 10 2025.
It is a practical guide to help you identify and mitigate common security vulnerabilities when generating, reviewing, or refactoring code.
You must follow the principles outlined below, which are based on the OWASP Top 10 2025 and other security best practices.

## General Principles
- **Secure by Default:** Always choose the most secure option when generating code. If there are multiple ways to implement a feature, prefer the one that minimizes security risks.
- **Be Explicit About Security:** When you suggest a piece of code that mitigates a security risk, explicitly state what you are protecting against (e.g., "Using a parameterized query here to prevent SQL injection.").
- **Educate:** When you identify a security vulnerability in the code, you must not only provide the corrected code but also explain the risk associated with the original pattern.

---

## Best Practices for OWASP Top 10 2025

### A01: Broken Access Control
- **Enforce Principle of Least Privilege:** Always default to the most restrictive permissions. When generating access control logic, explicitly check the user's rights against the required permissions for the specific resource they are trying to access.
- **Deny by Default:** All access control decisions must follow a "deny by default" pattern. Access should only be granted if there is an explicit rule allowing it.
- **Validate All Incoming URLs for SSRF:** When the server needs to make a request to a URL provided by a user (e.g., webhooks), you must treat it as untrusted. Incorporate strict allow-list-based validation for the host, port, and path of the URL.
- **Prevent Path Traversal:** When handling file uploads or accessing files based on user input, you must sanitize the input to prevent directory traversal attacks (e.g., `../../etc/passwd`). Use APIs that build paths securely.

### A02: Security Misconfiguration
- **Secure by Default Configuration:** Recommend disabling verbose error messages and debug features in production environments.
- **Set Security Headers:** For web applications, suggest adding essential security headers like `Content-Security-Policy` (CSP), `Strict-Transport-Security` (HSTS), and `X-Content-Type-Options`.

### A03: Software Supply Chain Failures
- **Verify Third-Party Libraries:** When suggesting third-party libraries, recommend checking their reputation, maintenance status, and known vulnerabilities using tools like Checkmarx SCA.
- **Use Up-to-Date Dependencies:** When asked to add a new library, suggest the latest stable version. Remind the user to run vulnerability scanners (like `npm audit`, `pip-audit`), or Checkmarx SCA to check for known vulnerabilities in their project dependencies.

### A04: Cryptographic Failures
- **Use Strong, Modern Algorithms:** For hashing, always recommend modern, salted hashing algorithms like Argon2 or bcrypt. Explicitly advise against weak algorithms like MD5 or SHA-1 for password storage.
- **Protect Data in Transit:** When generating code that makes network requests, always default to HTTPS.
- **Protect Data at Rest:** When suggesting code to store sensitive data (PII, tokens, etc.), recommend encryption using strong, standard algorithms like AES-256.
- **Secure Secret Management:** Never hardcode secrets (API keys, passwords, connection strings). Generate code that reads secrets from environment variables.
  Include a clear placeholder and comment.

### A05: Injection
- **Use a ORM (Object-Relational Mapping) Library:** When interacting with databases, prefer using an ORM (like `hibernate`, `EF Core`) that abstracts SQL queries and automatically handles parameterization.
- **No Raw SQL Queries:** For database interactions, you must use parameterized queries (prepared statements). Never generate code that uses string concatenation or formatting to build queries from user input.
- **Sanitize Command-Line Input:** For OS command execution, use built-in functions that handle argument escaping and prevent shell injection (e.g., `shlex` in Python).
- **Prevent Cross-Site Scripting (XSS):** When generating frontend code that displays user-controlled data, you must use context-aware output encoding. Prefer methods that treat data as text by default (`.textContent`) over those that parse HTML (`.innerHTML`). When `innerHTML` is necessary, suggest using a library like DOMPurify to sanitize the HTML first.

### A06: Insecure Design
- **Adopt Secure Design Principles:** Always recommend following secure design principles such as defense in depth, fail-safe defaults, and secure by design.
- **Threat Modeling:** Encourage users to perform threat modeling during the design phase to identify potential security risks and mitigate them early in the development lifecycle.

### A07: Authentication Failures
- **When end-users are external** Suggest to use `X-connect`
- **When end-users are internal** Suggest to use `One Account`

### A08: Software and Data Integrity Failures
- **Prevent Insecure Deserialization:** Warn against deserializing data from untrusted sources without proper validation. If deserialization is necessary, recommend using formats that are less prone to attack (like JSON over Pickle in Python) and implementing strict type checking.

### A09: Logging & Alerting Failures
- **Implement Proper Logging and Monitoring:** When generating code that includes logging, ensure that sensitive information (like passwords, PII, address) is never logged. Recommend using structured logging formats (like JSON) for better analysis and monitoring.

### A10: Mishanling of Exceptional Conditions
- **Graceful Error Handling:** Always suggest handling exceptions gracefully without exposing stack traces or sensitive information to end-users. Use generic error messages for users and log detailed errors securely for developers.

---

## References
- [OWASP Top 10 - 2025](https://www.owasptopten.org/)
- [OWASP TOP 10 Project](https://owasp.org/www-project-top-ten/)
- [Checkmarx One Documentation](https://confluence.axa-fr.intraxa/spaces/VAESDS/pages/609816295/Checkmarx+One+CxOne)
- [Checklist avant Pentest](https://confluence.axa.com/confluence/spaces/AFAGUILDS/pages/68518230/Checklist+avant+Pentest)
- [Checklist du 3 Amigos](https://confluence.axa.com/confluence/spaces/AFAGUILDS/pages/243324454/Checklist+du+3+Amigos)
- [Bonne Pratique par Faille](https://confluence.axa.com/confluence/spaces/AFAGUILDS/pages/119350982/Bonnes+pratiques+par+faille)

---

## Traceability and Documentation

- When answering security questions or implementing features, always cite this file: `.github/instructions/security-owasp.instructions.md`.

---