-- SQLite Database Schema for FAST Societies Management System

-- Users Table
CREATE TABLE Users (
    UserId INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT UNIQUE NOT NULL,
    PasswordHash TEXT NOT NULL,
    FullName TEXT NOT NULL,
    Email TEXT UNIQUE NOT NULL,
    Role TEXT CHECK(Role IN ('admin', 'society_head', 'student')) NOT NULL,
    Status TEXT DEFAULT 'active',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Societies Table
CREATE TABLE Societies (
    SocietyId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE,
    Description TEXT,
    Category TEXT,
    HeadUserId INTEGER,
    Status TEXT DEFAULT 'pending',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (HeadUserId) REFERENCES Users(UserId) ON DELETE SET NULL
);

-- Memberships Table
CREATE TABLE Memberships (
    MembershipId INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    SocietyId INTEGER NOT NULL,
    JoinDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status TEXT DEFAULT 'pending',
    FOREIGN KEY (StudentId) REFERENCES Users(UserId) ON DELETE CASCADE,
    FOREIGN KEY (SocietyId) REFERENCES Societies(SocietyId) ON DELETE CASCADE,
    UNIQUE(StudentId, SocietyId)
);

-- Events Table
CREATE TABLE Events (
    EventId INTEGER PRIMARY KEY AUTOINCREMENT,
    SocietyId INTEGER NOT NULL,
    Title TEXT NOT NULL,
    Description TEXT,
    EventDate DATETIME NOT NULL,
    Venue TEXT,
    Capacity INTEGER DEFAULT 50,
    Status TEXT DEFAULT 'pending',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (SocietyId) REFERENCES Societies(SocietyId) ON DELETE CASCADE
);

-- EventRegistrations Table
CREATE TABLE EventRegistrations (
    RegistrationId INTEGER PRIMARY KEY AUTOINCREMENT,
    StudentId INTEGER NOT NULL,
    EventId INTEGER NOT NULL,
    TicketNumber TEXT UNIQUE,
    RegistrationDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (StudentId) REFERENCES Users(UserId) ON DELETE CASCADE,
    FOREIGN KEY (EventId) REFERENCES Events(EventId) ON DELETE CASCADE
);

-- Tasks Table
CREATE TABLE Tasks (
    TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
    SocietyId INTEGER NOT NULL,
    Title TEXT NOT NULL,
    Description TEXT,
    AssignedTo INTEGER NOT NULL,
    AssignedBy INTEGER NOT NULL,
    DueDate DATETIME,
    Priority TEXT DEFAULT 'Medium',
    Status TEXT DEFAULT 'pending',
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (SocietyId) REFERENCES Societies(SocietyId) ON DELETE CASCADE,
    FOREIGN KEY (AssignedTo) REFERENCES Users(UserId),
    FOREIGN KEY (AssignedBy) REFERENCES Users(UserId)
);

-- ActivityLogs Table
CREATE TABLE ActivityLogs (
    LogId INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER NOT NULL,
    Action TEXT NOT NULL,
    Description TEXT,
    Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

-- Default Data
INSERT OR IGNORE INTO Users (Username, PasswordHash, FullName, Email, Role, Status) VALUES
('admin', '8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', 'System Admin', 'admin@fast.edu.pk', 'admin', 'active'),
('head', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Ahmed Khan', 'ahmed.khan@fast.edu.pk', 'society_head', 'active'),
('student', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'Ali Hassan', 'ali.hassan@fast.edu.pk', 'student', 'active');