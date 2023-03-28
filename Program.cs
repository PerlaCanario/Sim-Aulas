namespace Sim_Aulas
{
    internal class Program
    {
        const int estudiantesTotales = 175;
        static int estudiantes = 0;
        static int year = 1;
        static int cantidadAprobados = 0;
        static int cantidadRepetidos = 0;
        static int cantidadAbandonos = 0;
        static int cantidadAprobadosTotal = 0;
        static int cantidadRepetidosTotal = 0;
        static int cantidadAbandonosTotal = 0;
        static int cantidadEstudiantesTotal = 0;

        static Random random = new Random();

        static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        static double RandomNumber(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }

        //Funcion para calcular la cantidad de estudiantes que ingresan en el año
        static int IngresoEstudiantes(int cantidadtotal)
        {
            estudiantes = RandomNumber(0, cantidadtotal);
            cantidadEstudiantesTotal += estudiantes;
            return estudiantes;
        }

        //Funcion para calcular la cantidad de estudiantes que pasan el año
        static int Aprobados()
        {
            cantidadAprobados = (int)(estudiantes * RandomNumber(0.3, 0.5));
            estudiantes -= (int)cantidadAprobados;
            cantidadAprobadosTotal += cantidadAprobados;
            return cantidadAprobados;
        }

        //Funcion para calcular la cantidad de estudiantes que repiten el año
        static double Repetidos()
        {
            cantidadRepetidos = (int)(estudiantes * RandomNumber(0.1, 0.3));
            estudiantes -= (int)cantidadRepetidos;
            cantidadRepetidosTotal += cantidadRepetidos;
            return cantidadRepetidos;
        }

        //Funcion para calcular la cantidad de estudiantes que abandonan el año
        static double Abandonos()
        {
            cantidadAbandonos = (int)(estudiantes * RandomNumber(0.1, 0.2));
            estudiantes -= (int)cantidadAbandonos;
            cantidadAbandonosTotal += cantidadAbandonos;
            return cantidadAbandonos;
        }

        static int ActualizarAño()
        {
            year++;
            return year;
        }

        static void SimularExamenes()
        {
            Aprobados();
            Repetidos();
            Abandonos();
            Console.WriteLine($"En el año {year} ingresaron {estudiantes} estudiantes, de los cuales {cantidadAprobados} aprobaron, {cantidadRepetidos} repitieron y {cantidadAbandonos} abandonaron");
        }

        static void SimularAño()
        {
            int cantidadMaxima = estudiantesTotales - (int)cantidadRepetidos;
            IngresoEstudiantes(cantidadMaxima);
            SimularExamenes();
            ActualizarAño();
        }

        static void CalcularCantidadEstudiantesporAño()
        {
            double cantidadEstudiantesporAño = cantidadEstudiantesTotal / 5;
            Console.WriteLine($"La cantidad de estudiantes que ingresaron por año fue: {cantidadEstudiantesporAño}");
        }
        static void SimularCarrera()
        {
            for (int i = 0; i < 5; i++)
            {
                SimularAño();
            }
            Console.WriteLine($"En total la cantidad de estudiantes que aprobaron fue: {cantidadAprobadosTotal}, los repetidos: {cantidadRepetidosTotal} y los que abandonaron: {cantidadAbandonosTotal} ");
            Console.WriteLine($"La cantidad de estudiantes que ingresaron a la carrera fue: {cantidadEstudiantesTotal}");
            CalcularCantidadEstudiantesporAño();
        }

        //Funcion para calcular la cantidad de aulas que se necesitan 
        static int CalcularCantidadAulas()
        {
            IngresoEstudiantes(estudiantesTotales - (int)cantidadRepetidosTotal);
            Aprobados();
            Repetidos();
            int cantidadTotal = ((int)(cantidadEstudiantesTotal + cantidadAprobadosTotal + cantidadRepetidosTotal));
            int cantidadAulas = cantidadTotal / 30;
            if (cantidadTotal % 30 != 0)
            {
                cantidadAulas++;
            }

            Console.WriteLine($"La cantidad de aulas que se necesitan es: {cantidadAulas}");
            return cantidadAulas;

        }

        static void Main(string[] args)
        {
            SimularCarrera();
            CalcularCantidadAulas();
        }
        
    }
}