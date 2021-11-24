using CRUD_Personas_DAL.Gestoras;
using CRUD_Personas_Entities;
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
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GestoraAccionesPersonasDAL.alterPersonaDAL(new clsPersona(4, "Bug", "Fernandez"));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GestoraAccionesPersonasDAL.addPersonaDAL(new clsPersona("Buck", "Fernandez"));
        }
    }
}
