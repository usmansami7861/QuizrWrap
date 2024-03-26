# QuizrWrap
ASP.NET Console Project with SQLite Database (QuizWrap) This project is an ASP.NET console application that utilizes a SQLite database for data storage. It allows you to perform CRUD (Create, Read, Update, Delete) operations on three tables: Users, Content (Questions), and Networks.

Prerequisites Before you start, ensure you have the following installed:

.NET SDK for building and running .NET applications. SQLite database engine. SQLite client (optional) for managing the database. Setup Clone the Repository:

bash Copy code git clone [https://github.com/yourusername/your-repository.git](https://github.com/usmansami7861/QuizrWrap.git)  Navigate to the Project Directory:

bash cd your-repository Restore Packages:

bash dotnet restore Usage

Running the Application: To run the application, execute the following command:
bash
dotnet run Save to grepper 2. Database Operations: The application supports the following database operations:

Insert Users: To insert users into the database, modify the InsertUsers method in the Program.cs file with your desired user data, then run the application.

Insert Content (Questions): Modify the InsertContentTextBased method in the Program.cs file with your desired questions and answers data, including image paths, then run the application.

Insert Networks:
Modify the InsertNetworks method in the Program.cs file with your desired network data, then run the application.

Managing the Database:
You can manage the database using a SQLite client or command-line interface. The database file (database.db) is created in the project directory.

Notes
Ensure that all image files referenced in the questions exist and are accessible at the specified paths. The database schema and sample data are provided in the Program.cs file. Modify them according to your requirements.

Contributors
Usman Sami
License
This project is licensed under the MIT License.
