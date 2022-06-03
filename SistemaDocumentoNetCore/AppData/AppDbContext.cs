using Microsoft.EntityFrameworkCore;
using SistemaDocumentoNetCore.Models;

namespace SistemaDocumentoNetCore.AppData
{
    public class AppDbContext :DbContext
    {
        internal readonly object Processo;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Documento> Documentos { get; set; }


    }
}
