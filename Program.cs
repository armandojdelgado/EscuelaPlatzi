using System;
using System.Collections.Generic;
using System.Linq;
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
            ImprimirCursosEscuela(engine.escuela);   
            int dummy = 0;         
            var listaObjetos = engine.GetObjetosEscuelas(
                out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, out int conteoCursos
                );

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
