namespace CraftTech.WebUI.Areas.Admin.Models.Contact
{
    public class ContactUpdateDto
    {
        public int ContactID { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageURL { get; set; }
    }
}
