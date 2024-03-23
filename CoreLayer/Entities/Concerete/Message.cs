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
        public int MessageSenderUserId { get; set; }
        public int MessageReceiverUserId { get; set; }
        public string MessageContent { get; set; }
        public string MessageSendDate { get; set; }
    }
}
