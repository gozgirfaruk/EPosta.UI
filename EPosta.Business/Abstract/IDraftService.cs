using EPosta.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.Business.Abstract
{
    public interface IDraftService : IGenericService<Draft>
    {
        List<Draft> SendDraft(string p);
    }
}
