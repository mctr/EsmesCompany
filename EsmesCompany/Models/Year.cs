using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EsmesCompany.Models
{
    public class Year
    {
        [Key]
        public int YearId { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "Yıl değeri 4 karakter olmalıdır.")]
        public string YearName { get; set; }
              
        public virtual List<Subscription> Subscription { get; set; }

    }
}