using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Categoria()
        {

        }
        public Categoria(int Id, string nom)
        {
            id = Id;
            nombre = nom;
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
