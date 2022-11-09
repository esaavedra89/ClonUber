using ClonUber.Vistas.MenuPrincipal;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClonUber.VistaModelo
{
    public class VMDigitaCodigo : BaseViewModel
    {
        #region VARIABLES

        string _txtCodigo;
        string _mensajeRecibido;

        #endregion

        #region CONSTRUCTOR

        public VMDigitaCodigo(INavigation navigation, string code)
        {
            Navigation = navigation;
            _mensajeRecibido = code;
        }

        #endregion

        #region OBJETOS

        public string TxtCodigo
        {
            get { return _txtCodigo; }
            set { SetValue(ref _txtCodigo, value); }
        }

        #endregion

        #region PROCESOS

        public async void ValidarCodigo()
        {
            if (TxtCodigo == _mensajeRecibido)
            {
                CrearArchivo();
                await Navigation.PushAsync(new VMenuPrincipal());
            }
            else
            {
                await DisplayAlert("Alerta", "Codigo incorrecto", "Ok");
            }
        }
        public void CrearArchivo()
        {
            // We access to personal folder to get the file with the code.
            var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "auth.txt");
            StreamWriter sw;
            string estado = "1";
            try
            {
                if (File.Exists(ruta) == false)
                {
                    sw = File.CreateText(ruta);
                    sw.WriteLine(estado);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    File.Delete(ruta);
                    sw = File.CreateText(ruta);
                    sw.WriteLine(estado);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region COMANDOS

        public ICommand ValidarCommand => new Command(ValidarCodigo);

        #endregion
    }
}
