using IBSC.Common;
using IBSC.DAL;
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
    /// Interaction logic for MemberPage.xaml
    /// </summary>
    public partial class MemberPage : UserControl
    {
        public MemberPage()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable listMember = new MemberDAL().GetAllMember();
            grdMember.ItemsSource = listMember.DefaultView;          
            DataCommon.Set("LIST_MEMBER", listMember);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Index : " + grdMember.SelectedIndex);
        }
    }
}
