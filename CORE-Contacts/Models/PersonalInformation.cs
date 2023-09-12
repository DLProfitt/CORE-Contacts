using COREContacts.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Collections.Specialized.BitVector32;

namespace COREContacts.Models
{
    public class PersonalInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("SectionID")]
        public int SectionID { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string LinkedInProfile { get; set; }

        [MaxLength(255)]
        public string GitHubProfile { get; set; }

        // Navigation property for the related Resume Section
        public ResumeSection ResumeSection { get; set; }
    }
}

//CREATE TABLE[dbo].[personal_information] (
//    [ID]              INT IDENTITY(1, 1) NOT NULL,
//    [SectionID]       INT           NOT NULL,
//    [FirstName]       VARCHAR (100) NULL,
//    [LastName]        VARCHAR (100) NULL,
//    [Email]           VARCHAR (255) NULL,
//    [PhoneNumber]     VARCHAR (20)  NULL,
//    [LinkedInProfile] VARCHAR (255) NULL,
//    [GitHubProfile]   VARCHAR (255) NULL,
//    PRIMARY KEY CLUSTERED ([ID] ASC),
//    FOREIGN KEY([SectionID]) REFERENCES[dbo].[resume_sections]([ID])
//);