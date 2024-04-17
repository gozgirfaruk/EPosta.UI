using EPosta.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.Business.Abstract
{
    public interface IAppMessageService : IGenericService<AppMessage>
    {
        List<AppMessage> GetListSenderMessage(string p);
        List<AppMessage> GetListReceiverMessage(string p);
    }
}
