using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibe.Models
{
    public class Disco
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public float Valor { get; set; }
        public float Cash { get; set; }
    }
}
