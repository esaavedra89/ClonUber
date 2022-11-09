using ClonUber.Modelo;
using ClonUber.Vistas.Registro;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClonUber.VistaModelo
{
    public class VMCrearCuenta:BaseViewModel
    {
        #region VARIABLES
        
        string _Texto;
        readonly IGoogleManager _googleManager;
        GoogleUser _googleUserObtiene = new GoogleUser();

        #endregion

        #region CONSTRUCTOR

        public VMCrearCuenta(INavigation navigation)
        {
            // Navigation always is first.
            Navigation = navigation;
            _googleManager = DependencyService.Get<IGoogleManager>();
        }

        #endregion

        #region OBJETOS

        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }

        #endregion

        #region PROCESOS

       
        public void LoguearseConGmail()
        {
            _googleManager.LogIn(OnLoginComplete);
        }

        public async void OnLoginComplete(GoogleUser googleUserTrae, string message)
        {
            if (googleUserTrae != null)
            {
                // We get name and lastname of the user account.
                _googleUserObtiene = googleUserTrae;
                string[] cadena = _googleUserObtiene.Name.Split(' ');
                _googleUserObtiene.Name = cadena[0];
                _googleUserObtiene.Apellido = cadena[1];

                await Navigation.PushAsync(new CompletarReg(_googleUserObtiene));
            }
            else
            {
                await DisplayAlert("Message", message, "OK");
            }
        }

        #endregion

        #region COMANDOS

        public ICommand GmailCommand => new Command(LoguearseConGmail);


        #endregion
    }
}
