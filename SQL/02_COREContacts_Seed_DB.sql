USE RefactorResume;

INSERT INTO users (FirstName, LastName, Email, Password)
VALUES ('John', 'Doe', 'john.doe@example.com', 'password1'),
       ('Jane', 'Smith', 'jane.smith@example.com', 'password2'),
       ('Alice', 'Johnson', 'alice.johnson@example.com', 'password3');

INSERT INTO resumes (UserID)
VALUES (1), (2), (3);

INSERT INTO resume_sections (ResumeID, SectionType)
VALUES (1, 'Personal Information'), (2, 'Objective'), (3, 'Skills');

INSERT INTO personal_information (SectionID, FirstName, LastName, Email, PhoneNumber, LinkedInProfile, GitHubProfile)
VALUES (1, 'John', 'Doe', 'john.doe@example.com', '123-456-7890', 'linkedin.com/johndoe', 'github.com/johndoe');

INSERT INTO objective (SectionID, ObjectiveText)
VALUES (1, 'Seeking a challenging position...'),
       (2, 'Looking to leverage my skills...'),
       (3, 'Aspiring to grow in a dynamic environment...');

INSERT INTO skills (SectionID, SkillType, SkillName)
VALUES (1, 'Language', 'C#'),
       (2, 'Tool', 'Visual Studio'),
       (3, 'Technology', 'React.js');

INSERT INTO education (SectionID, SchoolName, DegreeReceived, GraduationDate)
VALUES (1, 'University A', 'B.S. in Computer Science', '2022-05-01'),
       (2, 'University B', 'M.S. in Software Engineering', '2021-12-15'),
       (3, 'University C', 'Ph.D. in Data Science', '2020-08-30');

INSERT INTO certifications (SectionID, CertificationTitle, DateReceived)
VALUES (1, 'AWS Certified Developer', '2022-01-10'),
       (2, 'Microsoft Certified: Azure Solutions Architect', '2021-03-25'),
       (3, 'Cisco Certified Network Associate (CCNA)', '2020-07-15');

INSERT INTO work_experience (SectionID, Company, Role, Location, Summary)
VALUES (1, 'TechCorp', 'Software Developer', 'New York, NY', 'Developed various applications...'),
       (2, 'DataInc', 'Data Analyst', 'San Francisco, CA', 'Analyzed large datasets...'),
       (3, 'Design LLC', 'UX Designer', 'Chicago, IL', 'Created intuitive user interfaces...');

INSERT INTO projects (SectionID, ProjectTitle, ProjectDetails, ProjectSummary, LinkToProject)
VALUES (1, 'Project A', 'Details about Project A...', 'Summary of Project A...', 'link-to-project-a.com'),
       (2, 'Project B', 'Details about Project B...', 'Summary of Project B...', 'link-to-project-b.com'),
       (3, 'Project C', 'Details about Project C...', 'Summary of Project C...', 'link-to-project-c.com');

INSERT INTO [references] (SectionID, ReferenceType, ReferenceName, ReferenceBusinessRole, ReferencePhoneNumber, ReferenceEmail)
VALUES (1, 'Professional', 'Referee A', 'Manager at TechCorp', '123-456-7890', 'referee.a@example.com'),
       (2, 'Personal', 'Referee B', 'Friend', '321-654-0987', 'referee.b@example.com'),
       (3, 'Professional', 'Referee C', 'Colleague at DataInc', '111-222-3333', 'referee.c@example.com');
