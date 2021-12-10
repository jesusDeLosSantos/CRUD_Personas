using BL;
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.ViewModels.utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Personas_UWP.Models;
using CRUD_Personas_BL.Gestoras;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonaNombreDepartamentoVM : clsVMBase
    {
        #region atributos
        private ObservableCollection<PersonaNombreDepartamento> listaPersonas;
        public ObservableCollection<PersonaNombreDepartamento> ListaPersonasFiltrada { get; set; }
        private PersonaNombreDepartamento persona;
        private string textoBox;
        private DelegateCommand commandFiltrar;
        private DelegateCommand commandEliminar;
        public string Cadena { get; set; }
        #endregion

        #region getters y setters
        public PersonaNombreDepartamento Persona
        {
            get
            {
                return persona;
            }
            set
            {
                persona = value;
                NotifyPropertyChanged("Persona");
                commandEliminar.RaiseCanExecuteChanged();
            }
        }
        public string TextoBox
        {
            get { return textoBox; }
            set
            {
                textoBox = value;
                commandFiltrar.RaiseCanExecuteChanged();
                if (String.IsNullOrEmpty(TextoBox))
                {
                    ListaPersonasFiltrada = listaPersonas;
                    NotifyPropertyChanged("ListaPersonasFiltrada");
                }
            }
        }
        public DelegateCommand CommandFiltrar
        {
            get
            {
                commandFiltrar = new DelegateCommand(FiltrarCommand_Execute, FiltrarCommand_CanExecute);
                return commandFiltrar;
            }

        }
        public DelegateCommand CommandEliminar
        {
            get
            {
                commandEliminar = new DelegateCommand(EliminarCommand_Execute, EliminarCommand_CanExecute);
                NotifyPropertyChanged("CommandEliminar");
                return commandEliminar;
            }

        }
        #endregion

        #region constructores
        public PersonaNombreDepartamentoVM()
        {
            RellenarLista();
            ListaPersonasFiltrada = listaPersonas;
        }
        #endregion

        #region metodos
        /// <summary>
        /// Cabecera: private async void EliminarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando eliminar. Pregunta si quieres eliminar a dicho departamento. Si seleccionas sí, lo elimina.
        /// Precondicion: persona no sea null.
        /// Postcondicion: si se acepta, la persona se borra.
        /// </summary>
        private async void EliminarCommand_Execute()
        {
            ContentDialog confirmar = new ContentDialog()
            {
                Content = "¿Quieres eliminar " + persona.Persona.Nombre + "?",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };
            ContentDialogResult respuesta = await confirmar.ShowAsync();

            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraAccionesPersonasBL.deletePersonaBL(persona.Persona.Id);
                    listaPersonas.Remove(persona);
                    ListaPersonasFiltrada = listaPersonas;
                }
                catch
                {
                    ContentDialog error = new ContentDialog()
                    {
                        Content = "Ha ocurrido un error.",
                        SecondaryButtonText = "Ok"
                    };
                }
            }
            NotifyPropertyChanged("ListaPersonasFiltrada");
        }

        private bool EliminarCommand_CanExecute()
        {
            bool valid = false;
            if (persona != null)        //Evita que el comando se pueda ejecutar si la persona es nula.
            {
                valid = true;
            }

            return valid;
        }

        private bool FiltrarCommand_CanExecute()
        {
            return !String.IsNullOrEmpty(TextoBox);
        }

        /// <summary>
        /// Cabecera: private void FiltrarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando filtrar. Asigna a la lista de las personas filtradas aquellas personas de la lista que contengan en el nombre o en el apellido, el contenido del textbox.
        /// Precondicion: listaDepartamento no sea null.
        /// Postcondicion: listaDepartamentosFiltrada contendra las personas con dichas condiciones.
        /// </summary>
        private void FiltrarCommand_Execute()
        {

            ListaPersonasFiltrada = new ObservableCollection<PersonaNombreDepartamento>(from p in listaPersonas
                                                                                        where p.Persona.Nombre.ToLower().Contains(TextoBox.ToLower()) || p.Persona.Apellidos.ToLower().Contains(TextoBox.ToLower())
                                                                                        select p);
            NotifyPropertyChanged("ListaPersonasFiltrada");
        }


        /// <summary>
        /// Cabecera: private async void RellenarLista()
        /// Descripcion: Este método rellena la lista de personas extrayéndolas de la bbdd.
        /// Precondicion: no deben haber problemas con la conexión de la bbdd.
        /// Postcondicion: se rellena la lista de las personas.
        /// </summary>
        private async void RellenarLista()
        {
            try
            {
                listaPersonas = new ObservableCollection<PersonaNombreDepartamento>();
                foreach (clsPersona p in new clsListadoPersonasBL().Personas)
                {
                    listaPersonas.Add(new PersonaNombreDepartamento(p));
                }
            }
            catch
            {
                ContentDialog error = new ContentDialog()
                {
                    Content = "Deja de tocar el server Fernando.",
                    SecondaryButtonText = "Ok"
                };
                ContentDialogResult resultado = await error.ShowAsync();
            }
        }
        #endregion
    }
}

