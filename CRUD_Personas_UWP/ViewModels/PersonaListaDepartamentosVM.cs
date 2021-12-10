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
        private clsPersona persona;
        private DelegateCommand commandGuardar;
        #endregion

        #region constructores
        public PersonaListaDepartamentosVM()
        {
            ListaDepartamentos = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().Departamentos);
            Persona = new clsPersona();
        }
        #endregion

        #region getters y setters
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsPersona Persona {
            get
            {
                return persona;
            }
            set
            {
                persona = value;
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

        #region metodos
        /// <summary>
        /// Cabecera: private async void GuardarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando guardar. Dependiendo de si el id es por defecto (0) o no, se guardan creando uno nuevo o editándose uno antiguo.
        /// Postcondicion: se crea una nueva persona si el id es 0, o se edita según su id.
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            try
            {
                if (Persona.Id == 0)
                    GestoraAccionesPersonasBL.addPersonaBL(Persona);
                else
                    GestoraAccionesPersonasBL.alterPersonaBL(Persona);

                ContentDialog guardar = new ContentDialog()
                {
                    Content = "Se han guardado los cambios.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult respuesta = await guardar.ShowAsync();
            }
            catch
            {
                ContentDialog error = new ContentDialog()
                {
                    Content = "Ha ocurrido un error.",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult resultado = await error.ShowAsync();
            }

        }
        private bool GuardarCommand_CanExecute()
        {
            return true; //(!String.IsNullOrEmpty(persona.Nombre) && !String.IsNullOrEmpty(persona.Apellidos));         Esto se supone que es para que no se pueda guardar si no se han rellenado el nombre y apellidos, pero no funcionaba bien, así que lo comento.
        }
        #endregion
    }
}
