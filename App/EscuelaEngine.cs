using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;


namespace CoreEscuela.App
{
    public sealed class EscuelaEngine
    {

        public Escuela escuela { get; set; }

        #region constructores
        public EscuelaEngine()
        {

        }
        public EscuelaEngine(Escuela escuela)
        {
            this.escuela = escuela;

        }
        #endregion

        #region Métodos
        public void Inicializar()
        {
            escuela = new Escuela("Platzi Academia", 2020,
                            TiposEscuela.Primaria,
                            ciudad: "Cali");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
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

        public List<ObjetoEscuelaBase> GetObjetosEscuelas(
            out int conteoEvaluaciones, out int conteoAlumnos, out int conteoAsignaturas, out int conteoCursos,
            bool traeEvaluaciones = true, bool traeAlumnos = true, bool traeAsignaturas = true, bool traeCursos = true
            )
        {
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = conteoCursos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(escuela);
            if (traeCursos)
                listaObj.AddRange(escuela.Cursos);
            conteoCursos += escuela.Cursos.Count;

            foreach (var curso in escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;

                if (traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if (traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);

                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count;
                    }
                }
            }
            return listaObj;
        }

        private float ObtenerNota(Random rnd) => (float)Math.Round((5.0 * rnd.NextDouble()), 1);
        #endregion

        #region Métodos de carga
        private void CargarEvaluaciones()
        {
            foreach (var curso in escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);
                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in escuela.Cursos)
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

        private void CargarCursos()
        {
            escuela.Cursos = new List<Curso>()
                {
                    new Curso(){Nombre = "101", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "301", Jornada = TiposJornada.Mañana},
                    new Curso(){Nombre = "401", Jornada = TiposJornada.Tarde},
                    new Curso(){Nombre = "501", Jornada = TiposJornada.Tarde}
                };

            Random rnd = new Random();
            //Para cada curso genero de 5 a 20 Alumnos
            foreach (var curso in escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                curso.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
    }
    #endregion
}
