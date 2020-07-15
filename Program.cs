using System;
using System.Collections.Generic;
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

            escuela.Cursos = new List<Curso>()
                {
                    new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana}
                };
            
            escuela.Cursos.Add(new Curso(){Nombre = "102", Jornada = TiposJornada.Tarde});
            escuela.Cursos.Add(new Curso(){Nombre = "202", Jornada = TiposJornada.Tarde});

            //creamos otra colección
            var otraColeccion= new List<Curso>()
            {
                new Curso(){Nombre = "401", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "501", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "502", Jornada = TiposJornada.Tarde}
            };

            //Se crea un nuevo objeto curso
            Curso temp = new Curso(){Nombre = "101-Vacacional", Jornada=TiposJornada.Noche};
            //Se adiciona a la Lista Cursos otra coleccion de Lista cursos
            escuela.Cursos.AddRange(otraColeccion);
            //Se adiciona el nuevo curso a la coleccion como un solo elemento.
            escuela.Cursos.Add(temp);
            ImprimirCursosEscuela(escuela); //Se presiona Ctl + . para que Code cree el metodo
            //El sistema borra segun el HashCode
            WriteLine("Curso.Hash: "+ temp.GetHashCode());
            //Despues de mostrar los cursos de la escuela, se procede a eliminar un curso
            escuela.Cursos.Remove(temp);
            //Se valida que el curso eliminado no este dentro de la coleccion Cursos
            ImprimirCursosEscuela(escuela); 

        }

        private static void ImprimirCursosEscuela(Escuela escuela)
        {
            //if (escuela!=null && escuela.Cursos!=null)
            if (escuela?.Cursos != null) //No va a validar Curso, salvo que escuela sea diferente de nulo
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

    }
}
