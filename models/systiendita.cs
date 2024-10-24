using Parcial.enums;
using System.Linq.Expressions;

namespace Parcial.models
{
    public static class systiendita
    {
        public static List<videojuego> VideoJuegos = new();
        public static readonly string ListaVideojuegos = "ListaVideojuegos.txt";

        public static void AgregarVideojuego(videojuego videojuego)
        {
            var juego = VideoJuegos.Find(v => v.Nombre == videojuego.Nombre);

            if (juego != null) 
            {
                Console.WriteLine("juego ya existente");
            }

                VideoJuegos.Add(videojuego);
                Console.WriteLine("videojuego agregado con exito");
                GuardarDato(videojuego);
        }

        public static void EliminarVideojuego(string nombre)
        {
            var juego = VideoJuegos.Find(v => v.Nombre == nombre);

            if (juego == null)
            {
                Console.WriteLine("juego no encontrado");
            }
            VideoJuegos.Remove(juego);
            GuardarDatos();
            Console.WriteLine("juego eliminado con exito");

        }
        public static void ModificarVideojuego(string nuevonombre, plataformas nuevaplataforma, double nuevoprecio, int nuevostock)
        {
            var juego = VideoJuegos.Find(v => v.Nombre == nuevonombre);

            if (juego == null)
            {
                Console.WriteLine("juego no encontrado");
            }

            VideoJuegos.Remove(juego);
            videojuego jueguito = new videojuego(nuevonombre, nuevaplataforma, nuevoprecio, nuevostock);
            VideoJuegos.Add(jueguito);
            GuardarDatos();
            Console.WriteLine("juego agregado con exito");


        }

        public static void MostrarCatalogo()
        {
            if (VideoJuegos.Count == 0) { Console.WriteLine("catalogo vacio"); }
            else { 
              Console.WriteLine("catalogo de videojuegos: ");
                foreach (var juego in VideoJuegos)
                {
                    Console.WriteLine(juego);
                }
            }
        }

        public static void CargarDatos()
        {
            try 
            {
                
                if(File.Exists(ListaVideojuegos))
                {
                    var linea = File.ReadAllLines(ListaVideojuegos);

                    foreach (var line in linea)
                    {
                        var datos = line.Split(", ");
                        string nombre = datos[0];

                        plataformas plataforma = (plataformas)Enum.Parse(typeof(plataformas), datos[1]);
                        double precio = double.Parse(datos[2]);
                        int stock = int.Parse(datos[3]);

                        videojuego juego = new(nombre, plataforma, precio, stock);

                        VideoJuegos.Add(juego);
                    }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void GuardarDato(videojuego juego)
        {
            using StreamWriter writer = new StreamWriter(ListaVideojuegos, true);
            writer.WriteLine(juego);
        }

        public static void GuardarDatos()
        {
            //using StreamWriter writer = new StreamWriter(ArchivoCatalogo);
            //foreach (var juego in catalogo)
            //{
            //    writer.WriteLine(juego);
            //}

            List<string> lineas = ListaVideojuegos.Select(x => x.ToString()).ToList();
            File.WriteAllLines(ListaVideojuegos, lineas);

        }

    }
}
