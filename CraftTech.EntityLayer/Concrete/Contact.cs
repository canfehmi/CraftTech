using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageURL { get; set; }
    }
}
