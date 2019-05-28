using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apibe.Models
{
    public class Compra
    {
            public long Id { get; set; }
            public string Usuario { get; set; }
            public List<Disco> Disco { get; set; }
            public float Valor { get; set; }
            public DateTime Data { get; set; } 
            public bool Finalizada { get; set; }
       

    }
}
