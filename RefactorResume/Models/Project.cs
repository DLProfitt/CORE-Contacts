using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("SectionID")]
        [Required]
        public int SectionID { get; set; }

        [StringLength(255)]
        public string ProjectTitle { get; set; }

        public string ProjectDetails { get; set; }

        public string ProjectSummary { get; set; }

        [StringLength(255)]
        public string LinkToProject { get; set; }

        public virtual ResumeSection ResumeSection { get; set; } // Navigation property to the related resume_section
    }
}

//CREATE TABLE[dbo].[projects] (
//    [ID]             INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]      INT           NOT NULL,
//    [ProjectTitle]   VARCHAR (255) NULL,
//    [ProjectDetails] TEXT          NULL,
//    [ProjectSummary] TEXT          NULL,
//    [LinkToProject]  VARCHAR (255) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);