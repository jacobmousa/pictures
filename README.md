# 📷 Personal Pictures System

A full-stack web-based application to upload and manage personal pictures. Built with:

- **Frontend**: React + Bootstrap
- **Backend**: .NET 9 WebAPI + Entity Framework Core
- **Database**: SQL Server
- **DevOps**: Docker & Docker Compose

---

## ✨ Features

- Upload picture files with metadata (name, date, description)
- Display list of uploaded pictures
- Validation and error handling
- Reset form with confirmation
- Responsive UI using Bootstrap
- Dockerized: API, DB, and frontend run in containers

## 📦 Frontend Structure
```
frontend-react/
├── src/
│   ├── api/
│   │   └── picturesApi.ts
│   ├── components/
│   │   ├── PictureForm.tsx
│   │   └── PictureList.tsx
│   └── App.tsx
├── public/
│   └── index.html
├── index.tsx
└── package.json
```

## 🗂️ Backend Structure
```
backend/
├── Pictures.Api/             # ASP.NET Core Web API
├── Pictures.Application/     # Application services (interfaces, DTOs)
├── Pictures.Domain/          # Entities and domain logic
└── Pictures.Infrastructure/  # EF Core DbContext, Repositories
---

## 🚀 How to Run Using Docker Compose

Ensure you have a working Docker environment, then:

1. Clone the project:
```bash
git clone https://github.com/YOUR_USERNAME/pictures.git
cd pictures
```

2. Start the full stack using Docker Compose:
```bash
docker-compose up --build
```

## 🖼️ Frontend (React) Seperatly

```bash
cd pictures-frontend
npm install
npm run dev
