using api_filmes_senai.Domains;
using Event_plus.Domains;
using Microsoft.EntityFrameworkCore;
using Projeto_Event_Plus.Domains;

namespace Event_plus.Context
{
    public class Evento_Contex : DbContext
    {
     public Evento_Contex()
        {
                
        }
        public Evento_Contex(DbContextOptions<Evento_Contex> options) : base(options) { }

        public DbSet<Eventos> Evento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<Presenca> Presenca { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =NOTE39-S28\\SQLEXPRESS; Database = Event-plus; User Id = sa; Pwd = Senai@134; TrustServerCertificate=true;");

            }
        }
    }
}
