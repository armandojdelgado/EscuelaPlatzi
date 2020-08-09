using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        private Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObj)
        {
            if (dicObj == null)
                throw new ArgumentNullException(nameof(dicObj));

            _diccionario = dicObj;
        }

        public IEnumerable<Escuela> GetListaEscuela()
        {
            IEnumerable<Escuela> rta;
            //var lista = _diccionario.GetValueOrDefault(LlaveDiccionario.Escuela);
            if (_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }else
            {
                rta = null;
                //Escribir en el Log de auditoria
            }
            return rta;
        }

        public IEnumerable<Evaluación> GetListaEvaluaciones()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluación, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluación>();
            }else
            {
                return new List<Evaluación>();
            }            
        }


        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out _);
        }

        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluación> listaEv)
        {
                var listaEvaluaciones = GetListaEvaluaciones();
                listaEv = listaEvaluaciones;
                return (from Evaluación ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string,IEnumerable<Evaluación>> GetDiccionarioEvaluacionesXAsignatura()
        {
            var dicRta = new Dictionary<string,IEnumerable<Evaluación>>();

            var listaAsig = GetListaAsignaturas(out var listaEva);
            foreach(var asig in listaAsig)
            {
                var evalAsig = from eval in listaEva
                        where eval.Asignatura.Nombre == asig
                        select  eval;
                
                dicRta.Add(asig, evalAsig);
            }
            return dicRta;
        }
    
        public Dictionary<string, IEnumerable<object>> GetPromeAlumnPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<object>>();
            var dicEvalPorAsig = GetDiccionarioEvaluacionesXAsignatura();

            foreach(var asigConEval in dicEvalPorAsig)
            {
                var dummy = from eval in asigConEval.Value
                            select new 
                            {
                                eval.Alumno.UniqueId,
                                AlumnoNombre = eval.Alumno.Nombre,
                                NombreEval = eval.Nombre,
                                eval.Nota,
                            };

            }
            return rta;
        }
    }
}