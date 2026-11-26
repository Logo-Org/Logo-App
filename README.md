# LogoApp – Backend

REST API for **LogoApp**, a mobile app that supports speech therapy between sessions. Speech therapists assign exercises from a shared library, patients practise at home, and therapists follow their progress.

Engineering thesis project at the Polish-Japanese Academy of Information Technology (PJATK), Warsaw.
**Title:** 

*System wspomagania terapii logopedycznej z modułem zdalnej realizacji ćwiczeń*
(Speech therapy support system with a remote exercise module)

**Status:** in development

---

## Features

- **Accounts and roles:** separate speech therapist and patient roles, JWT-based authentication
- **Patient management:** therapists add patients, who receive an email invitation to activate their account
- **Exercise library:** a shared, Polish-language library of exercises with descriptions and instructions
- **Therapy plans:** therapists assign exercises with frequency, number of repetitions and duration
- **Progress tracking:** patients mark exercises as done or report difficulties, and therapists see progress over time
- **Visit history:** exercises done during sessions alongside homework completion

## Tech stack

| Area | Technology |
|---|---|
| Language | C# |
| Framework | ASP.NET Core Web API |
| Data access | Entity Framework Core (code first, migrations) |
| Database | PostgreSQL |
| Authentication | ASP.NET Core Identity, JWT |
| API docs | OpenAPI |
| Containers | Docker |
| Mobile client | React Native, Expo, TypeScript (separate repository) |

## Authors

- **Wiktor Szczepanik**
- **Konrad Dominowski**

Supervisor: dr inż. Mariusz Trzaska

## Data protection

The system is designed to process health-related data, which is a special category of personal data under the GDPR (RODO). Never commit real patient data to this repository. Use only test data for development and demos.