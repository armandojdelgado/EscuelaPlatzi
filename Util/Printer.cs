using static System.Console;

namespace CoreEscuela.util
{
    public static class Printer
    {
        public static void DrawLine(int tamaño=10)
        {
            WriteLine("".PadLeft(tamaño,'='));
        } 

        public static void WriteTitle(string titulo)   
        {
            int tamaño = titulo.Length + 4;
            DrawLine(tamaño);
            WriteLine($"| {titulo} |");
            DrawLine(tamaño);
        }

        public static void Beep(int frequency = 2000, int duration = 500, int cantidad = 1)
        {
            while(cantidad-- >0)//despues de comparar resta
            {
                System.Console.Beep(frequency, duration);
            }
        }
    }
}