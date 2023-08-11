using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;
using System.Data;

namespace RefactorResume.Models
{
    public class WorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("ResumeSection")]
        [Required]
        public int SectionID { get; set; }

        [MaxLength(255)]
        public string Company { get; set; }

        [MaxLength(100)]
        public string Role { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        public string Summary { get; set; } // You can use [Column(TypeName = "text")] if you want to explicitly define the type

        public virtual ResumeSection ResumeSection { get; set; } // Navigation property for the related resume section
    }
}

//CREATE TABLE[dbo].[work_experience] (
//    [ID]        INT IDENTITY(1, 1) NOT NULL,
//    [SectionID] INT           NOT NULL,
//    [Company]   VARCHAR (255) NULL,
//    [Role]      VARCHAR (100) NULL,
//    [Location]  VARCHAR (100) NULL,
//    [Summary]   TEXT          NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);