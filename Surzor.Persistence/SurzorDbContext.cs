using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Surzor.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Surzor.Persistence
{
    public class SurzorDbContext : DbContext
    {
        public SurzorDbContext(DbContextOptions<SurzorDbContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyDbSets();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SurzorDbContext).Assembly);
            void ApplyDbSets()
            {
                System.Reflection.Assembly asmb = typeof(AuditableEntity).Assembly;
                var types = asmb.GetTypes();
                types.Where(w => typeof(BaseEntity).IsAssignableFrom(w)
                                 && w.Namespace.StartsWith("Surzor.Domain.Entities"))
                    .Distinct()
                    .ToList()
                    .ForEach(poco => { modelBuilder.Entity(poco); });
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDateTime = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifyDateTime = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
