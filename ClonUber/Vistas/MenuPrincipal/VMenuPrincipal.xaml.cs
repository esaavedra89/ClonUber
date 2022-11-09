using ClonUber.VistaModelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClonUber.Vistas.MenuPrincipal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VMenuPrincipal : ContentPage
    {
        public VMenuPrincipal()
        {
            InitializeComponent();
            BindingContext = new VMMenuPrincipal(Navigation);
        }
    }
}