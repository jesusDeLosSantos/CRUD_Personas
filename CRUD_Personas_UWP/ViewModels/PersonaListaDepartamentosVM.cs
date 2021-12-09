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
    public class PersonaListaDepartamentosVM
    {

        #region atributos
        private ObservableCollection<clsDepartamento> listaDepartamentos;
        private clsPersona persona;
        private DelegateCommand guardarFoto;
        #endregion
        #region construccion

        public PersonaListaDepartamentosVM()
        {
            guardarFoto = new DelegateCommand(Guardar, SePuedeGuardar);
            ListaDepartamentos = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().Departamentos);
            Persona = new clsPersona();
        }

        #endregion
        #region propiedades publicas
        public ObservableCollection<clsDepartamento> ListaDepartamentos { get => listaDepartamentos; set => listaDepartamentos = value; }
        public clsPersona Persona { get => persona; set => persona = value; }
        #endregion
        #region Commands
        private async void Guardar()
        {
            try
            {
                if (Persona.Id == 0)
                    GestoraAccionesPersonasBL.addPersonaBL(Persona);
                else
                    GestoraAccionesPersonasBL.alterPersonaBL(Persona);

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
        private bool SePuedeGuardar()
        {
            return (!String.IsNullOrEmpty(Persona.Nombre) && !String.IsNullOrEmpty(Persona.Apellidos));
        }
        #endregion
    }
}
