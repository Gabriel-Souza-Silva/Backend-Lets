using BackEnd___Lets.Data;
using BackEnd___Lets.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd___Lets.Interceptor
{
    public class ServiceInterceptor : ActionFilterAttribute,IActionFilter
    {
        private readonly CardContext _context;
        public ServiceInterceptor(CardContext context) {_context = context;}

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var descriptor = ((ControllerActionDescriptor)context.ActionDescriptor);
            string method = descriptor.ActionName == "Delete" ? "Removido" : "Alterado";
            string id = context.ActionArguments["id"].ToString();

            #region BLOCO ESPECIFICO PARA OBTER O TITULO, #TODO JEITO MELHOR DE FAZER ISSO
            List<Card> cards = new List<Card>();
            cards.AddRange(_context.cards.AsNoTracking().ToList());
            var card = cards.FirstOrDefault(x => x.id.ToString() == id);
            string titulo = card != null ? "- " + card.titulo : "";
            #endregion

            Console.WriteLine($"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - Card - {id} {titulo} - {method}");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
