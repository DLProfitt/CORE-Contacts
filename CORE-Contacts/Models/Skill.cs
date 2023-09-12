using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("SectionID")]
        public int SectionID { get; set; }

        [MaxLength(100)]
        public string SkillType { get; set; }

        [MaxLength(255)]
        public string SkillName { get; set; }

        public ResumeSection ResumeSection { get; set; } // Navigation property for the foreign key relationship
    }
}

//CREATE TABLE[dbo].[skills] (
//    [ID]        INT IDENTITY(1, 1) NOT NULL,
//    [SectionID] INT           NOT NULL,
//    [SkillType] VARCHAR (100) NULL,
//    [SkillName] VARCHAR (255) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);