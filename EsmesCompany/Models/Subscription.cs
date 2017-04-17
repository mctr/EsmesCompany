using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EsmesCompany.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

       
        public int Ocak { get; set; }
        public int Subat { get; set; }
        public int Mart { get; set; }
        public int Nisan { get; set; }
        public int Mayis { get; set; }
        public int Haziran { get; set; }
        public int Temmuz { get; set; }
        public int Agustos { get; set; }
        public int Eylul { get; set; }
        public int Ekim { get; set; }
        public int Kasim { get; set; }
        public int Aralik { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int YearId { get; set; }

        public virtual User User { get; set; }

        public virtual Year Year { get; set; }
    }
}