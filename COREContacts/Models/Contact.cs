namespace COREContacts.Models
{
    public class Contact
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? TwitterUsername { get; set; }
        public string? ImageUrl { get; set; }
        public string? Note { get; set; }
        public bool IsFavorite { get; set; }
    }
}
