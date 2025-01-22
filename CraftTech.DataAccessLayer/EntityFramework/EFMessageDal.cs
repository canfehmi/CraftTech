using CraftTech.DataAccessLayer.Abstract;
using CraftTech.DataAccessLayer.Concrete;
using CraftTech.DataAccessLayer.Repositories;
using CraftTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.DataAccessLayer.EntityFramework
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        public EFMessageDal(Context context) : base(context)
        {
        }

        public void ReadMessage(int id)
        {
            var contex = new Context();
            var value = contex.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = true;
            }
            contex.SaveChanges();   
        }
    }
}
