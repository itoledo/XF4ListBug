using System.ComponentModel;
using TSM4K.Models;

namespace TSM4K.Interfaces
{
    public enum TipoSeleccionable
    {
        Paradero,
        PuntoBip,
        EstacionMetro,
        ResultadoBusqueda,
        LugarMapa,
        MarcadoMapa,
        Reclamo,
        Recorrido
    }

    public interface ISeleccionable : INotifyPropertyChanged
    {
        string Id { get; }
        string Nombre { get; }
        string Descripcion { get; }
        //        string DistanciaFormat { get; }
        LatLng Location { get; }



        TipoSeleccionable Tipo { get; }

        string Icono { get; set; }

        bool Favoriteable { get; }

        /*        public static bool operator ==(Seleccionable s1, Seleccionable s2)
                {
                    return (s1.Id == s2.Id && s1.Tipo == s2.Tipo);
                } */
    }
}