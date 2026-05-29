---
applyTo: '**/*.js, **/*.ts, **/*.jsx, **/*.tsx'
title: React Front-End Architecture
description: 'How to structure and implement the React front-end.'
---

Use these guidelines when generating code, answering questions, or reviewing changes for this React application.

---

# React Front-End Architecture

## Structure

The project should be structured into six main directories:

1. **api**:

Contains all code responsible for external communication.
External systems include HTTP APIs, SDKs, browser storage used as remote state, analytics clients, and any
third-party service.

- It contains a `clients` directory in which is defined, for each external service, a client.
- It contains a `services` directory in which is defined, for each external use case, a function.
    - Each function must use a client to call the required external service.
- It contains a `hooks` directory in which is defined, for each service, a hook to wrap it for UI consumption.

The `api` directory is the only layer allowed to communicate with external systems.
Authorized React entry points must only use hooks from `api/hooks` to call external services. They must not use
`clients` or `services` directly.

2. **app**:

- It contains the [ApplicationName]App.tsx. The entrypoint of the javascript/typescript application
- It contains a `providers` directory in which are defined application's providers
- It contains a `router` directory containing the application's router and a `routes` directory containing the
  RootRouteObject.tsx defining base routes for the router
- It contains a `styles` directory for global css

3. **config**:

Contains application runtime configuration shared by `app` and `api`.

- It contains and exports appsettings.[env].json files.
- It must not import from `app`, `pages`, `widgets`, `shared`, or `api`.

4. **pages**:

It contains application pages. The route-level screens of the application.

- It contains [PageName] directories
    - [PageName] contains the [PageName].tsx
    - [PageName] contains a [ComponentName] directory for each custom component in the page
        - [Component] get information through props
        - [PageName] controls all the data and passes it to components

5. **shared**:

Contains generic reusable code for all the application

- It contains `components` directory for each reusable component
    - If the application uses any external component or design system, every component must be wrap in 'components'
      before being used
- It contains `hooks` for reusable hooks
- It contains `types`for reusable types/interfaces

6. **widgets**:

Contains shared business-oriented UI blocks composed of shared components and API data.
Widgets can be used by several pages, but they should remain focused on one visible feature or section.

## Implementation Scheme

```text
.
├── index.html
├── docs/
├── public/
│   ├── documents/
│   └── images/
└── src/
    ├── index.tsx
    ├── api/
    │   ├── index.ts
    │   ├── clients/
    │   │   ├── index.ts
    │   │   └── [ServiceName]Client.ts
    │   ├── services/
    │   │   ├── index.ts
    │   │   └── [featureName].ts
    │   └── hooks/
    │       ├── index.ts
    │       └── use[FeatureName]Query.ts 
    ├── config/
    │   ├── index.ts
    │   └── appsettings.[env].json
    ├── app/
    │   ├── index.ts
    │   ├── [AppName]App.tsx
    │   ├── providers/
    │   │   ├── index.ts
    │   │   └── [providerName]-provider/
    │   │       ├── index.ts
    │   │       └── [ProviderName]Provider.tsx
    │   ├── router/
    │   │   ├── index.ts
    │   │   ├── [ApplicationName]Router.ts
    │   │   └── Routes/
    │   │       ├── index.ts
    │   │       └── RootRouteObject.tsx
    │   └── styles/
    │       └── global.css
    ├── pages/
    │   ├── index.ts
    │   └── [PageName]Page/
    ├── shared/
    │   ├── components/
    │   │   ├── index.ts
    │   │   └── [ComponentName]Component/
    │   │       ├── [ComponentName]Component.module.css
    │   │       ├── [ComponentName]Component.tsx
    │   │       └── index.ts
    │   ├── hooks/
    │   │   ├── index.ts
    │   │   └── [hookName].ts
    │   └── types/
    │       ├── index.ts
    │       └── I[TypeName].ts
    └── widgets/
        └── [WidgetName]/
            ├── index.ts
            ├── [WidgetName].module.css
            └── [WidgetName].tsx
```

## Dependencies

The architecture should keep dependencies flowing in one direction:

```text
app -> pages
app -> api/hooks
app -> config
app -> shared
app -> widgets
pages -> api/hooks
pages -> shared
pages -> widgets
widgets -> api/hooks
widgets -> shared
api/hooks -> api/services
api/services -> api/clients
api/clients -> config
```

Rules:

1. **app** can import from `pages`, `shared`, `widgets`, `config`, and `api/hooks` only when wiring global concerns such
   as providers or routing. Providers can call hooks from `api/hooks` when they need external data to initialize or
   expose application-level state.
2. **pages** can import from `widgets`, `shared`, and `api/hooks`. Pages should coordinate data and layout, but must not
   store reusable UI logic that belongs in `widgets` or `shared`.
3. **widgets** can import from `shared` and `api/hooks`. **widgets** must not import from `pages` or `app`.
4. **shared** must not import from `pages`, `widgets`, `app`, or `api`. Shared code should stay generic and stable.
   Shared must also wrap any external components.
5. **api/hooks** can import from `api/services`.
6. **api/services** can import from `api/clients`.
7. **api/clients** contains external communication setup and can import runtime configuration from `config`.
8. **api** must not import from `app`, `pages`, `widgets`, or `shared`.
9. **config** must not import from `app`, `pages`, `widgets`, `shared`, or `api`.
10. Prefer public `index.ts` exports for cross-folder imports. Avoid deep imports into another module's private files
    unless the folder explicitly exposes that file as part of its contract.
11. Keep circular dependencies out of the codebase. If two modules need each other, extract the shared contract into
    `shared`.

## Data Fetching Boundaries

Only application providers, route-level pages, and root widgets can call hooks from `api/hooks`.

Allowed:

- `app/providers/[providerName]-provider/[ProviderName]Provider.tsx`
- `[PageName]Page.tsx`
- `[WidgetName].tsx`

Not allowed:

- shared components
- page-specific child components
- widget child components
- presentational components

Child components receive all external data through props.

## Imports

Note: this section is not about authorization, but only verification of the import path.

any import must not go deeper than :

- api/clients
- api/services
- api/hooks
- app/providers
- app/router
- app/styles
- config
- pages
- shared/components
- shared/hooks
- shared/types
- widgets

example :

ok:

```javascript
import Page1 from 'pages'
```

ko:

```javascript
import Page1 from 'pages/Page1'
```

ko:

```javascript
import Page1 from 'pages/Page1/Page1.tsx'
```

## Naming Conventions

Use clear and consistent names:

1. Shared Components
    1. use `PascalCase`.
    2. end with `Component`
2. Hooks
    1. use `camelCase`
    2. start with `use`.
3. providers
    1. use `kebab-case`
    2. end with provider

## Component Guidelines

1. Keep components small and focused on one rendering responsibility.
2. Use CSS modules for component-level styling. Global CSS should be reserved for resets, tokens, typography defaults,
   and app-wide layout primitives.
3. Reuse shared components before creating page-specific alternatives.
4. Move a page-specific component to `widgets` or `shared` only after it is reused or clearly belongs to a broader UI
   concept.
5. Keep data fetching out of presentational components. Data fetching must be handled by application providers,
   route-level pages, or root widgets through `api/hooks` and passed to child components as props.
6. Use arrow function with props typed `I[ComponentName]Props` as parameter

## API Guidelines

1. Keep global HTTP configuration in `api/clients`.
2. `api/clients` is the only directory allowed to configure low-level external clients.
3. `api/clients` can import runtime configuration from `config`.
4. `api/services` is the only directory allowed to call external clients directly.
5. Expose one request function per API use case. Each request function is defined as a service in the api/services
   directory.
6. Each service must be wrapped as a hook in api/hooks directory.
7. React components must consume external data only through hooks exported from api/hooks.
8. Keep API route strings centralized as consts.
