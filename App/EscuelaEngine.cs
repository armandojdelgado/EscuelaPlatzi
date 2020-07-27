using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;


namespace CoreEscuela.App
{
    public class EscuelaEngine
    {

        public EscuelaEngine(Escuela escuela)
        {
            this.Escuela = escuela;

        }
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academy", 2020,
                            TiposEscuela.Primaria,
                            ciudad: "Cali");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            Random rnd = new Random();
            int[] nroevaluacion = { 1, 2, 3, 4, 5 };
            foreach (var cur in Escuela.Cursos)
            {
                var listEvaluacion = from asi in cur.Asignaturas
                                     from al in cur.Alumnos
                                     from nro in nroevaluacion
                                     select new Evaluacion
                                     {
                                         Nombre = asi.Nombre + " #" + nro,
                                         Alumno = al,
                                         Asignatura = asi,
                                         Nota = ObtenerNota(rnd)
                                     };
                cur.Evaluaciones = listEvaluacion.ToList();
            }

        }

        private float ObtenerNota(Random rnd) => (float)Math.Round((5.0 * rnd.NextDouble()), 1);

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                    {
                        new Asignatura{Nombre="Matematicas"},
                        new Asignatura{Nombre="Educación Física"},
                        new Asignatura{Nombre="Español"},
                        new Asignatura{Nombre="Ciencias Naturales"}
                    };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar(int cantidadAlumnos)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Donald", "Alvaro", "Nicolas" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murthy", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            //se realiza una combinatoria con arreglos
            //Linq lenguaje envevido de consulta
            var listaAlumnos = from n1 in nombre1 //Por cada nombre 1 se combinara con nombre 2 y se combinara con apellido1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidadAlumnos).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>()
                {
                    new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                    new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
                };

            Random rnd = new Random();
            //Para cada curso genero de 5 a 20 Alumnos
            foreach (var curso in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
}
