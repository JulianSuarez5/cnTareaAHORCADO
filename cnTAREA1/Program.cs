using System;
using System.Linq;

namespace Ahorcado
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                // Mensaje de bienvenida
                Console.WriteLine("Bienvenido al juego de ahorcado.");

                // Genera una lista de palabras
                string[] palabras = { "mundo", "ahorcado", "programacion", "lenguaje", "c#", "console", "ingeniero", "informatica" };

                // Pide al jugador que elija la dificultad
                Console.WriteLine("¿Cuántas vidas quieres tener? (1-7)");
                int vidas = int.Parse(Console.ReadLine());

                // Genera una palabra aleatoria
                string palabra = palabras[new Random().Next(palabras.Length)];

                // Inicia el juego
                char[] letrasAcertadas = new char[palabra.Length];
                for (int i = 0; i < letrasAcertadas.Length; i++)
                {
                    letrasAcertadas[i] = '_';
                }

                // Bucle central del juego
                while (vidas > 0)
                {
                    // Muestra el estado del juego
                    Console.WriteLine("Palabra: {0}", string.Join(" ", letrasAcertadas));

                    // Pide una letra al jugador
                    char letra = char.ToLower(Console.ReadKey().KeyChar);

                    // Comprueba si la letra es correcta
                    bool letraCorrecta = false;
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        if (palabra[i] == letra)
                        {
                            letrasAcertadas[i] = letra;
                            letraCorrecta = true;
                        }
                    }

                    // Actualizar el estado del juego
                    if (!letraCorrecta)
                    {
                        vidas--;
                        Console.WriteLine("\nLetra incorrecta. Te quedan {0} intentos.", vidas);
                    }
                    else
                    {
                        Console.WriteLine("\nLetra correcta.");
                    }

                    // Dibuja el ahorcado
                    DibujarAhorcado(vidas);

                    // Comprueba si el jugador ha ganado
                    if (string.Join("", letrasAcertadas) == palabra)
                    {
                        Console.WriteLine("Felicidades has ganado!");
                        break;
                    }
                }

                // Comprueba si el jugador ha perdido
                if (vidas <= 0)
                {
                    Console.WriteLine("Has perdido!");
                    Console.WriteLine("La palabra era: {0}", palabra);

                }

                Console.WriteLine("¿Quieres jugar de nuevo? (s/n)");
                string respuesta = Console.ReadLine().ToLower();
                if (respuesta != "s")
                {
                    salir = true;
                }

                Console.Clear();
            }
        }

        static void DibujarAhorcado(int vidas)
        {
            Console.WriteLine("   +---+");
            Console.WriteLine("   |   |");

            // Dibujar el ahorcado cuando vaya perdiendo vidas
            switch (vidas)
            {
                case 6:
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 5:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 4:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("   |   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 3:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|   |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 2:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 1:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("  /    |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
                case 0:
                    Console.WriteLine("   O   |");
                    Console.WriteLine("  /|\\  |");
                    Console.WriteLine("  / \\  |");
                    Console.WriteLine("       |");
                    Console.WriteLine("       |");
                    Console.WriteLine("=========");
                    break;
            }
        }
    }
}