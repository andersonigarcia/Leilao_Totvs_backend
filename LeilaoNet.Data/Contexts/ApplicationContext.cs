using LailaoNet.Domain.Core.Data;
using LeilaoNet.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LeilaoNet.Data.Contexts
{
    public class ApplicationContext: DbContext, IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            //Add Maps
            modelBuilder.ApplyConfiguration(new LeilaoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = _configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }       

        public async Task<bool> CommitAsync()
        {
            var success = await SaveChangesAsync() > 0;
            return success;
        }

        public bool HasChanges()
        {
            var hasChanges = ChangeTracker.HasChanges();
            return hasChanges;
        }
    }
}
