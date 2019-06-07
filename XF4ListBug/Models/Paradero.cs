using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TSM4K.Interfaces;
using XF4ListBug.ViewModels;

namespace TSM4K.Models
{
    public class Paradero : BaseViewModel, ISeleccionable
    {
        // esto es stop_id
        private string _codigo; public string Codigo { get { return _codigo; } set { if (_codigo != value) { _codigo = value; OnPropertyChanged("Codigo"); OnPropertyChanged("Nombre"); } } }
        // stop_name
        private string _texto; public string Texto { get { return _texto; } set { if (_texto != value) { _texto = value; OnPropertyChanged("Texto"); OnPropertyChanged("Descripcion"); OnPropertyChanged("TextoSinCodigo"); } } }

        //private string prueba;

        //public string ParaderoCorto
        //{
        //    get { return Texto.Split('/')[1]; }
        //}


        public LatLng loc;

        public ObservableCollection<Recorrido> Servicios { get; private set; }

        public Paradero()
        {
            Servicios = new ObservableCollection<Recorrido>();
        }

        // interfaz Seleccionable
        public string Id { get { return _codigo; } }
        public string Nombre { get { return _codigo; } }
        public string Descripcion { get { return _texto; } }
        public Interfaces.TipoSeleccionable Tipo { get { return Interfaces.TipoSeleccionable.Paradero; } }
        public LatLng Location { get { return loc; } }
        public bool Favoriteable { get { return true; } }

        public string TextoSinCodigo
        {
            get
            {
                if (_texto.StartsWith(_codigo))
                {
                    return _texto.Substring(_codigo.Length).TrimStart('-', ' ');
                }
                else
                {
                    return _texto;
                }
            }
        }

        public string Icono
        {
            get
            {
                if (Servicios.Count == 0 || string.IsNullOrEmpty(Servicios[0].route_type))
                {
                    return _icono;
                }
                /*                if (EsParadaMetro())
                   return GetIcono("1"); */
                return GetIcono(Servicios[0].route_type);
                //                return _icono;
            }
            set { SetProperty(ref _icono, value); }
        }

        public bool EsParadaMetro()
        {
            return Servicios.Any(c => c.route_type == "1");
        }

        private static string _icono;
        public static void SetIcono(string param) { _icono = param; }

        public static Dictionary<string, string> Iconos = new Dictionary<string, string>();

        public static void SetIcono(string key, string val)
        {
            Iconos[key] = val;
        }

        public static string GetIcono(string key)
        {
            string salida = string.Empty;
            return (Iconos.TryGetValue(key, out salida) ? salida : string.Empty);
        }

        public override string ToString()
        {
            return "Paradero " + Codigo;
        }

        // propiedades GTFS
        public int gtfs_id;
        public string service_id;
        private string _stop_code; public string stop_code
        {
            get { return _stop_code; }
            set { _stop_code = value; OnPropertyChanged("stop_code"); }
        }
        private string _stop_desc;
        public string stop_desc
        {
            get { return _stop_desc; }
            set { _stop_desc = value; OnPropertyChanged("stop_desc"); }
        }


        private bool _realtime; public bool realtime { get { return _realtime; } set { _realtime = value; OnPropertyChanged("realtime"); } }

        public override bool Equals(object obj)
        {
            var p = obj as Paradero;
            if (p == null)
            {
                return false;
            }

            return (gtfs_id == p.gtfs_id && _codigo.Equals(p._codigo));
        }

        public string DestinosServicios
        {
            get
            {
                return string.Join(" - ", Servicios.Select(s => s.trip_headsign).Distinct().OrderBy(s => s));
            }
        }
    }
}
