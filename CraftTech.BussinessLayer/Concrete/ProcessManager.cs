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
    public class ProcessManager:IProcessService
    {
        private readonly IProcessDal _processDal;

        public ProcessManager(IProcessDal processDal)
        {
            _processDal = processDal;
        }

        public void TDelete(Process entity)
        {
            _processDal.Delete(entity);
        }

        public Process TGetById(int id)
        {
            return _processDal.GetById(id);
        }

        public List<Process> TGetList()
        {
            return _processDal.GetList();
        }

        public void TInsert(Process entity)
        {
            _processDal.Insert(entity);
        }

        public void TUpdate(Process entity)
        {
            _processDal.Update(entity);
        }
    }
}
