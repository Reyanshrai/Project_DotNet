# 🚀 How to Start a .NET Core Project After Cloning the Repo

If you or your team members clone the repository, follow these steps to set up and run the project using **VS Code** instead of Visual Studio.

---

## **1️⃣ Clone the Repository**
Open the terminal and run:
```sh
git clone your-repo-url.git
cd your-project-folder
```

---

## **2️⃣ Install Dependencies**
Since `bin/` and `obj/` folders are ignored in `.gitignore`, restore dependencies using:
```sh
dotnet restore
```
This will install all required **NuGet packages**.

---

## **3️⃣ Apply Database Migrations (If Using Entity Framework)**
If your project uses **Entity Framework**, update the database:
```sh
dotnet ef database update
```
If there's an error about missing EF tools, install them first:
```sh
dotnet tool install --global dotnet-ef
```

---

## **4️⃣ Set Up Configuration Files**
Some files (like `appsettings.Development.json`) may be ignored in `.gitignore`. If missing:
1. **Check if these files exist**.
2. **Copy `appsettings.json` and manually configure connection strings, secrets, etc.**.

---

## **5️⃣ Run the Project**
Run the backend server:
```sh
dotnet run
```
If there's a frontend built with **ASP.NET Core MVC**, navigate to the frontend folder and run:
```sh
dotnet run
```

---

## **6️⃣ Open in VS Code**
To open the project in **VS Code**, use:
```sh
code .
```
This will launch the project in **VS Code**.

---

## 🎯 **Quick Recap**
1️⃣ **Clone the repo** → `git clone your-repo-url.git`  
2️⃣ **Restore dependencies** → `dotnet restore`  
3️⃣ **Apply DB migrations** → `dotnet ef database update`  
4️⃣ **Set up config files** → `appsettings.json`  
5️⃣ **Run the project** → `dotnet run`  
6️⃣ **Open in VS Code** → `code .`  

🔥 Now you're ready to code! 🚀

git log -n 2 --pretty=format:"%h - %s (%an, %ar)" > recent_commits.txt