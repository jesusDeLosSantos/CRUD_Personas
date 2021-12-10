using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CRUD_Personas_UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DepartamentosView : Page
    {
        public DepartamentosView()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al click que navega al frame CrearDepartamento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCreate(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CrearDepartamento));
        }

        /// <summary>
        /// Evento asociado al click que navega al frame EditarDepartamento.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickEdit(object sender, RoutedEventArgs e)
        {
            if (lsvPersonas.SelectedItem != null)
            {
                this.Frame.Navigate(typeof(EditarDepartamento), lsvPersonas.SelectedItem);
            }
        }
    }
}
