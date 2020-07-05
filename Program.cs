using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi Academy",2020); //Se preciona Ctl + . para agregar el espacio de nombres
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Cali";
            Console.WriteLine(escuela.Nombre);
        }
    }
}
