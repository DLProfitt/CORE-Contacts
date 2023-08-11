using RefactorResume.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(ResumeSection))]
        [Required]
        public int SectionID { get; set; }

        [StringLength(255)]
        public string SchoolName { get; set; }

        [StringLength(100)]
        public string DegreeReceived { get; set; }

        public DateTime? GraduationDate { get; set; }

        // Navigation property for the related ResumeSection
        public ResumeSection ResumeSection { get; set; }
    }
}

//CREATE TABLE[dbo].[education] (
//    [ID]             INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]      INT           NOT NULL,
//    [SchoolName]     VARCHAR (255) NULL,
//    [DegreeReceived] VARCHAR (100) NULL,
//    [GraduationDate] DATE          NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);