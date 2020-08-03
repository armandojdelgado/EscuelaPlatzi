using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela : ObjetoEscuelaBase
    {
        public int AñoDeCreacion { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }

        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion) = (nombre, año);

        //Sobrecarga del Constructor
        public Escuela(string nombre, int año,
                        TiposEscuela tipo,
                        string pais = "",
                        string ciudad = "")
        {
            //Asignación de tuplas
            (Nombre, AñoDeCreacion) = (nombre, año);
            //Asignación normal
            Pais = pais;
            Ciudad = ciudad;
        }

        //public override string ToString() => $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \n Pais: {Pais}, Ciudad: {Ciudad}";
        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela}, \nPais: {Pais}, {System.Environment.NewLine} Ciudad: {Ciudad}";
        }

    }
}