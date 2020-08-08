﻿using System;
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
            Dictionary<int,string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10,"JuanK");
            diccionario.Add(23,"Lorem Ipsum");
            
            foreach(var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Valor: {keyValPair.Value} ");
            }
            var diccionarioTemp = engine.GetDiccionarioObjetos();
            engine.ImprimirDiccionario(diccionarioTemp,true);
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
