using Microsoft.EntityFrameworkCore;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Data
{
    public static class DbContextExtentions
    {
        public static void AddAuditInfo(this DbContext ctx)
        {
            //alle entities ophalen die geupdated zijn
            var entries = ctx.ChangeTracker.Entries()
                .Where(e => e.Entity is BaseAuditableEntity && (e.State is EntityState.Added || e.State is EntityState.Modified));

            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added) ((BaseAuditableEntity)entry.Entity).Created = DateTime.Now;
                ((BaseAuditableEntity)entry.Entity).Modified = DateTime.Now;
            }
        }
    }
}
