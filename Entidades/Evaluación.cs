using System;

namespace CoreEscuela.Entidades
{
    public class Evaluación : ObjetoEscuelaBase
    {
        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }

        public float Nota { get; set; }

        public override string ToString() => $"Alumno:{Alumno.Nombre}, Asignatura: {Asignatura.Nombre}, Evalución:{Nombre}, Nota:{Nota}";

    }
}