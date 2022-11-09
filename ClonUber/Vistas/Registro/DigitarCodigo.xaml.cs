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
    public partial class DigitarCodigo : ContentPage
    {
        public DigitarCodigo(string codigo)
        {
            InitializeComponent();
            BindingContext = new VMDigitaCodigo(Navigation, codigo);
        }
    }
}