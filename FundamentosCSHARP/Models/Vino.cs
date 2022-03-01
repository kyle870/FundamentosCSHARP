using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal class Vino: Bebida, IBebidaAlcoholica
    {
        public Vino(int cantidad, string nombre="Vino") : base(nombre, cantidad)
        {
        }

        public int Alcohol { get; set; }

        public void MaxRecomendado()
        {
            Console.WriteLine("El maximo permitido son 10 copas");
        }
    }
}
