using BL;
using CRUD_Personas_BL.Gestoras;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.ViewModels.utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CRUD_Personas_UWP.ViewModels
{
    public class PersonaListaDepartamentosVM : clsVMBase
    {

        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsPersona cliente;
        private DelegateCommand commandGuardar;
        #endregion
        #region construccion

        public PersonaListaDepartamentosVM()
        {
            ListaDepartamentos = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().Departamentos);
            Cliente = new clsPersona();
        }

        #endregion
        #region propiedades publicas
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsPersona Cliente {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                NotifyPropertyChanged("Persona");
                if (commandGuardar != null)
                    commandGuardar.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand CommandGuardar {
            get
            {
                commandGuardar = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
                NotifyPropertyChanged("CommandGuardar");
                return commandGuardar;
            }
        }
        #endregion
        #region Commands
        private async void GuardarCommand_Execute()
        {
            try
            {
                if (Cliente.Id == 0)
                    GestoraAccionesPersonasBL.addPersonaBL(Cliente);
                else
                    GestoraAccionesPersonasBL.alterPersonaBL(Cliente);

                ContentDialog mensajeConfirmacion = new ContentDialog()
                {
                    Title = "PERSONA GUARDADA",
                    Content = "La persona se ha guardado",
                    CloseButtonText = "Confirmar"
                };

                ContentDialogResult respuesta = await mensajeConfirmacion.ShowAsync();
            }
            catch
            {
                ContentDialog mensajeExito = new ContentDialog()
                {
                    Title = "ERROR",
                    Content = "No se ha eliminado la persona correctamente",
                    SecondaryButtonText = "Volver"
                };

                ContentDialogResult resultado = await mensajeExito.ShowAsync();
            }

        }
        private bool GuardarCommand_CanExecute()
        {
            return true; //(!String.IsNullOrEmpty(Persona.Nombre) && !String.IsNullOrEmpty(Persona.Apellidos));
        }
        #endregion
    }
}
