using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using sistemasugestao.Models;

namespace sistemasugestao.Context
{
    public class GerarDadosDB
    {
         public static void IncluiDadosDB(IApplicationBuilder app)
        {
           using (var serviceScope = app.ApplicationServices.CreateScope())
           {
            var context = serviceScope.ServiceProvider.GetService<MyContext>();

            context.Database.Migrate();
            
            if (!context.Sugestoes.Any())
            {
                context.Avaliadores.AddRange(
                    new Avaliador(){ name = "Avaliador 1"},
                     new Avaliador(){ name = "Avaliador 2"}
                );
                context.SaveChanges();

                context.Campanhas.AddRange(
                    new Campanha(){Titulo = "Melhoria de Processos"},
                    new Campanha(){Titulo = "Redução de Custos"}
                );
                context.SaveChanges();

                context.Sugestoes.AddRange(
                    new Sugestao(){Descricao="Reuniões de no máximo 15 minutos", CampanhaID=1,AvaliadorID=1 },
                    new Sugestao(){Descricao="Verificar processos para evitar retrabalho", CampanhaID=1,AvaliadorID=2 },
                    new Sugestao(){Descricao="Troca de Lâmpadas antigas", CampanhaID=2,AvaliadorID=2 },
                    new Sugestao(){Descricao="Conscientização de desperdicio de materiais", CampanhaID=2,AvaliadorID=2 },
                    new Sugestao(){Descricao="Instalar temporizador nos aparelhos de ar condicionado", CampanhaID=2,AvaliadorID=2 }

                );
                context.SaveChanges();                                             
            }   


           } 
        }
    }
}