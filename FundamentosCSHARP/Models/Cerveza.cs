using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentosCSHARP.Models
{
    internal class Cerveza:Bebida , IBebidaAlcoholica
    {
        public Cerveza(int Cantidad, string Nombre = "Cerveza") //los valores por defecto siempre van a la derecha
            :base (Nombre, Cantidad) //Base hace referencia al constructor padre
        {

        }

        public int Alcohol { get; set ; }

        public string Marca { get; set ;}
        public void MaxRecomendado()
        {
            Console.WriteLine("El maximo permitido son 20 botellas");
        }
    }
}
