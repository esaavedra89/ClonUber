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
    public partial class Empezar : ContentPage
    {
        public Empezar()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Crearcuenta());
        }
    }
}