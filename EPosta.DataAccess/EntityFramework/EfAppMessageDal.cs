using EPosta.DataAccess.Abstract;
using EPosta.DataAccess.Repository;
using EPosta.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPosta.DataAccess.EntityFramework
{
    public class EfAppMessageDal : GenericRepository<AppMessage>,IAppMessageDal
    {
    }
}
