using ClonUber.Modelo;
using ClonUber.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClonUber.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CompletarReg : ContentPage
    {
        public CompletarReg(GoogleUser parametros)
        {
            InitializeComponent();
            BindingContext = new VMCompletarReg(Navigation, parametros);
        }
    }
}