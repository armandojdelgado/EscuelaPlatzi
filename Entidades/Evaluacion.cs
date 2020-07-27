using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string UniqueId { get; private set;}
        public string Nombre { get; set; }

        public Evaluacion() => UniqueId = Guid.NewGuid().ToString();

        public Alumno Alumno {get; set;}

        public Asignatura Asignatura{get; set;}

        public float Nota {get; set;}

        public override string ToString() => $"Alumno:{Alumno.Nombre}, Asignatura: {Asignatura.Nombre}, Evalución:{Nombre}, Nota:{Nota}";

    }
}