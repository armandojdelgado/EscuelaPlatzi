using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Alumno: ObjetoEscuelaBase
    {
        //Cada alumno va a tener sus notas
        public List<Evaluación> Evaluaciones {get; set;} = new List<Evaluación>();
    }
}