namespace RefactorResume.Models
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

//CREATE TABLE[dbo].[users] (
//    [ID]        INT IDENTITY(1, 1) NOT NULL,
//    [FirstName] VARCHAR (100) NULL,
//    [LastName]  VARCHAR (100) NULL,
//    [Email]     VARCHAR (255) NULL,
//    [Password]  VARCHAR (255) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    UNIQUE NONCLUSTERED([Email] ASC)
//);