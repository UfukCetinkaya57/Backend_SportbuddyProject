using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreLayer.Entities.Concerete
{
    public class Activity: IEntity
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
        
        //public int TotalNumberOfUsersAtTheEvent { get; set; }

        //        public string? Participants { get; set; }
        //SQL DE DÜZENLEMELER YAPILMALI
    }
}
