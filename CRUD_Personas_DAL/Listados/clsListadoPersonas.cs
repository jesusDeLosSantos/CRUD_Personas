using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Entities;

namespace DAL
{
    public class clsListadoPersonas
    {
        public ObservableCollection <clsPersona> listado { get; }

        public clsListadoPersonas() {
            listado = new ObservableCollection<clsPersona>();
            listado.Add(new clsPersona("Pedro", "Pastor"));
            listado.Add(new clsPersona("Santi", "Martinez"));
            listado.Add(new clsPersona("Jesus", "de los Santos"));
            listado.Add(new clsPersona("Albert", "Machio"));
        }
    }
}
