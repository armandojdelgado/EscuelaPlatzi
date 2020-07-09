using System;
using CoreEscuela.Entidades;
//Carga la libreria Consola, permite usar sus metodos sin necesidad de colocar Console
using static System.Console;

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
            /*
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
*/
            //Arreglo de objetos
            /*
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
            */

            //otra forma de crear un arreglo de objetos de una forma mas ordenada
            /*
            var arregloCursos = new Curso[3]
            {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
            };
            */
            //optimización

            escuela.Cursos = new Curso[]
            {
                new Curso(){Nombre = "101"},
                new Curso(){Nombre = "201"},
                new Curso(){Nombre = "301"}
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
            /*
            Console.WriteLine("RECORRIDO CON WHILE");
            ImprimirCursosWhile(escuela.Cursos);
            Console.WriteLine("RECORRIDO CON DO WHILE");
            ImprimirCursosDoWhile(escuela.Cursos);
            Console.WriteLine("RECORRE CON FOR");
            ImprimirCursosFor(escuela.Cursos);
            Console.WriteLine("RECORRIDO CON FOREACH");
            ImprimirCursosForEach(escuela.Cursos);
            */
            
            ImprimirCursosEscuela(escuela); //Se presiona Ctl + . para que Code cree el metodo

            bool rta = 10==10;
            int cantidad =10;
            if (rta == false)
            {
                WriteLine("Se cumplio la condición #1");
            }else if(cantidad > 15)
            {
                WriteLine("Se cumplio la condicion #2");
            }
            else
            {
                WriteLine("No se cumplio la condición #3");
            }

            if (cantidad > 5 && rta)
            {
                WriteLine("Se cumplio la condición #4");
            }

            if (cantidad >15 || rta)
            {
                WriteLine("Se cumplio la condición #5");
            }

            cantidad = 10;
            if ((cantidad > 15 || !rta) && (cantidad%5==0))
            {
                WriteLine("Se cumplio la condición #6");
            }
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            //if (escuela!=null && escuela.Cursos!=null)
            if (escuela?.Cursos!=null) //No va a validar Curso, salvo que escuela sea diferente de nulo
            {
                //using static System.Console; Hace que no sea necesario colocar Console
                WriteLine("********************");
                WriteLine("CURSOS DE LA ESCUELA");
                WriteLine("********************");
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre} , ID: {curso.UniqueId}");
                }
            }
        }

        private static void ImprimirCursosWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            while (contador < arregloCursos.Length)
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre} , ID: {arregloCursos[contador].UniqueId}");
                // contador = contador + 1;
                //contador += 1;
                contador++;
            }
        }

        private static void ImprimirCursosDoWhile(Curso[] arregloCursos)
        {
            int contador = 0;
            do
            {
                Console.WriteLine($"Nombre: {arregloCursos[contador].Nombre} , ID: {arregloCursos[contador].UniqueId}");
                // contador = contador + 1;
                //contador += 1;
                contador++;
            } while (contador < arregloCursos.Length);
        }

        private static void ImprimirCursosFor(Curso[] arregloCursos)
        {
            for (int i = 0; i < arregloCursos.Length; i++)
            {
                Console.WriteLine($"Nombre: {arregloCursos[i].Nombre} , ID: {arregloCursos[i].UniqueId}");
            }

        }

        private static void ImprimirCursosForEach(Curso[] arregloCursos)
        {
            foreach (var curso in arregloCursos)
            {
                Console.WriteLine($"Nombre: {curso.Nombre} , ID: {curso.UniqueId}");
            }
        }
    }
}
