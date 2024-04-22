using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        IResult AddMessage(Message message);
        IDataResult<Message> GetById(int Id);
        IDataResult<List<Message>> GetListByActivityId(int activityId);
        IDataResult<List<Message>> GetListByUserId(int userId);

        IDataResult<List<Message>> GetList();
        IResult Add(Message product);
        IResult Update(Message product);
        IResult Delete(int id);
    }
}
