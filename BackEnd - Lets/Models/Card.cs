using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd___Lets.Models
{
    public class Card
    {
        public Card(){}

        public Card(string titulo, string conteudo, string lista)
        {
            this.titulo = titulo;
            this.conteudo = conteudo;
            this.lista = lista;
        }

        public int id { get; set; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public string lista { get; set; }
    }
}
