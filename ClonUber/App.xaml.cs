using ClonUber.Vistas.MenuPrincipal;
using ClonUber.Vistas.Navegacion;
using ClonUber.Vistas.Registro;
using ClonUber.Vistas.Reutilizables;
using Xamarin.Forms;

namespace ClonUber
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ADondeVamos());
            //ainPage = new NavigationPage(new ListaPaises());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
