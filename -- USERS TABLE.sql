-- USERS TABLE
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password_hash NVARCHAR(255) NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    email NVARCHAR(100) NOT NULL UNIQUE,
    role NVARCHAR(20) NOT NULL CHECK (role IN ('student', 'society_head', 'admin')),
    status NVARCHAR(20) NOT NULL DEFAULT 'active' CHECK (status IN ('active', 'inactive')),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- SOCIETIES TABLE
CREATE TABLE Societies (
    society_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL UNIQUE,
    description NVARCHAR(500),
    category NVARCHAR(50),
    status NVARCHAR(20) NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'approved', 'rejected')),
    creation_date DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME()
);

-- SOCIETY MEMBERSHIPS TABLE
CREATE TABLE SocietyMemberships (
    membership_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT NOT NULL,
    society_id INT NOT NULL,
    role NVARCHAR(20) NOT NULL CHECK (role IN ('member', 'society_head')),
    join_date DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    status NVARCHAR(20) NOT NULL DEFAULT 'active' CHECK (status IN ('active', 'inactive', 'pending')),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Membership_Student FOREIGN KEY (student_id) REFERENCES Users(user_id),
    CONSTRAINT FK_Membership_Society FOREIGN KEY (society_id) REFERENCES Societies(society_id)
);

-- EVENTS TABLE
CREATE TABLE Events (
    event_id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    event_date DATETIME2 NOT NULL,
    venue NVARCHAR(100),
    capacity INT,
    society_id INT NOT NULL,
    approval_status NVARCHAR(20) NOT NULL DEFAULT 'pending' CHECK (approval_status IN ('pending', 'approved', 'rejected')),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Event_Society FOREIGN KEY (society_id) REFERENCES Societies(society_id)
);

-- EVENT REGISTRATIONS TABLE
CREATE TABLE EventRegistrations (
    registration_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id INT NOT NULL,
    event_id INT NOT NULL,
    registration_date DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    ticket_number NVARCHAR(50) NOT NULL UNIQUE,
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Registration_Student FOREIGN KEY (student_id) REFERENCES Users(user_id),
    CONSTRAINT FK_Registration_Event FOREIGN KEY (event_id) REFERENCES Events(event_id)
);

-- TASKS TABLE
CREATE TABLE Tasks (
    task_id INT IDENTITY(1,1) PRIMARY KEY,
    title NVARCHAR(100) NOT NULL,
    description NVARCHAR(500),
    assigned_to INT NOT NULL,
    assigned_by INT NOT NULL,
    deadline DATETIME2 NOT NULL,
    status NVARCHAR(20) NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'in_progress', 'completed', 'cancelled')),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Task_AssignedTo FOREIGN KEY (assigned_to) REFERENCES Users(user_id),
    CONSTRAINT FK_Task_AssignedBy FOREIGN KEY (assigned_by) REFERENCES Users(user_id)
);

-- ANNOUNCEMENTS TABLE
CREATE TABLE Announcements (
    announcement_id INT IDENTITY(1,1) PRIMARY KEY,
    society_id INT NOT NULL,
    title NVARCHAR(100) NOT NULL,
    content NVARCHAR(1000) NOT NULL,
    posted_by INT NOT NULL,
    post_date DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    created_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    updated_at DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Announcement_Society FOREIGN KEY (society_id) REFERENCES Societies(society_id),
    CONSTRAINT FK_Announcement_User FOREIGN KEY (posted_by) REFERENCES Users(user_id)
);

-- INDEXES
CREATE INDEX IX_SocietyMemberships_Student ON SocietyMemberships(student_id);
CREATE INDEX IX_SocietyMemberships_Society ON SocietyMemberships(society_id);
CREATE INDEX IX_Events_Society ON Events(society_id);
CREATE INDEX IX_EventRegistrations_Student ON EventRegistrations(student_id);
CREATE INDEX IX_EventRegistrations_Event ON EventRegistrations(event_id);