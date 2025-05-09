# 🌍 Flag Explorer App

A beginner-friendly full-stack web app built using:
- React for the frontend
- .NET Core Web API for the backend
- [restcountries.com](https://restcountries.com) as the data source

---

## 🚀 Features

- View all country flags
- Search countries by name
- Click on a flag to view country details in a popup modal (capital, population)
- Fully responsive and easy to use

---

## 🧰 Tech Stack

| Layer       | Technology            |
|-------------|------------------------|
| Frontend    | React, Axios, Custom CSS |
| Backend     | .NET Core Web API      |
| Data Source | restcountries.com      |

---

## 🖥️ Getting Started

### 🔧 Backend Setup (API)
1. Open Command Prompt (Run as Administrator)
2. Navigate to backend folder:
   ```bash
   cd C:\Users\TSEKOBOANE\source\repos\FlagExplorerAPI
   ```
3. Run the project:
   ```bash
   dotnet run
   ```
4. Confirm the Swagger UI opens on `https://localhost:7206/swagger`

---

### 🌐 Frontend Setup (React App)
1. Open a new Command Prompt
2. Navigate to frontend folder:
   ```bash
   cd C:\Users\TSEKOBOANE\flag-explorer
   ```
3. Start the React app:
   ```bash
   npm start
   ```
4. App opens at `http://localhost:3000`

---

## 📦 Folder Structure

```
FlagExplorerAPI/
├── Controllers/
│   └── CountryController.cs
├── Models/
│   ├── Country.cs
│   └── CountryDetails.cs

flag-explorer/
├── src/
│   ├── components/
│   │   ├── Home.js
│   │   └── Modal.js
│   ├── App.js
│   └── App.css
```

---

## 📬 Contact

Made with ❤️ by Trevor Sekoboane