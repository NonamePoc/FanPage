using FanPage.Domain.Fanfik;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Persistence.Context
{
    public class FanfikContext : DbContext
    {
        public FanfikContext(DbContextOptions<FanfikContext> options) : base(options)
        {
        }

        public DbSet<Fanfic> Fanfics { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
    }
}
