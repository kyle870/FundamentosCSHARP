using FundamentosCSHARP.Models;
using System;
using System.Collections.Generic;

namespace FundamentosCSHARP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int index = 0;
            //Un arreglo, al arreglo se le da una longitud inicial
            int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            foreach (int numero in numeros)
            {
                Console.WriteLine($"La iteración {index} es {numero}");
                index++;
            }
            Console.WriteLine("**********************************************");
            
            
            //Una lista que no tiene longitud
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            list.Add(9);
            list.Add(0);
            //list.Remove(2);

            foreach (int numero in list)
            {
                Console.WriteLine($"Elemento: {numero}");
            }

            //Creamos una lista de clases
            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10,"Prem")};

            //Forma 1 de crear un objeto, sin nombre de variable
            cervezas.Add(new Cerveza(10));

            //Forma 2 de crear un objeto, con nombre de variable
            Cerveza erdinger = new Cerveza(50,"Cerveza de trigo");
            cervezas.Add(erdinger);

            Console.WriteLine("**********************************************");
            foreach (var cerveza in cervezas) { 
                Console.WriteLine($"Cerveza nombre {cerveza.Nombre} y cantidad {cerveza.Cantidad}");
            }


            Console.WriteLine("************************************************");
            var bebidaAlcoholica = new Vino(100);
            MostrarRecomendaciones(bebidaAlcoholica);
            
            
            Console.WriteLine("************************************************");
            //Instanciación de la clase de conexion de la base de datos
            CervezaBD cervezaBD = new CervezaBD();

            //insertar cervezas
            Cerveza cerveza1 = new Cerveza(15, "Corona");
            cerveza1.Marca = "Minerva";
            cerveza1.Alcohol = 6;
            cervezaBD.Add(cerveza1);


            //obtener las cervezas
            var cerv = cervezaBD.Get();
            
            foreach (var cer in cerv)
            {
                Console.WriteLine($"Nombre: {cer.Nombre} Cantidad {cer.Cantidad}");
            }
        }

        static void MostrarRecomendaciones(IBebidaAlcoholica bebida)
        {
            bebida.MaxRecomendado();
        }


    }
}
