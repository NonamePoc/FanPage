using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Domain.Identity
{
    public class Follower
    {
        [Key]
        public int FollowerId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
