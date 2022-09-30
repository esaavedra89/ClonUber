using ClonUber.Vistas.MenuPrincipal;
using ClonUber.Vistas.Registro;
using Xamarin.Forms;

namespace ClonUber
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new Empezar());
            MainPage = new VMenuPrincipal();
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
