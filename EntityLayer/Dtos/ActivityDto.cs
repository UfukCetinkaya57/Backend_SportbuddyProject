using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class ActivityDto
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public string ActivityType { get; set; }
        public string ActivityMap { get; set; }
        public string ActivityDate { get; set; }
        public int NumberOfUsersRequestedForTheEvent { get; set; } = 0;
        //Kullanıcıların Listeleri Olmalı
        public string? UsersIdList { get; set; } = null;
        public string? JoinTheActivitesList { get; set; } = null;

    }
}
