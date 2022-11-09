using ClonUber.Vistas.Registro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClonUber.VistaModelo
{
    public class VMEmpezar:BaseViewModel
    {
        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMEmpezar(INavigation navigation)
        {
            Navigation = navigation;
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
        async void IrCrearCuenta()
        {
            await Navigation.PushAsync(new Crearcuenta());
        }
        #endregion
        #region COMANDOS
        public ICommand IrCrearCuentaCommand => new Command(IrCrearCuenta);
        #endregion
    }
}
