using Microsoft.AspNetCore.Http;
using COREContacts.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COREContacts.Models
{
    public class ResumeSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [ForeignKey(nameof(Resume))]
        public int ResumeID { get; set; }

        [MaxLength(100)]
        public string SectionType { get; set; }

        public virtual Resume Resume { get; set; }
        public virtual PersonalInformation PersonalInformation { get; set; }
    }
}

//CREATE TABLE[dbo].[resume_sections] (
//    [ID]          INT IDENTITY(1, 1) NOT NULL,
//    [ResumeID]    INT           NOT NULL,
//    [SectionType] VARCHAR (100) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([ResumeID]) REFERENCES[dbo].[resumes]([ID])
//);