using Parcial.enums;

namespace Parcial.models
{
    public class videojuego
    {
        private string _nombre;

        private plataformas _plataforma;

        private double _precio;

        private int    _stock;
        public string Nombre => _nombre;
        public plataformas Plataforma => _plataforma;
        public double Precio => _precio;
        public int Stock => _stock;

        public videojuego(string nombre, plataformas plataforma, double precio, int stock)
        {
            _nombre = nombre;
            _plataforma = plataforma;
            _precio = precio;
            _stock = stock;
        }

        public override string ToString() 
        {
            return $"{Nombre}, {Plataforma}, {Precio}, {Stock}";
        }
    }
}
