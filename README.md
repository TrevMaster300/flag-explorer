# 🌍 Flag Explorer App

A full-stack web app that showcases country flags and details.

Built using:
- React for the frontend
- .NET 8 Web API for the backend
- [restcountries.com](https://restcountries.com) as the data source

---

## 🚀 Features

- View all country flags from around the world
- Search for a country by name
- Click a flag to view its capital, population, and more
- Responsive UI
- Swagger-enabled backend
- CI/CD pipeline via GitHub Actions (builds, tests, packages artifacts)

---

## 🧰 Tech Stack

| Layer       | Technology                  |
|-------------|------------------------------|
| Frontend    | React, Axios, CSS Modules    |
| Backend     | .NET 8 Web API               |
| CI/CD       | GitHub Actions               |
| Tests       | xUnit (.NET), Jest (React)   |
| Data Source | restcountries.com            |

---

## 🖥️ Getting Started

### 🔧 Backend Setup (API)

1. Open Command Prompt (Run as Administrator)
2. Navigate to your backend folder:
   ```bash
   cd C:\Users\TSEKOBOANE\source\repos\FlagExplorerAPI
   ```
3. Run the backend:
   ```bash
   dotnet run
   ```
4. Open [https://localhost:7206/swagger](https://localhost:7206/swagger)

---

### 🌐 Frontend Setup (React App)

1. Open a new terminal
2. Navigate to the frontend folder:
   ```bash
   cd C:\Users\TSEKOBOANE\flag-explorer
   ```
3. Install dependencies:
   ```bash
   npm install
   ```
4. Start the app:
   ```bash
   npm start
   ```
5. Open [http://localhost:3000](http://localhost:3000)

---

## ✅ CI/CD Pipeline

GitHub Actions runs on every push and pull request to `main`:
- ✅ Builds and tests backend
- ✅ Builds frontend
- 📦 Packages backend and frontend builds as artifacts
- ❌ Frontend tests are skipped temporarily

---

## 🗂️ Folder Structure

```
FlagExplorerAPI/
├── Controllers/
│   └── CountryController.cs
├── Models/
│   ├── Country.cs
│   └── CountryDetails.cs
├── Program.cs
├── FlagExplorerAPI.csproj

flag-explorer/
├── src/
│   ├── components/
│   │   ├── Home.js
│   │   └── CountryDetails.js
│   ├── App.js
│   ├── App.test.js
│   ├── setupTests.js
├── public/
├── package.json
├── babel.config.js
├── jest.config.js
```

---

## 📬 Contact

Made with ❤️ by **Trevor Sekoboane**