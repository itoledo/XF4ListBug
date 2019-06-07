using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using TSM4K.Interfaces;
using XF4ListBug.ViewModels;

namespace TSM4K.Models
{
    public enum Sentido
    {
        Ida,
        Regreso
    };

    public class Recorrido : BaseViewModel, ISeleccionable
    {
        private string _tiempo;
        public string Tiempo
        {
            get
            {
                return _tiempo;
            }
            set
            {
                if (value != _tiempo)
                {
                    _tiempo = value;
                    OnPropertyChanged("Tiempo");
                }
            }
        }

        private string _distancia;
        public string Distancia
        {
            get
            {
                return _distancia;
            }
            set
            {
                if (value != _distancia)
                {
                    _distancia = value;
                    OnPropertyChanged("Distancia");
                }
            }
        }

        private string _codigo;
        public string Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value != _codigo)
                {
                    _codigo = value;
                    OnPropertyChanged("Codigo");
                    OnPropertyChanged("CodigoSmall");
                }
            }
        }

        private string _ida; public string Ida { get { return _ida; } set { if (_ida != value) { _ida = value; OnPropertyChanged("Ida"); } } }
        private string _regreso; public string Regreso { get { return _regreso; } set { if (_regreso != value) { _regreso = value; OnPropertyChanged("Regreso"); } } }

        public Sentido Sentido;

        public override string ToString()
        {
            return "Recorrido " + Codigo;
        }

        // gtfs
        public int gtfs_id;
        public string service_id;

        public string trip_id;
        private string _trip_headsign; public string trip_headsign
        {
            get { return _trip_headsign; }
            set
            {
                _trip_headsign = value;
                OnPropertyChanged("trip_headsign");
            }
        }
        public string route_id;
        public string agency_id;
        public string route_type;
        // route_short_name está en "Código"
        private string _route_color; public string route_color
        {
            get { return _route_color; }
            set { _route_color = value; OnPropertyChanged("route_color"); }
        }
        private string _route_text_color;
        public string route_text_color
        {
            get { return _route_text_color; }
            set { _route_text_color = value; OnPropertyChanged("route_text_color"); }
        }
        private string _route_long_name; public string route_long_name { get { return _route_long_name; } set { _route_long_name = value; OnPropertyChanged("route_long_name"); OnPropertyChanged("CodigoSmall"); } }
        public bool frequency;
        public string arrival_time;
        public string departure_time;
        public int arrival_diff;
        public int dep_diff;

        public string CodigoSmall
        {
            get
            {
                if (!string.IsNullOrEmpty(_route_long_name))
                {
                    if (_route_long_name.StartsWith("Línea "))
                        return "L" + _route_long_name.Substring(6);
                    return _route_long_name;
                }
                return _codigo;
            }
        }

        // interfaz Seleccionable
        public string Id { get { return Codigo; } }
        public string Nombre { get { return Codigo; } }
        public string Descripcion { get { return string.IsNullOrEmpty(trip_headsign) ? (Ida + " - " + Regreso) : trip_headsign; } }
        public Interfaces.TipoSeleccionable Tipo { get { return Interfaces.TipoSeleccionable.Recorrido; } }
        public LatLng Location { get { return null; } }
        public bool Favoriteable { get { return false; } }
        private string _icono;
        public string Icono { get { return _icono; } set { SetProperty(ref _icono, value); } }

        private bool _tieneAlarma;
        public bool TieneAlarma { get { return _tieneAlarma; } set { SetProperty(ref _tieneAlarma, value); } }
    }
}
