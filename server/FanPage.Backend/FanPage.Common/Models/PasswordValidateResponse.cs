using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Common.Models
{
    public class PasswordValidateResponse
    {
        public PasswordValidateResponse()
        {
            Errors = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Errors { get; set; }

        public bool Succeeded => !Errors.Any();
    }
}
