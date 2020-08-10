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
            //AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;
            //AppDomain.CurrentDomain.ProcessExit += (o,s)=>Printer.Beep(2000,1000,1);
            
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienvenidos a la escuela");
           
           var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
           //reporteador.GetListaEscuela();
           var evalList = reporteador.GetListaEvaluaciones();
           var listaAsig = reporteador.GetListaAsignaturas();
           var listaEvalAsig = reporteador.GetDiccionarioEvaluacionesXAsignatura();
           var listaPromXAsig = reporteador.GetPromeAlumnPorAsignatura();
           var topListaPromXAsig = reporteador.GetTopPromeAlumnPorAsignatura(5);
           
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("SALIENDO");
            Printer.Beep(3000,1000,3);
            Printer.WriteTitle("SALIO");
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
    }
}
