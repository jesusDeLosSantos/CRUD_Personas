using CRUD_Personas_DAL.Gestoras;
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
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.Views;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento asociado al click que navega al frame PersonasView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PersonasTapped(object sender, TappedRoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(PersonasView));
        }

        /// <summary>
        /// Evento asociado al click que navega al frame DepartamentosView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartamentosTapped(object sender, TappedRoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(DepartamentosView));
        }

        /// <summary>
        /// Evento asociado al click que navega hacia detras en los frame del contenedor. En caso de que salga del contenedor, irá al frame anterior de la app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void nvSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            try 
            { 
                contentFrame.GoBack(); 
            }
            catch (Exception ex)
            {
                App.TryGoBack();
            }
        }
    }
}
