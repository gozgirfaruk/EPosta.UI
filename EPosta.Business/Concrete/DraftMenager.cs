using EPosta.Business.Abstract;
using EPosta.DataAccess.Abstract;
using EPosta.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.Business.Concrete
{
    public class DraftMenager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftMenager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public List<Draft> GetAll()
        {
            return _draftDal.GetAll();
        }

        public Draft GetById(int id)
        {
            return _draftDal.GetByID(id);
        }

        public List<Draft> SendDraft(string p)
        {
            return _draftDal.GetByFilter(x=>x.SenderMail==p);
        }

        public void TAdd(Draft entity)
        {
           _draftDal.Insert(entity);
        }

        public void TDelete(Draft entity)
        {
            entity.Status = false;
            _draftDal.Update(entity);
        }

        public void TUpdate(Draft entity)
        {
            
            _draftDal.Update(entity);
        }
    }
}
