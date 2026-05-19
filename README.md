# Societies Management System

A comprehensive desktop application for managing university societies, events, memberships, and student activities.

## 🛠️ Built With
- **C# .NET 8 (Windows Forms)**
- **SQL Server** (optional, for persistent mode)

---

## 🚀 Features

- **Multi-role Support**: Student, Society Head, Admin
- **User Registration & Login**
- **Society Browsing & Membership Requests**
- **Event Management & Registration**
- **Admin Dashboard** (User & Society Management)
- **Society Head Dashboard** (Manage own society, events, members)
- **Activity Logging**
- **Password Strength Checker**
- **Task Management**
- **Announcements**
- **Analytics & Reporting**

---

## 🧑‍💻 Project Structure

| File/Folder                  | Description                                 |
|------------------------------|---------------------------------------------|
| `ActivityLog.cs`             | Handles activity logging                    |
| `AdminDashboard.cs`          | Admin dashboard UI and logic                |
| `AnalyticsDashboard.cs`      | Analytics and reporting                     |
| `AnnouncementModel.cs`       | Announcement data model                     |
| `AuthService.cs`             | Authentication logic                        |
| `DatabaseHelper.cs`          | Database connection and queries             |
| `EventModel.cs`              | Event data model                            |
| `EventRegistrationModel.cs`  | Event registration logic                    |
| `MembershipModel.cs`         | Membership data model                       |
| `Prompt.cs`                  | UI prompts                                  |
| `RegistrationForm.cs`        | User registration form                      |
| `ReportModel.cs`             | Reporting data model                        |
| `SessionManagement.cs`       | Session handling                            |
| `SocietiesBrowserForm.cs`    | Browse societies                            |
| `SocietyHeadDashboard.cs`    | Society head dashboard                      |
| `SocietyModel.cs`            | Society data model                          |
| `StudentDashboard.cs`        | Student dashboard                           |
| `TaskComment.cs`             | Task comments                               |
| `TaskManagementForm.cs`      | Task management UI                          |
| `TaskModel.cs`               | Task data model                             |
| `UserModel.cs`               | User data model                             |
| `USERS TABLE.sql`            | SQL script for initial users table          |

---

## 🏁 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) (recommended)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for persistent mode)

### Setup Instructions
1. **Clone the repository**
   ```bash
   git clone <repo-url>
   cd sms
   ```
2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```
3. **Build the solution**
   ```bash
   dotnet build
   ```
4. **Configure the database (optional)**
   - Update the connection string in `DatabaseHelper.cs` if using SQL Server.
   - Run `USERS TABLE.sql` and create additional tables as needed.
5. **Run the application**
   ```bash
   dotnet run
   ```

---

## 🧪 Default Login Credentials

| Role           | Username     | Password     |
|----------------|--------------|--------------|
| **Admin**      | admin        | admin123     |
| **Society Head** | head       | head123      |
| **Student**    | student      | student123   |

---

## 💡 Usage

1. **Login** as Admin, Society Head, or Student using the credentials above.
2. **Explore Dashboards**:
   - **Admin**: Manage users, societies, and view analytics.
   - **Society Head**: Manage your society, events, and members.
   - **Student**: Browse societies, request memberships, register for events.
3. **Manage Events**: Create, edit, and register for events.
4. **Task Management**: Assign and track tasks (Society Head/Admin).
5. **View Announcements** and activity logs.

---

## 🗄️ Database Setup (Optional)

For persistent data storage, configure SQL Server:
1. Update the connection string in `DatabaseHelper.cs`.
2. Run the `USERS TABLE.sql` script to create the users table.
3. Add additional tables for events, memberships, etc., as needed.

---

## 🤝 Contributing

Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

---

## 📄 License

This project is licensed for educational purposes.