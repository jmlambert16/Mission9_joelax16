using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Models
{
    public class Checkout
    {
        [Key]
        [BindNever]
        public int CheckoutId { get; set; }
        
        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }

        [Required(ErrorMessage ="Please enter a name")]
        public string name { get; set; }

        [Required(ErrorMessage ="Please enter an address on 'AddressLine1'")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please enter a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter Zip")]
        public int zip { get; set; }
        [Required(ErrorMessage = "Please enter a Country")]
        public string Country { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
    }
}
