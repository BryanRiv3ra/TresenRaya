using System.Data;
namespace TresenRaya
{
    class program
    {
        static void Main(string[] args)
        {
            char[,] tablero = new char[3, 3];
            iniciarTablero(ref tablero);

            string nombre1 = "";
            string nombre2 = "";
            bool turnojugador1 = true;
            string coordenada = "";
            char caracterusado = ' ';
            int casillasocupadas = 0;

            Console.WriteLine("Bienvenido al juego de 3 en raya");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

            while (nombre1 == "")
            {
                Console.WriteLine("Jugador 1 eres la x ahora ingresa tu nombre: ");
                nombre1 = Console.ReadLine();
                Console.WriteLine();
            }

            while (nombre2 == "")
            {
                Console.WriteLine("Jugador 2 eres la o ahora ingresa tu nombre: ");
                nombre2 = Console.ReadLine();
                Console.WriteLine();
            }

            while (casillasocupadas < 9 && !Unganador(tablero))
            {
                Console.Clear();
                Console.WriteLine("Bienvenido al juego de 3 en raya");
                Console.WriteLine("--------------------------------");
                Console.WriteLine();
                Console.WriteLine(TableroV(tablero));

                string nombrejugador = (turnojugador1) ? nombre1 : nombre2;
                Console.WriteLine($"{nombrejugador}, ingresa la coordenada para empezar");
                Console.WriteLine("por ejemplo, A1");

                while (true)
                {
                    coordenada = Console.ReadLine().ToUpper();
                    if (coordenadavalida(coordenada) && !Ocupada(tablero, coordenada))
                        break;
                    Console.WriteLine("La coordenada ingresada es inválida o ya está en uso, introduce otra por favor.");
                }

                caracterusado = (turnojugador1) ? 'x' : 'o';
                CambiarCordenada(tablero, coordenada, caracterusado);
                casillasocupadas++;

                if (Unganador(tablero))
                    break;

                turnojugador1 = !turnojugador1;
            }
            if (Unganador(tablero))
            {
                Console.WriteLine("Se acabó el juego.");
                if (Ganador(tablero) == 'x')
                    Console.WriteLine($"{nombre1} es el ganador");
                else
                    Console.WriteLine($"{nombre2} es el ganador");
            }
            else
                Console.WriteLine("Empate");

            Console.ReadKey();
        }
        static void iniciarTablero(ref char[,] tablero)
        {
            for (int contador1 = 0; contador1 < 3; contador1++)
            {
                for (int contador2 = 0; contador2 < 3; contador2++)
                {

                    tablero[contador1, contador2] = ' ';
                }

            }
        }
        static string TableroV(char[,] tablero)
        {
            string tablerov = "";
            tablerov = "    A    B    C" + Environment.NewLine;
            tablerov +=  " ┌────┬────┬────┐" + Environment.NewLine;
            tablerov += $"1|  {tablero[0,0]} |  {tablero[0, 1]} |  {tablero[0, 2]} |" + Environment.NewLine;
            tablerov +=  " ├────┼────┼────┤" + Environment.NewLine;
            tablerov += $"2|  {tablero[1, 0]} |  {tablero[1, 1]} |  {tablero[1, 2]} |" + Environment.NewLine;
            tablerov +=  " ├────┼────┼────┤" + Environment.NewLine;
            tablerov += $"3|  {tablero[2, 0]} |  {tablero[2, 1]} | {tablero[2, 2]}  |" + Environment.NewLine;
            tablerov +=  " └────┴────┴────┘" + Environment.NewLine;
            return tablerov;

        }
        static char Ganador(char[,] tablero)
        {
            if (tablero[0, 0] == tablero[0, 1] && tablero[0, 1] == tablero[0, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }
            if (tablero[1, 0] == tablero[1, 1] && tablero[1, 1] == tablero[1, 2] && tablero[1, 0] != ' ')
            {
                return tablero[1, 0];
            }
            if (tablero[2, 0] == tablero[2, 1] && tablero[2, 1] == tablero[2, 2] && tablero[2, 0] != ' ')
            {
                return tablero[2, 0];
            }
            if (tablero[0, 0] == tablero[1, 0] && tablero[1, 0] == tablero[2, 0] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }
            if (tablero[0, 1] == tablero[1, 1] && tablero[1, 1] == tablero[2, 1] && tablero[0, 1] != ' ')
            {
                return tablero[0, 1];
            }
            if (tablero[0, 2] == tablero[1, 2] && tablero[1, 2] == tablero[2, 2] && tablero[0, 2] != ' ')
            {
                return tablero[0, 2];
            }
            if (tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2] && tablero[0, 0] != ' ')
            {
                return tablero[0, 0];
            }
            if (tablero[0, 2] == tablero[1, 1] && tablero[1, 1] == tablero[2, 0] && tablero[0, 2] != ' ')
            {
                return tablero[0, 2];
            }
            return ' ';
        }
        static bool Unganador(char[,] tablero)
        {
            return Ganador(tablero) != ' ';
        }
        static bool Ocupada(char[,] tablero, int x, int y)
        {
            if (x < 0 || x > 2)
            {
                throw new ArgumentException("el valor de x debe de ser entre 0 hasta 2");
            }
            if (y < 0 || y > 2)
            {
                throw new ArgumentException("el valor de y debe de ser entre 0 hasta 2");
            }
            return tablero[x, y] != ' ';
        }
        static bool Ocupada(char[,] tablero, string coordenada)
        {
            switch (coordenada)
            {
                case "A1":
                    return Ocupada(tablero, 0, 0);
                case "A2":
                    return Ocupada(tablero, 0, 1);
                case "A3":
                    return Ocupada(tablero, 0, 2);
                case "B1":
                    return Ocupada(tablero, 1, 0);
                case "B2":
                    return Ocupada(tablero, 1, 1);
                case "B3":
                    return Ocupada(tablero, 1, 2);
                case "C1":
                    return Ocupada(tablero, 2, 0);
                case "C2":
                    return Ocupada(tablero, 2, 1);
                case "C3":
                    return Ocupada(tablero, 2, 2);
            }
           return false;
        }
        static void CambiarCordenada(char[,] tablero, string coordenada, char letra)
        {
            coordenada = coordenada.ToUpper();
            switch(coordenada)
            {
                case "A1":
                    tablero[0, 0] = letra;
                    return;
                case "A2":
                    tablero[0, 1] = letra;
                    return;
                case "A3":
                    tablero[0, 2] = letra;
                    return;
                case "B1":
                    tablero[1, 0] = letra;
                    return;
                case "B2":
                    tablero[1, 1] = letra;
                    return;
                case "B3":
                    tablero[1, 2] = letra;
                    return;
                case "C1":
                    tablero[2, 0] = letra;
                    return;
                case "C2":
                    tablero[2, 1] = letra;
                    return;
                case "C3":
                    tablero[2, 2] = letra;
                    return;
            }
        }
        static bool coordenadavalida(string coordenada)
        {
            switch (coordenada)
            {
                case "A1":
             
                case "A2":
                    
                case "A3":
                   
                case "B1":
                    
                case "B2":
                    
                case "B3":
                   
                case "C1":
                   
                case "C2":

                case "C3":
                    return true;
                default:
                    return false;
            }
        }
    }
}
