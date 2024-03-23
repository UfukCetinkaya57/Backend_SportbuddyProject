using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.JWT;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        IUserDal _userDal;
        public MessageManager(IMessageDal messageDal, IUserDal userDal)
        {
            _messageDal = messageDal;
            _userDal = userDal;
        }

        public IResult AddMessage(Message message)
        {
            List<int> MessagesIdList = new List<int>();
            
            User sendUser = _userDal.Get(p => p.Id == message.MessageSenderUserId);
            User receiveUser = _userDal.Get(p => p.Id == message.MessageReceiverUserId);
            
            _messageDal.Add(message);

           // var getMessage = _messageDal.Get(m => m.MessageId == message.MessageId);

            if (sendUser.MessagesIdList != null)
            {
                MessagesIdList = JsonConvert.DeserializeObject<List<int>>(sendUser.MessagesIdList);
                MessagesIdList.Add(message.MessageId);
                //   activities.Add(user);
            }
            else
            {
                MessagesIdList.Add(message.MessageId);
            }
            if (receiveUser.MessagesIdList != null)
            {
                MessagesIdList = JsonConvert.DeserializeObject<List<int>>(receiveUser.MessagesIdList);
                MessagesIdList.Add(message.MessageId);
                //   activities.Add(user);
            }
            else
            {
                MessagesIdList.Add(message.MessageId);
            }
            receiveUser.MessagesIdList = JsonConvert.SerializeObject(MessagesIdList);
            sendUser.MessagesIdList = JsonConvert.SerializeObject(MessagesIdList);


            _userDal.Update(receiveUser);
            _userDal.Update(sendUser);

            ///UPDATE KISIMLARI ///

            return new SuccessResult(Messages.ProductAdded);
            
        }
        public IResult Delete(int id)
        {
            Message message = _messageDal.Get(p => p.MessageId == id);
            _messageDal.Delete(message);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Message message)
        {
            _messageDal.Update(message);
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IDataResult<List<Message>> GetList()
        {
            return new IResult<List<Message>>(_messageDal.GetList().ToList());
        }
    }
}
