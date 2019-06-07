using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using TSM4K.Models;
using Xamarin.Forms;

using XF4ListBug.Models;
using XF4ListBug.Views;

namespace XF4ListBug.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Paradero> ParaderosCercanos { get; set; } = new ObservableCollection<Paradero>();

        public bool SinPermisoUbicacion => false;

        private bool _refrescando;
        public bool Refrescando { get { return _refrescando; } set { SetProperty(ref _refrescando, value); } }

        private ICommand _refrescarCommand;
        public ICommand RefrescarCommand
        {
            get
            {
                return _refrescarCommand ?? (_refrescarCommand = new Command(async () =>
                {
                    try
                    {
                        Refrescando = true;
                        await Task.Delay(2);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine($"e: {e}");
                    }
                    finally
                    {
                        Refrescando = false;
                    }
                }, () => !Refrescando));
            }
        }


        public ItemsViewModel()
        {
            Title = "Browse";

            int i = 0;
            var rnd = new Random();
            while(i < 50)
            {
                var cod = "PC" + rnd.Next(0, 999);
                var par = new Paradero()
                {
                    Codigo = cod,
                    stop_code = cod,
                    Texto = "lorem ipsum trololo",
                    gtfs_id = 1,
                    loc = new LatLng(0, 0)
                };
                for(int j = 0; j < 7; j++)
                {
                    par.Servicios.Add(new Recorrido()
                    {
                        Codigo = rnd.Next(0,999).ToString(),
                        Ida = "Providencia",
                        Regreso = "Las Condes",
                        Sentido = rnd.Next(1) == 0 ? Sentido.Ida : Sentido.Regreso
                    });
                }
                ParaderosCercanos.Add(par);
                i++;
            }
        }

    }
}