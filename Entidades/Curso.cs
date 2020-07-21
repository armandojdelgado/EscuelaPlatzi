using System; //Para el Guid
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        //identificador unico (numero entero o cadena
        //Se crea un identificador unico de tipo cadena
        public string UniqueId {get;
                                private set;} //la asignación solo lo hace la clase con el Guid
        public string Nombre {get;set;}
        public TiposJornada Jornada{get;set;}

        public List<Asignatura> Asignaturas {get;set;}

        public List<Alumno> Alumnos {get; set;}
        
        //Se crea un contructor
        public Curso()
        {
            //Generar el codigo unico automaticamente
            UniqueId = Guid.NewGuid().ToString();
        }
        //Tambien se puede crear el constructor asi:
        //public Curso() =>UniqueId = Guid.NewGuid().ToString();
    }
}