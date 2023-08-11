USE master;

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'RefactorResume')
BEGIN
    CREATE DATABASE RefactorResume;
    ALTER DATABASE RefactorResume SET RECOVERY SIMPLE;
END;

USE RefactorResume;

CREATE TABLE users (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	Email VARCHAR(255) UNIQUE,
	Password VARCHAR(255)
);
GO

CREATE TABLE resumes (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	UserID INT NOT NULL,
	FOREIGN KEY (UserID) REFERENCES users(ID)
);
GO

CREATE TABLE resume_sections (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	ResumeID INT NOT NULL,
	FOREIGN KEY (ResumeID) REFERENCES resumes(ID),
	SectionType VARCHAR(100)
);
GO

CREATE TABLE personal_information (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	FirstName VARCHAR(100),
	LastName VARCHAR(100),
	Email VARCHAR(255),
	PhoneNumber VARCHAR(20),
	LinkedInProfile VARCHAR(255),
	GitHubProfile VARCHAR(255)
);
GO

CREATE TABLE objective (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	ObjectiveText TEXT
);
GO

CREATE TABLE skills (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	SkillType VARCHAR(100),
	SkillName VARCHAR(255)
);
GO

CREATE TABLE education (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	SchoolName VARCHAR(255),
	DegreeReceived VARCHAR(100),
	GraduationDate DATE
);
GO

CREATE TABLE certifications (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	CertificationTitle VARCHAR(255),
	DateReceived DATE
);
GO

CREATE TABLE work_experience (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	Company VARCHAR(255),
	Role VARCHAR(100),
	Location VARCHAR(100),
	Summary TEXT
);
GO

CREATE TABLE projects (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	ProjectTitle VARCHAR(255),
	ProjectDetails TEXT,
	ProjectSummary TEXT,
	LinkToProject VARCHAR(255)
);
GO

CREATE TABLE [references] (
	ID INT IDENTITY(1,1) PRIMARY KEY,
	SectionID INT NOT NULL,
	FOREIGN KEY (SectionId) REFERENCES resume_sections(ID),
	ReferenceType VARCHAR(50),
	ReferenceName VARCHAR(100),
	ReferenceBusinessRole VARCHAR(255),
	ReferencePhoneNumber VARCHAR(20),
	ReferenceEmail VARCHAR(255)
);
GO