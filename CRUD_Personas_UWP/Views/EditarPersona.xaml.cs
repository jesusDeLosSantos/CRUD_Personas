using CRUD_Personas_Entities;
using CRUD_Personas_UWP.Models;
using CRUD_Personas_UWP.ViewModels;
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
    public sealed partial class EditarPersona : Page
    {
        public EditarPersona()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Evento que recibe cualquier parametro y es casteado a persona, para que si esta no es nula, enviarla al vm de la vista.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PersonaNombreDepartamento persona = (PersonaNombreDepartamento) e.Parameter;
            if (persona != null)
            {
                PersonaListaDepartamentosVM vm = (PersonaListaDepartamentosVM)this.DataContext;
                vm.Persona = persona.Persona;
            }
        }
    }
}
