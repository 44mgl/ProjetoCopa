using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNet_React_CopaDoMundo.Models;

namespace DotNet_React_CopaDoMundo.Data
{
    public class AppDbContext : DbContext // Classe que representa o contexto do banco de dados, responsável por gerenciar as entidades e suas relações
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // Construtor que recebe as opções de configuração do DbContext
        {
        }
    
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Selecao> Selecoes { get; set; }
        public DbSet<Clube> Clubes { get; set; }
    }

}

// O AppDbContext : DbContext herda os comportamentos da classe DbContext, enquanto o construtor pega as configurações direto do Program.cs e passa essas configurações para a classe DbContext atrás do base(options.
// Migration é um historico versionado da estrutura do banco de dados.