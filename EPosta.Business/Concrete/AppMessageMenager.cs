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
    public class AppMessageMenager : IAppMessageService
    {
        IAppMessageDal _messageDal;

        public AppMessageMenager(IAppMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<AppMessage> GetAll()
        {
           return _messageDal.GetAll();
        }

        public AppMessage GetById(int id)
        {
            return _messageDal.GetByID(id);
        }

        public List<AppMessage> GetListReceiverMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.ReceiverMail == p);

        }

        public List<AppMessage> GetListSenderMessage(string p)
        {
            return _messageDal.GetByFilter(x => x.SenderMail == p);
        }

        public void TAdd(AppMessage entity)
        {
           _messageDal.Insert(entity);
        }

        public void TDelete(AppMessage entity)
        {
            _messageDal.Delete(entity);
        }

        public void TUpdate(AppMessage entity)
        {
           _messageDal.Update(entity);
        }
    }
}
