using Microsoft.OpenApi.Models;
using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Reference
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(ResumeSection))]
        [Required]
        public int SectionID { get; set; }

        [StringLength(50)]
        public string ReferenceType { get; set; }

        [StringLength(100)]
        public string ReferenceName { get; set; }

        [StringLength(255)]
        public string ReferenceBusinessRole { get; set; }

        [StringLength(20)]
        public string ReferencePhoneNumber { get; set; }

        [StringLength(255)]
        public string ReferenceEmail { get; set; }

        public ResumeSection ResumeSection { get; set; } // Navigation property
    }
}

//CREATE TABLE[dbo].[references] (
//    [ID]                    INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]             INT           NOT NULL,
//    [ReferenceType]         VARCHAR (50)  NULL,
//    [ReferenceName]         VARCHAR (100) NULL,
//    [ReferenceBusinessRole] VARCHAR (255) NULL,
//    [ReferencePhoneNumber]  VARCHAR (20)  NULL,
//    [ReferenceEmail]        VARCHAR (255) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);