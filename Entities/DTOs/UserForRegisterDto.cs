using Core.Entities;
using Core.Entities.Abstract;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto //Kullanıcı Kaydı oluşturma
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
