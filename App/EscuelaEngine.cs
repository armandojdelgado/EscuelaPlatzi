using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class EscuelaEngine
    {
        
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
            
            foreach(var cursos in Escuela.Cursos)
            {
                cursos.Alumnos.AddRange(CargarAlumnos())
            };
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            throw new NotImplementedException();
        }

        private void CargarAsignaturas()
        {
            foreach(var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                    {
                        new Asignatura{Nombre="Matematicas"},
                        new Asignatura{Nombre="Educación Física"},
                        new Asignatura{Nombre="Español"},
                        new Asignatura{Nombre="Ciencias Naturales"}
                    };
                curso.Asignaturas.AddRange(listaAsignaturas);
            }
        }

        private IEnumerable<Alumno> CargarAlumnos()
        {
            string[] nombre1 = {"Alba","Felipa","Eusebio","Donald","Alvaro","Nicolas"};
            string[] apellido1 = {"Ruiz","Sarmiento","Uribe","Maduro","Trump","Toledo"};
            string[] nombre2 = {"Freddy","Anabel","Rick","Murthy","Silvana","Diomedes","Nicomedes","Teodoro"};

            //se realiza una combinatoria con arreglos
            //Linq lenguaje envevido de consulta
            var listaAlumnos = from n1 in nombre1 //Por cada nombre 1 se combinara con nombre 2 y se combinara con apellido1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{Nombre = $"{n1} {n2} {a1}"};
            return listaAlumnos;
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
        }
    }
}
