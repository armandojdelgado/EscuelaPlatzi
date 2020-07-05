using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se preciona Ctl + . para agregar el espacio de nombres
            var escuela = new Escuela("Platzi Academy",2020, 
                            TiposEscuela.Primaria,
                            ciudad: "Cali"); 
            escuela.Pais = "Colombia";
            escuela.Ciudad = "Cali";
            Console.WriteLine(escuela);
        }
    }
}
