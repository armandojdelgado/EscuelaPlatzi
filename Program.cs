using System;
using CoreEscuela.Entidades;

namespace Etapa1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se preciona Ctl + . para agregar el espacio de nombres
            var escuela = new Escuela("Platzi Academy", 2020,
                            TiposEscuela.Primaria,
                            ciudad: "Cali");
            //escuela.Pais = "Colombia";
            //escuela.Ciudad = "Cali";

            //Se crea un curso
            var curso1 = new Curso()
            {
                Nombre = "101"
            };

            var curso2 = new Curso()
            {
                Nombre = "201"
            };

            var curso3 = new Curso()
            {
                Nombre = "301"
            };

            //Arreglo de objetos
            var arregloCursos = new Curso[3];

            //Se asinga la posición 0 del arreglo, forma de asignar:
            arregloCursos[0] = new Curso()
            {
                Nombre = "101"
            };

            //Se asigna la posición 1 del arreglo, otra forma de asignar:
            arregloCursos[1] = curso2;

            //Se asigna la posición 2 del arreglo, otra forma de asignar:
            arregloCursos[2] = new Curso
            {
                Nombre = "301"
            };

            Console.WriteLine(escuela);//al imprimir el objeto se llama implicitamente el ToString

            System.Console.WriteLine("============");
            //Console.WriteLine(curso1.Nombre + ","+ curso1.UniqueId);
            //Console.WriteLine($"{curso2.Nombre} , {curso2.UniqueId}"); //Otra forma de escribir
            //Console.WriteLine(curso3);

            //Imprimiendo el arreglo
            /*
            Console.WriteLine(arregloCursos[0].Nombre);
            Console.WriteLine("Presione ENTER para continuar:");
            Console.ReadLine(); //Espera a que alguien presiona Enter
            Console.WriteLine(arregloCursos[5].Nombre);
            */

            //Se crea metodo para que imprima curso
            ImprimirCursos(arregloCursos);
        }

        private static void ImprimirCursos(Curso[] arregloCursos)
        {
            int contador = 0;
           while(contador< arregloCursos.Length)
           {
               Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre} , ID: {arregloCursos[contador].UniqueId}");
              // contador = contador + 1;
              //contador += 1;
              contador++;
           }
        }
    }
}
