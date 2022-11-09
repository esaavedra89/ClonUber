using ClonUber.Modelo;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace ClonUber.Vistas.Reutilizables
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPaises : PopupPage
    {
        public ListaPaises()
        {
            var parametros = new GoogleUser();
            InitializeComponent();
        }
    }
}