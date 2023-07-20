using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudApi.Contexto
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options) : base(options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
    }
}