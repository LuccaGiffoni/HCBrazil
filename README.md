# HCBrazil PWA Application

This repository contains the source code for the HCBrazil PWA Application, a progressive web application developed using Blazor WebAssembly. The application is designed to manage campers, volunteers, and events for The Rawlings Foundation in Brazil.

## Architecture

The application is structured into three main projects:

1. **HCBrazil.Core**: This project contains the core models, requests, responses, and shared logic used across the application.
2. **HCBrazil.Api**: This project serves as the backend API, built with ASP.NET Core and Entity Framework Core (EF Core). It handles data persistence and business logic, and interacts with a MySQL database.
3. **HCBrazil.Web**: This project is the Blazor WebAssembly frontend application, utilizing MudBlazor for the UI components. It communicates with the backend API to fetch and manage data.

### Core Project (HCBrazil.Core)
- Contains models representing the domain entities (e.g., Attendee, Guardian).
- Contains request and response classes for API operations.
- Implements validation logic using Data Annotations.

### API Project (HCBrazil.Api)
- Built with ASP.NET Core 8.
- Uses Entity Framework Core for database interactions with a MySQL database.
- Contains controllers for managing attendees, guardians, and events.
- Implements authentication and authorization.

### Web Project (HCBrazil.Web)
- Built with Blazor WebAssembly.
- Uses MudBlazor for UI components and layout.
- Contains pages and components for managing campers, volunteers, and events.
- Implements PWA features for offline support.

## Task List

### Core Project
- [x] Define models for Attendee, Guardian, Event, and EventAttendees.
- [ ] Implement request classes with Data Annotations for validation.
- [ ] Implemente the services classes for all requests
- [x] Implement response classes for API responses.

### API Project
- [x] Set up ASP.NET Core API project.
- [x] Configure Entity Framework Core with MySQL.
- [ ] Implement AttendeesController with endpoints for creating and managing attendees.
- [ ] Implement GuardiansController with endpoints for creating and managing guardians.
- [ ] Implement authentication and authorization.
- [x] Implement migration and seeding logic for the database.

### Web Project
- [x] Set up Blazor WebAssembly project.
- [x] Configure MudBlazor for UI components.
- [x] Implement navigation and layout with a sidebar and navbar.
- [ ] Implement pages for managing attendees.
- [ ] Implement pages for managing guardians.
- [ ] Implement pages for managing events.
- [ ] Integrate PWA features for offline support.
- [ ] Implement authentication and authorization in the frontend.

### Prerequisites
- .NET 8 SDK
- MySQL Server
- Visual Studio

### Setting Up the Backend
1. Navigate to the `HCBrazil.Api` project directory.
2. Update the connection string in `appsettings.json` to point to your MySQL database.
3. Run the following commands to apply migrations and start the API:
   ```bash
   dotnet ef database update
   dotnet run
