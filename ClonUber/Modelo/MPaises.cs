using ClonUber.VistaModelo;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClonUber.Modelo
{
    public class MPaises:BaseViewModel
    {
        string _iconUrl;
        string _pais;
        string _codigoPais;

        public string IconUrl 
        { 
            get { return _iconUrl; }
            set { SetValue(ref _iconUrl, value); }
        }

        public string Pais
        {
            get { return _pais; }
            set { SetValue(ref _pais, value); }
        }

        public string CodigoPais
        {
            get { return _codigoPais; }
            set { SetValue(ref _codigoPais, value); }
        }
    }
}
