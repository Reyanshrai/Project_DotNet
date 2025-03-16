# Fitness Website Project

This project is a comprehensive fitness website built using .NET for both the frontend and backend. The website provides various features such as user registration, login, viewing fitness services, trainers, pricing plans, and more.

## Project Structure

The project is organized into two main folders: `Backend` and `Frontend`. Below is a detailed description of each folder and its contents.

### Backend

The `Backend` folder contains the backend logic of the application, including API endpoints, configuration files, and project settings.

- **appsettings.Development.json**: Configuration file for development environment settings.
- **appsettings.json**: Configuration file for application settings.
- **Backend.csproj**: Project file for the backend, specifying dependencies and target framework.
- **Backend.http**: HTTP file for testing API endpoints.
- **Program.cs**: Entry point of the backend application, configuring services and middleware.
- **bin/**: Directory containing compiled binaries and other build outputs.
- **obj/**: Directory containing intermediate build outputs and project-specific files.
- **Properties/**: Directory containing project properties and settings.
- **Controllers/**: Directory for API controllers handling HTTP requests.
- **Models/**: Directory for data models and entities.

### Frontend

The `Frontend` folder contains the frontend logic of the application, including views, controllers, and static assets.

- **appsettings.Development.json**: Configuration file for development environment settings.
- **appsettings.json**: Configuration file for application settings.
- **Frontend.csproj**: Project file for the frontend, specifying dependencies and target framework.
- **Program.cs**: Entry point of the frontend application, configuring services and middleware.
- **bin/**: Directory containing compiled binaries and other build outputs.
- **obj/**: Directory containing intermediate build outputs and project-specific files.
- **Properties/**: Directory containing project properties and settings.
- **Controllers/**: Directory for MVC controllers handling HTTP requests and returning views.
- **Models/**: Directory for data models and view models.
- **Views/**: Directory for Razor views, including shared layouts and partial views.
- **wwwroot/**: Directory for static assets such as CSS, JavaScript, and images.

## How to Run the Project

Follow these steps to set up and run the project:

1. **Clone the Repository**:
    ```sh
    git clone your-repo-url.git
    cd your-project-folder
    ```

2. **Install Dependencies**:
    ```sh
    dotnet restore
    ```

3. **Apply Database Migrations (If Using Entity Framework)**:
    ```sh
    dotnet ef database update
    ```

4. **Set Up Configuration Files**:
    - Ensure `appsettings.Development.json` and other necessary configuration files are present and properly configured.

5. **Run the Backend**:
    ```sh
    cd Backend
    dotnet run
    ```

6. **Run the Frontend**:
    ```sh
    cd Frontend
    dotnet run
    ```

7. **Open in VS Code**:
    ```sh
    code .
    ```

## Features

- User Registration and Login
- Viewing Fitness Services
- Viewing Trainers and Their Details
- Viewing Pricing Plans
- Contact Form
- Timetable for Fitness Classes

## Technologies Used

- .NET 9.0
- ASP.NET Core MVC
- Entity Framework Core
- Bootstrap for UI Styling

## Contributing

If you would like to contribute to this project, please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.
