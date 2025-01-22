namespace CraftTech.WebUI.Areas.Admin.Models.Message
{
    public class MessageResultDto
    {
        public int MessageID { get; set; }
        public string? NameSurname { get; set; }
        public string? Company { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? FileURL { get; set; }
        public string? MessageDetail { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsRead { get; set; }
    }
}
