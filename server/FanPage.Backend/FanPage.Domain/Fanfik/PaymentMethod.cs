using FanPage.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Fanfik
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string UserId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CVV { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
