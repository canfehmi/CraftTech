using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string NameSurname { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? FileURL { get; set; }
        public string MessageDetail { get; set; }
        public DateTime SendTime { get; set; }
        public bool IsRead { get; set; }
    }
}
