using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TSM4K.Interfaces;
using TSM4K.Models;
using Xamarin.Forms;

namespace TSM4K.Converters
{
    public class SeleccionableImagenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (Paradero)value;
            string img = null;
            //string prefix = "imagenes/gtfs/";
            //if (parameter != null)
            //    prefix += "simplewhite/";
            switch (s.Tipo)
            {
                case Interfaces.TipoSeleccionable.Paradero:
                    var p = s as Paradero;
                    if (p != null && p.EsParadaMetro()) //&& p.gtfs_id == 1)
                        img = "metro.png";
                    else
                        img = "stop.png";
                    break;
                case Interfaces.TipoSeleccionable.PuntoBip:
                    img = "smallbip.png";
                    break;
                case Interfaces.TipoSeleccionable.EstacionMetro:
                    img = "metro.png";
                    break;
                    //                case TipoSeleccionable.Reclamo: return App.Current.Resources["ARSocialTemplate"];
                    //case TipoSeleccionable.LugarMapa: return App.Current.Resources["ARLugarTemplate"];
                    //case TipoSeleccionable.ResultadoBusqueda: return App.Current.Resources["ARResultadoBusquedaTemplate"];
                    //case TipoSeleccionable.MarcadoMapa: return App.Current.Resources["ARLugarTemplate"];
            }

            if (img != null)
            {
//                return new Uri(prefix + img, UriKind.RelativeOrAbsolute);
                return img;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
