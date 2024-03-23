using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Concerete
{

        public class JoinTheActivity: IEntity
        {
            [Key]
            public int JoinActivityId { get; set; }
            public int ActivityId { get; set; }
            public int UserId { get; set; }
            public string ActivityName { get; set; }
        }
    
}
