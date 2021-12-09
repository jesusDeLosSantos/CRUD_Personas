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
    public class PersonasViewVM : clsVMBase
    {

        private ObservableCollection<clsPersona> listaClientes;
        public ObservableCollection<clsPersona> ListaClientesFiltrada { get; set; }
        private PersonaNombreDepartamento cliente;
        private string textoBox;
        private DelegateCommand commandFiltrar;
        private DelegateCommand commandEliminar;



        public string Cadena { get; set; }
        public PersonaNombreDepartamento Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
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
                    ListaClientesFiltrada = listaClientes;
                    NotifyPropertyChanged("listaClientesFiltrada");
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
                commandEliminar = new DelegateCommand(EliminarCommand_ExecuteAsync, EliminarCommand_CanExecute);
                NotifyPropertyChanged("CommandEliminar");
                return commandEliminar;
            }

        }

        private bool FiltrarCommand_CanExecute()
        {
            return !String.IsNullOrEmpty(TextoBox);
        }

        private void FiltrarCommand_Execute()
        {
            ListaClientesFiltrada = new ObservableCollection<clsPersona>(from p in listaClientes
                                                                where p.Nombre.ToLower().Contains(TextoBox.ToLower()) || p.Apellidos.ToLower().Contains(TextoBox.ToLower())
                                                                select p);
            NotifyPropertyChanged("listaClientesFiltrada");
        }


        private async void EliminarCommand_ExecuteAsync()
        {
            ContentDialog confirmar = new ContentDialog()
            {
                Content = "¿Quieres eliminar esta persona permanentemente?",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };
            ContentDialogResult respuesta = await confirmar.ShowAsync();

            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraAccionesPersonasBL.deletePersonaBL(cliente.Persona.Id);
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
        }

        private bool EliminarCommand_CanExecute()
        {
            bool valid = false;
            if (cliente != null)
            {
                valid = true;
            }

            return valid;
        }

        public PersonasViewVM()
        {
            listaClientes = new clsListadoPersonasBL().Personas;
            ListaClientesFiltrada = listaClientes;

        }
    }
}
