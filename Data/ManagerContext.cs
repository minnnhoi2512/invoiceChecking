using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManagerInvoice.Models;

namespace Manager.Data
{
    public class ManagerContext : DbContext
    {
        public ManagerContext (DbContextOptions<ManagerContext> options)
            : base(options)
        {
        }

        public DbSet<ManagerInvoice.Models.Order> Order { get; set; } = default!;
        public DbSet<ManagerInvoice.Models.Image> Image { get; set; } = default!;
        public DbSet<ManagerInvoice.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<ManagerInvoice.Models.ProgressOrder> ProgressOrder { get; set; } = default!;
        public DbSet<ManagerInvoice.Models.Sector> Sector { get; set; } = default!;
    }
}
