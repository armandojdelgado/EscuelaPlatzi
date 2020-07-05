namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;

        //Se protege dentro de una propiedad
        public string Nombre
        {
            get { return "Copia: " + nombre; }
            set { nombre = value.ToUpper(); } //Indicamos que al asignar dejarlo en mayuscula
        }

        //shorcut de propiedad, 
        //el compilador crea una variable añoDeCreacion
        public int AñoDeCreacion{get;set;}

        //Prop, atajo para crear una propiedad
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        //Propfull
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        /*
        public Escuela(string nombre, int año) 
        {
            this.nombre = nombre;
            AñoDeCreacion = año;
        }
        */

        //El constructor es un metodo
        //otra forma de escribir el metodo contructor
        //Constructor => (Propieades)=(atributos)
        //Igualación por tuplas
        public Escuela (string nombre, int año) => (Nombre,AñoDeCreacion)=(nombre,año);

        

    }
}