using ClonUber.Vistas.Registro;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClonUber.VistaModelo
{
    public class VMMenuPrincipal : BaseViewModel
    {
        #region VARIABLES

        string _Texto;
        int estado = 0;

        #endregion

        #region CONSTRUCTOR

        public VMMenuPrincipal(INavigation navigation)
        {
            Navigation = navigation;
            ValidarAuth();
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

        
        public int Autenticacion()
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath
                    (Environment.SpecialFolder.Personal), "auth.txt");
                estado = Convert.ToInt32(File.ReadAllText(ruta));
                return estado;
            }
            catch (System.Exception)
            {
                return estado;
            }
        }

        public void ValidarAuth()
        {
            Autenticacion();
            if (estado == 0)
            {
                Application.Current.MainPage = new NavigationPage(new Empezar());
            }
        }

        #endregion

        #region COMANDOS

        public ICommand ValidarCommand => new Command(ValidarAuth);

        #endregion
    }
}
