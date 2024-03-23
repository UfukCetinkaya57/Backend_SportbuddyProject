using CoreLayer.DataAccess.EntityFramework;
using CoreLayer.Entities.Concerete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, SportBuddyContext>, IMessageDal
    {

    }
}
