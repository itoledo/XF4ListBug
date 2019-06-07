using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XF4ListBug.ViewModels;

namespace TSM4K.Models
{
    public class LatLng : BaseViewModel
    {
        private double _lat; public double lat { get { return _lat; } set { if (value != _lat) { _lat = value; OnPropertyChanged("lat"); } } }
        private double _lng; public double lng { get { return _lng; } set { if (value != _lng) { _lng = value; OnPropertyChanged("lng"); } } }

        public LatLng(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        public bool IsNull()
        {
            return (_lat == 0 && _lng == 0);
        }

        public override string ToString()
        {
            return _lat.ToString() + "," + _lng.ToString();
        }
    }
}
