using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entities.Concerete
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; } = null;
        public string? LastName { get; set; } = null;
        public string? UserName { get; set; } = null;
        public string? Email { get; set; } = null;
        public string? Roles { get; set; } = null;
        //Messajların ID sini tutmak mı daha mantıklı yoksa list şeklinde string bir yapıyla döndürmek mi?
        public string? MessagesIdList { get; set; } = null;

        [NotMapped]
        public string? PhotoBase64 { get; set; } = null;
      
        //List yapmaya bir ara dene bunu
        public string? JoinTheActivitesIdList { get; set; } = null;
        public string? PhotoPath { get; set; } = null;
        public byte[]? PasswdSalt { get; set; } = null;
        public byte[]? PasswdHash { get; set; } = null;
        public string? Address { get; set; } = null;
        public string? MobilePhone { get; set; } = null;

        //public Activity? Messages { get; set; } = null;
        //     public bool Status { get; set; }
    }
}
