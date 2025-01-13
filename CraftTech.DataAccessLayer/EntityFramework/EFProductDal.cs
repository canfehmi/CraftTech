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
    public class EFProductDal : GenericRepository<Product>, IProductDal
    {
        public EFProductDal(Context context) : base(context)
        {
        }
    }
}
