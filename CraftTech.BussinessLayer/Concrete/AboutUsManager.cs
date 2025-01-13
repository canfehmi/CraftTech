using CraftTech.BussinessLayer.Abstract;
using CraftTech.DataAccessLayer.Abstract;
using CraftTech.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.BussinessLayer.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsDal _aboutUsDal;

        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }

        public void TDelete(AboutUs entity)
        {
            _aboutUsDal.Delete(entity);
        }

        public AboutUs TGetById(int id)
        {
            return _aboutUsDal.GetById(id);
        }

        public List<AboutUs> TGetList()
        {
            return _aboutUsDal.GetList();
        }

        public void TInsert(AboutUs entity)
        {
            _aboutUsDal.Insert(entity);
        }

        public void TUpdate(AboutUs entity)
        {
            _aboutUsDal.Update(entity);
        }
    }
}
