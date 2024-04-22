using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Concerete
{
    public class Message : IEntity
    {
        public int MessageId { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
      //  public string? MessageSenderUsersIdList { get; set; } = null; 
        public string? MessageContent { get; set; } = null; 
        public string MessageSendDate { get; set; }
    }
}
