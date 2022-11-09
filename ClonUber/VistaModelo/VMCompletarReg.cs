using ClonUber.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using ClonUber.Vistas.Registro;
using ClonUber.Datos;
using Rg.Plugins.Popup.Services;
using ClonUber.Vistas.Reutilizables;
using Rg.Plugins.Popup.Pages;

namespace ClonUber.VistaModelo
{
    public class VMCompletarReg : BaseViewModel
    {
        #region VARIABLES

        string _Texto;
        public GoogleUser _googleUserRecibe { get; set; }
        string _txtNumero;
        List<MPaises> _listaPaises;
        MPaises _selectedPais;
        MPaises _selectPaisDefault;

        #endregion

        #region OBJETOS

        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public string TxtNumero
        {
            get { return _txtNumero; }
            set { SetValue(ref _txtNumero, value); }
        }

        public List<MPaises> ListaPaises
        {
            get { return _listaPaises; }
            set { SetValue(ref _listaPaises, value); }
        }
        public MPaises SelectPaisDefault
        {
            get { return _selectPaisDefault; }
            set { SetValue(ref _selectPaisDefault, value); }
        }
        public MPaises SelectedPais
        {
            get { return _selectedPais; }
            set { SetValue(ref _selectedPais, value); }
        }

        #endregion

        #region CONSTRUCTOR

        public VMCompletarReg(INavigation navigation, GoogleUser _googleUserTrae)
        {
            Navigation = navigation;
            _googleUserRecibe = _googleUserTrae;
            ObtenerDataPaisXPais();
        }

        #endregion
        

        #region PROCESOS

        public async void EnviarSms()
        {
            try
            {
                // Find your Account SID and Auth Token at twilio.com/console
                // and set the environment variables. See http://twil.io/secure
                //string accountSid = Environment.GetEnvironmentVariable("AC4d0c5c57cb59375223a2e31d19bbc35b");
                //string authToken = Environment.GetEnvironmentVariable("e50beaccf6988204d760a89e2e88b94a");

                //TwilioClient.Init(accountSid, authToken);

                //var message = MessageResource.Create(
                //    body: "This is the ship that made the Kessel Run in fourteen parsecs?",
                //    from: new Twilio.Types.PhoneNumber("+18504079929"),
                //    to: new Twilio.Types.PhoneNumber("+584121897161")
                //);

                #region Codigo Aleatorio
                
                // Random code. 
                Random geneador = new Random();
                string randomSms = geneador.Next(0,9999).ToString();

                #endregion

                var accountSid = "AC4d0c5c57cb59375223a2e31d19bbc35b";
                var authToken = "e50beaccf6988204d760a89e2e88b94a";
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(SelectPaisDefault.CodigoPais + TxtNumero));
                messageOptions.MessagingServiceSid = "MGf3185b9a2c007a1e41eecaa58b8488aa";
                messageOptions.Body = "Usa este código " + randomSms + @" para validar tu cuenta en Uber";

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);

                Console.WriteLine(message.Sid);

                await Navigation.PushAsync(new DigitarCodigo(randomSms));
            }
            catch (Exception exc)
            {
                await Application.Current.MainPage.DisplayAlert("Error", exc.Message, "OK");
            }
        }

        public void MostrarPaises()
        {
            var funcion = new DPaises();
            ListaPaises = funcion.MostrarPaises();
        }

        void ObtenerDataPaisXPais()
        {
            var funcion = new DPaises();
            SelectPaisDefault = funcion.MostrarPaisesXNombre("Venezuela");
            SelectedPais = funcion.MostrarPaisesXNombre("Venezuela");
        }

        void IrListaPaises()
        {
            // Is instantiated and assigned BindingContext.
            var popup = new ListaPaises();
            popup.BindingContext = this;
            MostrarPaises();
            PopupNavigation.Instance.PushAsync(popup);
        }

        void SelectCountry(MPaises parametros)
        {
            SelectedPais = parametros;
        }

        void ConfirmCountry()
        {
            SelectPaisDefault = SelectedPais;
            Cancel();
        }

        void Cancel()
        {
            PopupNavigation.Instance.PopAsync();
        }

        void SearchCountry(string searcher)
        {
            searcher = ConvertFirstLetterToUppercase(searcher);
            var funcion = new DPaises();

            var list = funcion.ListShowCountriesByName(searcher);
            if (string.IsNullOrWhiteSpace(searcher))
            {
                ListaPaises = new List<MPaises>();
                MostrarPaises();
            }
            else
            {
                if (list.Count > 0)
                {
                    ListaPaises = new List<MPaises>();
                    ListaPaises = list;
                }
            }
        }

        #endregion

        #region COMANDOS

        public ICommand SearchCommand => new Command<string>(SearchCountry);
        public ICommand CancelCommand => new Command(Cancel);
        public ICommand ConfirmCountryCommand => new Command(ConfirmCountry);
        public ICommand SiguienteCommand => new Command(() => EnviarSms());
        public ICommand IrPaisesCommand => new Command(() => IrListaPaises());
        public ICommand SelectCountryCommand => new Command<MPaises>(SelectCountry);

        #endregion
    }
}
