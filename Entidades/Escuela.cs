namespace CoreEscuela.Entidades
{
    class Escuela
    {
        string nombre;

        //Se protege dentro de una propiedad
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value.ToUpper(); } //Indicamos que al asignar dejarlo en mayuscula
        }

        //PROPIEDAD AUTOIMPLEMENTADA
        //el compilador crea una variable añoDeCreacion
        public int AñoDeCreacion{get;set;}

        //Prop, atajo para crear una propiedad
        public string Pais { get; set; }
        public string Ciudad { get; set; }

        //Propfull
        public TiposEscuela TipoEscuela {get; set;}
        
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

        //Sobrecarga del Constructor
        public Escuela(string nombre, int año, 
                        TiposEscuela tipo, 
                        string pais = "", 
                        string ciudad = "")
        {
            //Asignación de tuplas
            (Nombre,AñoDeCreacion)=(nombre,año);
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