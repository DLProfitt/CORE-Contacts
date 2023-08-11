using RefactorResume.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("ResumeSection")]
        [Required]
        public int SectionID { get; set; }

        [MaxLength(255)]
        public string CertificationTitle { get; set; }

        public DateTime? DateReceived { get; set; }

        public virtual ResumeSection ResumeSection { get; set; }
    }
}

//CREATE TABLE[dbo].[certifications] (
//    [ID]                 INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]          INT           NOT NULL,
//    [CertificationTitle] VARCHAR (255) NULL,
//    [DateReceived]       DATE          NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);