﻿using BL;
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

        private ObservableCollection<PersonaNombreDepartamento> listaClientes;
        public ObservableCollection<PersonaNombreDepartamento> ListaClientesFiltrada { get; set; }
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
                NotifyPropertyChanged("Cliente");
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
                    NotifyPropertyChanged("ListaClientesFiltrada");
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
        private bool FiltrarCommand_CanExecute()
        {
            return !String.IsNullOrEmpty(TextoBox);
        }
        private void FiltrarCommand_Execute()
        {

            ListaClientesFiltrada = new ObservableCollection<PersonaNombreDepartamento>(from p in listaClientes
                                                                                        where p.Persona.Nombre.ToLower().Contains(TextoBox.ToLower()) || p.Persona.Apellidos.ToLower().Contains(TextoBox.ToLower())
                                                                                        select p);
            NotifyPropertyChanged("ListaClientesFiltrada");
        }



        public PersonaNombreDepartamentoVM()
        {
            RellenarLista();
            ListaClientesFiltrada = listaClientes;
        }



        private async void EliminarCommand_Execute()
        {
            ContentDialog confirmar = new ContentDialog()
            {
                Content = "¿Quieres eliminar " + cliente.Persona.Nombre + "?",
                SecondaryButtonText = "Sí",
                CloseButtonText = "No"
            };
            ContentDialogResult respuesta = await confirmar.ShowAsync();

            if (respuesta.HasFlag(ContentDialogResult.Secondary))
            {
                try
                {
                    GestoraAccionesPersonasBL.deletePersonaBL(cliente.Persona.Id);
                    listaClientes.Remove(cliente);
                    ListaClientesFiltrada = listaClientes;
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
            NotifyPropertyChanged("ListaClientesFiltrada");
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



        private async void RellenarLista()
        {
            try
            {
                listaClientes = new ObservableCollection<PersonaNombreDepartamento>();
                foreach (clsPersona p in new clsListadoPersonasBL().Personas)
                {
                    listaClientes.Add(new PersonaNombreDepartamento(p));
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
    }        
}

