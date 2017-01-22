using System;
using System.Collections.Generic;
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
            DataContext = new List<Person>
            {
                new Person{Name = "Tom", Age = 10},
                new Person{Name = "Ken", Age = 20},
                new Person{Name = "Jen", Age = 30}
            };
            grdMember.Items.Add(new Person { Name = "Tom", Age = 10 });
            grdMember.Items.Add(new Person { Name = "Ken", Age = 20 });
            grdMember.Items.Add(new Person { Name = "Jen", Age = 30 });
            grdMember.Columns.Add(new DataGridTextColumn { Header = "Name", Binding = new Binding("Name") });
            grdMember.Columns.Add(new DataGridTextColumn { Header = "Age", Binding = new Binding("Age") });
            grdMember.Columns[0].Width = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopupUser p = new PopupUser();
            p.ShowDialog();
        }
    }

    public class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
    }
}
