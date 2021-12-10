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
    public class DepartamentosVM : clsVMBase
    {
        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        public ObservableCollection<clsDepartamento> ListaDepartamentosFiltrada { get; set; }
        private clsDepartamento departamento;
        private string textoBox;
        private DelegateCommand commandFiltrar;
        private DelegateCommand commandEliminar;
        private DelegateCommand commandGuardar;
        public string Cadena { get; set; }
        #endregion

        #region getters y setters
        public clsDepartamento Departamento
        {
            get
            {
                return departamento;
            }
            set
            {
                departamento = value;
                NotifyPropertyChanged("Departamento");
                if (commandEliminar != null)
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
                    ListaDepartamentosFiltrada = listaDepartamentos;
                    NotifyPropertyChanged("ListaDepartamentosFiltrada");
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
        public DelegateCommand CommandGuardar
        {
            get
            {
                commandGuardar = new DelegateCommand(GuardarCommand_Execute, GuardarCommand_CanExecute);
                NotifyPropertyChanged("CommandGuardar");
                return commandGuardar;
            }
        }
        #endregion

        #region constructores
        public DepartamentosVM()
        {
            RellenarLista();
            ListaDepartamentosFiltrada = listaDepartamentos;
            Departamento= new clsDepartamento();
        }
        #endregion

        #region metodos
        private bool FiltrarCommand_CanExecute()
        {
            return !String.IsNullOrEmpty(TextoBox);
        }

        /// <summary>
        /// Cabecera: private void FiltrarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando filtrar. Asigna a la lista de los departamentos filtrados aquellos departamentos de la lista que contenga en el nombre el contenido del textbox.
        /// Precondicion: listaDepartamento no sea null.
        /// Postcondicion: listaDepartamentosFiltrada contendra los departamentos con dichas condiciones.
        /// </summary>
        private void FiltrarCommand_Execute()
        {
            ListaDepartamentosFiltrada = new ObservableCollection<clsDepartamento>(from d in listaDepartamentos
                                                                                        where d.Nombre.ToLower().Contains(TextoBox.ToLower()) select d);
            NotifyPropertyChanged("ListaDepartamentosFiltrada");
        }

        /// <summary>
        /// Cabecera: private async void EliminarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando eliminar. Pregunta si quieres eliminar a dicho departamento. Si seleccionas sí, lo elimina.
        /// Precondicion: departamento no sea null.
        /// Postcondicion: si se acepta, el departamento se borra.
        /// </summary>
        private async void EliminarCommand_Execute()
        {
            ContentDialog confirmar = new ContentDialog()
            {
                Content = "¿Quieres eliminar "+Departamento.Nombre+"?",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };
            ContentDialogResult respuesta = await confirmar.ShowAsync();

            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraAccionesDepartamentosBL.deleteDepartamentosBL(departamento.Id);
                    listaDepartamentos.Remove(departamento);
                    ListaDepartamentosFiltrada = listaDepartamentos;
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
            if (departamento != null && departamento.Id!=0)     //Esto evita que se puedan eliminar departamentos nulos o por defecto (con id=0)
            {
                valid = true;
            }

            return valid;
        }

        /// <summary>
        /// Cabecera: private async void GuardarCommand_Execute()
        /// Descripcion: Este método es la ejecucion del comando guardar. Dependiendo de si el id es por defecto (0) o no, se guardan creando uno nuevo o editándose uno antiguo.
        /// Postcondicion: se crea un nuevo departamento si el id es 0, o se edita según su id.
        /// </summary>
        private async void GuardarCommand_Execute()
        {
            try
            {
                if (Departamento.Id == 0)       
                    GestoraAccionesDepartamentosBL.addDepartamentosBL(Departamento);
                else
                    GestoraAccionesDepartamentosBL.alterDepartamentosBL(Departamento);

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
            return true; 
        }

        /// <summary>
        /// Cabecera: private async void RellenarLista()
        /// Descripcion: Este método rellena la lista de departamentos extrayéndolas de la bbdd.
        /// Precondicion: no deben haber problemas con la conexión de la bbdd.
        /// Postcondicion: se rellena la lista del departamento.
        /// </summary>
        private async void RellenarLista()
        {
            listaDepartamentos = new ObservableCollection<clsDepartamento>();
            try
            {
                foreach (clsDepartamento d in new clsListadoDepartamentosBL().Departamentos)
                {
                    listaDepartamentos.Add(d);
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

