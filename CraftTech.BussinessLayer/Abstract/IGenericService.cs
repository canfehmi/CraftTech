using CraftTech.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftTech.BussinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetList();
        T TGetById(int id);
        void TUpdateWithFile(T entity, IFormFile? file);
    }
}
