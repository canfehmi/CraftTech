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
    public class BannerManager:IBannerService
    {
        private readonly IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void TDelete(Banner entity)
        {
            _bannerDal.Delete(entity);
        }

        public Banner TGetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public List<Banner> TGetList()
        {
            return _bannerDal.GetList();
        }

        public void TInsert(Banner entity)
        {
            _bannerDal.Insert(entity);
        }

        public void TUpdate(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}
