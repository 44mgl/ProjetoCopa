using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_React_CopaDoMundo.Models;
using DotNet_React_CopaDoMundo.Data; 
using Microsoft.AspNetCore.Mvc; // Importa o namespace Microsoft.AspNetCore.Mvc, que contém classes e atributos para criar controladores e ações de API no ASP.NET Core

namespace DotNet_React_CopaDoMundo.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota do controller como "api/selecao"
    public class SelecaoController
    {
        private readonly AppDbContext _context; // Contexto do banco injetado pelo ASP.NET Core. Será utilizado pelos métodos do Controller para acessar o banco.
        public SelecaoController(AppDbContext context)  
        {
            _context = context;
        }

        [HttpGet]
        public List<Selecao>GetSelecoes() 
        {
            var selecoes = _context.Selecoes.ToList(); 
            return selecoes;
        }
        
    }
}