﻿using IBSC.Common;
using IBSC.DAL;
using IBSC.WindowApp.Popup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IBSC.WindowApp.Panel
{
    /// <summary>
    /// Interaction logic for InsureCarPage.xaml
    /// </summary>
    public partial class InsureCarPage : UserControl
    {
        public InsureCarPage()
        {
            InitializeComponent();
        }

        private void grdInsure_Loaded(object sender, RoutedEventArgs e)
        {
            ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                DataTable listMember = new InsureCarDAL().GetAll();
                grdInsure.ItemsSource = listMember.DefaultView;
                DataCommon.Set("LIST_INSURE_CAR", listMember);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PopupInsureCar popup = new PopupInsureCar();
            popup.ShowDialog();
            ReloadData();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
