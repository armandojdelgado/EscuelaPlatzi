using System;
using System.Collections.Generic;
using CoreEscuela.App;
using CoreEscuela.Entidades;
using CoreEscuela.util;
//Carga la libreria Consola, permite usar sus metodos sin necesidad de colocar Console
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la escuela");
            //Printer.Beep(frequency: 1000, cantidad: 10);
            ImprimirCursosEscuela(engine.Escuela);            

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Pruebas de Polimorfismo");

            var alumnoTest = new Alumno{Nombre ="Claire UnderWood"};

            Printer.WriteTitle("Alumno");
            WriteLine($"Alumno: {alumnoTest.Nombre}");
            WriteLine($"Alumno: {alumnoTest.UniqueId}");
            WriteLine($"Alumno: {alumnoTest.GetType()}");

            ObjetoEscuelaBase ob = alumnoTest;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

            var evalución = new Evaluación(){ Nombre = "Evaluación de Math",Nota = 4.5f};
            Printer.WriteTitle("Evalucación");
            WriteLine($"Evalución: {evalución.Nombre}");
            WriteLine($"Evalución: {evalución.UniqueId}");
            WriteLine($"Evalución: {evalución.Nota}");
            WriteLine($"Evalución: {evalución.GetType()}");

            ob = evalución;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine($"Alumno: {ob.Nombre}");
            WriteLine($"Alumno: {ob.UniqueId}");
            WriteLine($"Alumno: {ob.GetType()}");

        }

        private static bool Predicado(Curso obj)
        {
            return obj.Nombre == "301";
        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            //if (escuela!=null && escuela.Cursos!=null)
            if (escuela?.Cursos != null) //No va a validar Curso, salvo que escuela sea diferente de nulo
            {
                //using static System.Console; Hace que no sea necesario colocar Console
                Printer.WriteTitle("Curso de la escuela");
                
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre} , ID: {curso.UniqueId}");
                    //ImprimirEvaluaciones(curso);
                }
            }
        }

        /*private static void ImprimirEvaluaciones(Curso curso)
        {
            foreach (var ev in  curso.Evaluaciones)
            {
                System.Console.WriteLine(ev.ToString());
            }            
        }*/
    }
}
