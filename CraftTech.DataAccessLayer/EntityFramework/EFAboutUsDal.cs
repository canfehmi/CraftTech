using CraftTech.DataAccessLayer.Abstract;
using CraftTech.DataAccessLayer.Concrete;
using CraftTech.DataAccessLayer.Repositories;
using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.DataAccessLayer.EntityFramework
{
    public class EFAboutUsDal:GenericRepository<AboutUs>, IAboutUsDal
    {
        public EFAboutUsDal(Context context) : base(context) 
        { 
        }

    }
}
