---
applyTo: '**/*.cs'
title: Clean architecture in C#
description: 'How to implement Clean architecture in C#.'
---

Provide context and coding guidelines that AI should follow when generating code, answering questions, or reviewing changes.

---

# Clean Architecture

## Structure

The project should be structured into three main layers:

1. **API**:

The API layer is the entry point for the application.
It exposes endpoints for clients to interact with.
It also handles exceptions and errors.
It handles the mapping between **API** models and **Application** models.
Ressources (or controllers) handle incoming requests, validate them, and delegate processing to the Application layer.

 - It uses **Resources** to process requests.
 - It uses **Routes** to handle routing. A route is a path to a resource.
 - It uses **Models** to implement request and response models.
 - It uses **Extensions** to implement model methods.
 - It uses **Helpers** to implement common methods.
 - It uses **Mappers** to convert between **API** models and **Application** models.
 - It uses **Middleware** to handle exceptions, errors, authentification, logging, ... .
 - It uses **Validators** to validate requests.

2. **Application**:

The Application layer is responsible of business logic.
It uses Use Cases to perform tasks.
It interacts with other layers throught Interfaces implementations when it needs to use external services.
It is also responsible of generating business errors.
It does not handle mapping between layers.

 - It uses **UseCases** to handle business logic.
 - It uses **Interfaces** that the Gateway layer implements to interact with external services.
 - It also uses **Interfaces** to expose his own services.
 - It uses **Models** to implement business models.
 - It uses **Extensions** to implement model methods.
 - It uses **Helpers** to implement common methods.

3. **Gateway**:

The Gateway layer is responsible of communication with external services.
It is also responsible of handling external errors.
It is also responsible of mapping between **Gateway** models and **Application** models.

 - It uses **WebServices** to communicate with web accessible services.
 - It uses **Adapters** to communicate with the System.
 - It uses **Models** to implement external models.
 - It uses **Mappers** to convert between **Gateway** models and **Application** models.
 - It uses **Extensions** to implement models methods.
 - It uses **Helpers** to implement common methods.

Schéma d'implémentation :

```
/src
├─ [NomApplication].sln
├─ /[NomApplication].Api
│  ├─[NomApplication].Api.csproj
│  ├─ Ressources(or controllers)/
│  ├─ Routes/
│  ├─ Models/
│  ├─ Extensions/
│  ├─ Helpers/
│  ├─ Mappers/
│  ├─ Middleware/
│  ├─ Validators/
│  └─ Program.cs
├─ /[NomApplication].Application
│  ├─[NomApplication].Application.csproj
│  ├─ Extensions/
│  ├─ Helpers/
│  ├─ Interfaces/
│  ├─ Models/
│  └─ UseCases/
│     ├─domain1.cs
│     ├─domain1.usecase1.cs
│     ├─domain1.usecase2.cs
│     ├─domain2.cs
│     └─domain2.usecase1.cs
└─ /[NomApplication].Gateway
   ├─ [NomApplication].Gateway.csproj
   ├─ WebServices/
   ├─ Adapters/
   ├─ Extensions/
   ├─ Helpers/
   ├─ Models/
   └─ Mappers/
```

## Implementation

Références de projets (csproj):

```
`[NomApplication].Api.csproj` -> `[NomApplication].Gateway.csproj` -> `[NomApplication].Application.csproj`
`[NomApplication].Api.csproj` --------------------------------------> `[NomApplication].Application.csproj`
```
Remarques : 
 - `[NomApplication].Application.csproj` ne référence aucun autre projet.