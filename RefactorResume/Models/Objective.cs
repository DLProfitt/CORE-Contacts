using RefactorResume.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace RefactorResume.Models
{
    public class Objective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey(nameof(ResumeSection))]
        [Required]
        public int SectionID { get; set; }

        public string ObjectiveText { get; set; }

        // Navigation property to the ResumeSection
        public virtual ResumeSection ResumeSection { get; set; }
    }
}

//CREATE TABLE[dbo].[objective] (
//    [ID]            INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]     INT  NOT NULL,
//    [ObjectiveText] TEXT NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);