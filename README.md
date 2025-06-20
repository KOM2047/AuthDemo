# DualDashboardAuth

An ASP.NET Core MVC sample that implements custom cookie-based authentication and authorization—no Identity Framework—featuring two separate dashboards for **Admin** and **User** roles.

## Table of Contents

1. Features  
2. Prerequisites  
3. Getting Started  
4. Configuration  
5. Running the App  
6. Project Structure  
7. Authentication Flow  
8. Extending & Customizing  
9. Git Hygiene  
10. Contributing  
11. License  

## Features

- Cookie-based authentication (no Identity Framework)  
- In-memory user store with two demo accounts:  
  - **alice / P@ssword1** → Admin dashboard  
  - **bob   / P@ssword2** → User dashboard  
- Role-based authorization via `[Authorize(Roles="…")]`  
- Safe local redirect on login, CSRF protection  
- Clean separation of concerns (Models, Services, Controllers, Views)

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later  
- Visual Studio 2022 (or VS Code with C# extension)  
- Git (optional, for cloning)

## Getting Started

1. **Clone the repo**  
   ```bash
   git clone https://github.com/your-org/DualDashboardAuth.git
   cd DualDashboardAuth
Restore packages

bash
dotnet restore
Configuration
No extra configuration needed. All services and routes are set up in Program.cs. Credentials live in Services/InMemoryUserService.cs.

Running the App
CLI

bash
dotnet run
Browse to the URL shown (e.g. https://localhost:5001).

Visual Studio

Open DualDashboardAuth.sln

Press F5 or click Start Debugging

You’ll land on the login page at /Account/Login.

Project Structure
DualDashboardAuth/
├── Controllers/
│   ├── AccountController.cs
│   ├── AdminDashboardController.cs
│   └── UserDashboardController.cs
├── Models/
│   └── User.cs
├── Services/
│   ├── IUserService.cs
│   └── InMemoryUserService.cs
├── Views/
│   ├── Account/
│   │   ├── Login.cshtml
│   │   └── AccessDenied.cshtml
│   ├── AdminDashboard/
│   │   └── Index.cshtml
│   └── UserDashboard/
│       └── Index.cshtml
├── Program.cs
└── DualDashboardAuth.csproj
Authentication Flow
Login

POSTs credentials to AccountController.Login.

IUserService.Validate(...) returns a User or null.

On success: builds a ClaimsPrincipal, calls SignInAsync, then redirects by role.

On failure: re-displays the login form with an error.

Protected Dashboards

[Authorize(Roles="Admin")] secures AdminDashboardController.

[Authorize(Roles="User")] secures UserDashboardController.

Unauthorized access → /Account/AccessDenied.

Logout

Calls SignOutAsync, then redirects to /Account/Login.

Extending & Customizing
Swap in a database-backed IUserService (EF Core, Dapper, Web API).

Hash & salt passwords (e.g. BCrypt, PBKDF2).

Add custom claims (email, tenant ID) and policies.

Implement two-factor auth (TOTP) or external logins (OAuth/OpenID Connect).

Organize dashboards into Areas for large apps.

Git Hygiene
Commit only source files (.cs, .cshtml, .json, .csproj, .sln, etc.).

Exclude build artifacts like /bin/ in your .gitignore.

Keep secrets out of source—use environment variables or Secret Manager.

Contributing
Fork the repo

Create a branch for your feature

Commit your changes

Open a Pull Request

Ensure builds pass and code is formatted

License
This project is licensed under the MIT License.
