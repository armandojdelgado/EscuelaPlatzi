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
            //escuela.Pais = "Colombia";
            //escuela.Ciudad = "Cali";

            //Se crea un curso
            var curso1 = new Curso(){
                Nombre = "101"
            };

            var curso2 = new Curso(){
                Nombre = "201"
            };

            var curso3 = new Curso(){
                Nombre = "301"
            };

            Console.WriteLine(escuela);//al imprimir el objeto se llama implicitamente el ToString

            System.Console.WriteLine("============");
            Console.WriteLine(curso1.Nombre + ","+ curso1.UniqueId);
            Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}"); //Otra forma de escribir
            Console.WriteLine(curso3);
        }
    }
}
