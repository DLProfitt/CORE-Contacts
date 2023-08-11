using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RefactorResume.Models
{
    public class Resume
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserID { get; set; }

        // Navigation property for the user
        public virtual User User { get; set; }
    }
}

//CREATE TABLE[dbo].[resumes] (
//    [ID]     INT IDENTITY(1, 1) NOT NULL,
//    [UserID] INT NOT NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([UserID]) REFERENCES[dbo].[users]([ID])
//);