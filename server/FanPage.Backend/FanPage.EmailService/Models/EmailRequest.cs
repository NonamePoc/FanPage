using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.EmailService.Models
{
    public class EmailRequest
    {
        public string? EmailTo { get; set; }

        public string? Subject { get; set; }

        public string? Html { get; set; }
    }
}
