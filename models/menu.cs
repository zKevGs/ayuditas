using Parcial.enums;

namespace Parcial.models
{
    public static class menu
    {

        static List<Action> Acciones = new List<Action>()
        {
            AgregarVideojuego,
            EliminarVideoJuego,
            ModificarVideoJuego,
            MostrarCatalogo,
        };

        public static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú ---\n" +
                    "1. Agregar Videojuego\n" +
                    "2. Eliminar Videojuego\n" +
                    "3. Modificar Videojuego\n" +
                    "4. Mostrar Videojuego\n" +
                    "5. Salir\n");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }
        }


        public static void AgregarVideojuego()
        {
            Console.Write("ingrese el nombre del videojuego a agregar: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("ingrese la plataforma del videojuego: ");
            foreach (var plataforma in Enum.GetValues(typeof(plataformas)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma} ");
            }
            int seleccionPlataforma = int.Parse(Console.ReadLine());
            plataformas plataformaSeleccionada = (plataformas)seleccionPlataforma;

            Console.Write("ingrese el precio del videojuego: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("ingrese el stock total: ");
            int stock = int.Parse(Console.ReadLine());

            videojuego jueguito = new videojuego(nombre, plataformaSeleccionada, precio, stock);
            systiendita.AgregarVideojuego(jueguito);
        }

        public static void EliminarVideoJuego() 
        {
            Console.Write("ingrese el nombre del videojuego a eliminar: ");
            string nombre = Console.ReadLine();

            systiendita.EliminarVideojuego(nombre);
        }

        public static void ModificarVideoJuego()
        {
            Console.Write("ingrese el nombre del videojuego a modificar: ");
            string nombre = Console.ReadLine();

            Console.Write("ingrese la plataforma del videojuego: ");
            foreach (var plataforma in Enum.GetValues(typeof(plataformas)))
            {
                Console.WriteLine($"{(int)plataforma}. {plataforma} ");
            }
            int seleccionPlataforma = int.Parse(Console.ReadLine());
            plataformas plataformaSeleccionada = (plataformas)seleccionPlataforma;

            Console.Write("ingrese el nuevo precio del videojuego: ");
            double precio = double.Parse(Console.ReadLine());

            Console.Write("ingrese el nuevo stock total: ");
            int stock = int.Parse(Console.ReadLine());

            systiendita.ModificarVideojuego(nombre, plataformaSeleccionada, precio, stock);
        }
        public static void MostrarCatalogo()
        {
            systiendita.MostrarCatalogo();
        }
    }

}
