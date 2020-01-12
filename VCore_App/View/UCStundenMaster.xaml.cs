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
    /// Interaktionslogik für UCStundenMaster.xaml
    /// </summary>
    public partial class UCStundenMaster : UserControl
    {
        private string _UserId;
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public UCStundenMaster()
        {
            InitializeComponent();
            UserId = "All";
            //this.DataContext = new ViewModel.VMStunden(UserId);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            //this.DataContext = new ViewModel.VMStunden(UserId);
        }
    }
}
