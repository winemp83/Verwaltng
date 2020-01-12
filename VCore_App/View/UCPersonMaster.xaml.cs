using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VCore_App.View
{
    /// <summary>
    /// Interaktionslogik für UCPersonMaster.xaml
    /// </summary>
    public partial class UCPersonMaster : UserControl
    {
        public UCPersonMaster()
        {
            InitializeComponent();
            Refresh_Click(this, null);
        }

        public void Refresh_Click(object sender, RoutedEventArgs e) {
            //this.DataContext = new ViewModel.VMPerson();
        }
    }
}
