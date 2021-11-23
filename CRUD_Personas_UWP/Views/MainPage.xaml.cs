﻿using CRUD_Personas_DAL.Gestoras;
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
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.Views;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace CRUD_Personas_UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {

            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //GestoraAccionesDepartamentosDAL.deleteDepartamentoDAL(3);
            this.Frame.Navigate(typeof(Page2));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GestoraAccionesDepartamentosDAL.alterDepartamentoDAL(new clsDepartamento());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GestoraAccionesDepartamentosDAL.addDepartamentoDAL(new clsDepartamento("fuck"));
        }
    }
}
