using ClonUber.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClonUber.Vistas.Registro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Crearcuenta : ContentPage
    {
        public Crearcuenta()
        {
            InitializeComponent();
            BindingContext = new VMCrearCuenta(Navigation);
        }
    }
}