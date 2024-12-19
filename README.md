




# To-Do List API

A simple API for managing tasks in a to-do list application. This API allows users to create, update, view, and delete tasks. It is lightweight, easy to use, and does not require authentication.

---

## Core Features

### Task Management
- **Retrieve All Tasks**
  - `GET /tasks`: Fetch a list of all tasks.

- **Create a New Task**
  - `POST /tasks`: Add a new task with details such as title, description, and due date.

- **Retrieve a Specific Task**
  - `GET /tasks/{id}`: Get details of a task by its unique ID.

- **Update an Existing Task**
  - `PUT /tasks/{id}`: Modify task details like title, description, due date, or mark it as completed/incomplete.

- **Delete a Task**
  - `DELETE /tasks/{id}`: Remove a task by its ID.

### Task Status
- **Mark a Task as Completed**
  - `PUT /tasks/{id}/complete`

- **Mark a Task as Incomplete**
  - `PUT /tasks/{id}/incomplete`

### Filtering Tasks
- **Retrieve Completed Tasks**
  - `GET /tasks?completed=true`: Get all tasks marked as completed.

- **Retrieve Incomplete Tasks**
  - `GET /tasks?completed=false`: Get all tasks that are incomplete.

- **Filter by Due Date**
  - `GET /tasks?due_date={YYYY-MM-DD}`: Get tasks due on a specific date.

### Task Priorities
- **Filter by Priority**
  - `GET /tasks?priority={priority_level}`: Retrieve tasks based on priority levels (low, medium, high).

- **Update Task Priority**
  - `PUT /tasks/{id}/priority`: Update the priority level of a specific task.

---

## Installation and Setup

### Prerequisites
- .NET 8 SDK
- Microsoft SQL Server

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/todo-list-api.git
   cd todo-list-api
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Apply migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

5. The API will be accessible at `http://localhost:5000/`.

---

## Technologies Used

- **ASP.NET Core**: For building the web API.
- **Entity Framework Core**: For database management and ORM.
- **AutoMapper**: For object-to-object mapping.
- **SQL Server**: As the database.

---

## API Endpoints

### Base URL
```
http://localhost:5000/
```

### Endpoints

#### Task Management
- `GET /tasks` - Retrieve all tasks
- `POST /tasks` - Create a new task
- `GET /tasks/{id}` - Retrieve a specific task by ID
- `PUT /tasks/{id}` - Update an existing task
- `DELETE /tasks/{id}` - Delete a task

#### Task Status
- `PUT /tasks/{id}/complete` - Mark a task as completed
- `PUT /tasks/{id}/incomplete` - Mark a task as incomplete

#### Filtering Tasks
- `GET /tasks?completed=true` - Retrieve completed tasks
- `GET /tasks?completed=false` - Retrieve incomplete tasks
- `GET /tasks?due_date={YYYY-MM-DD}` - Filter tasks by due date

#### Task Priorities
- `GET /tasks?priority={priority_level}` - Filter tasks by priority
- `PUT /tasks/{id}/priority` - Update task priority

---

## Sample Use Cases

1. **Simple Task Management Apps**
   - Manage personal to-do lists with basic functionalities like creating, updating, and deleting tasks.

2. **Project Management**
   - Track project tasks and deadlines by creating tasks, updating details, and filtering based on due dates or completion status.

3. **Personal Organization**
   - Use the API to manage everyday activities, such as shopping lists, reminders, or other organizational needs.

---

## Contributing

Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Commit your changes and push the branch.
4. Open a pull request describing your changes.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.



