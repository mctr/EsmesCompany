using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EsmesCompany.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz.")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "Kullanıcı Adınız 3 - 24 karakter arasında olmalıdır.")]
        public string Username { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Lütfen Şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Şifreniz en az 5, en çok 16 karakter olabilir.")]
        public string Password { get; set; }

        [DisplayName("İsim Soyisim")]
        [Required(ErrorMessage = "Lütfen İsminizi giriniz")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "İsminiz 3 - 24 karakter arasında olmalıdır.")]
        public string Fullname { get; set; }

        public virtual List<Subscription> Subscriptions { get; set; }
    }
}