using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto //Kullanıcı girişi
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
