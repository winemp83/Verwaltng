using System;
using System.Collections.Generic;
using System.IO;
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
using VCore_Lib;

namespace VCore_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //if (File.Exists($@"{Directory.GetCurrentDirectory()}\DB.sak"))
            //    Crypt.EncryptFile("finnpro", $@"{Directory.GetCurrentDirectory()}\DB.sak", $@"{Directory.GetCurrentDirectory()}\xdb.xml");
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuRefresh_Click(object sender, RoutedEventArgs e)
        {
            PersonList.Refresh();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (File.Exists($@"{Directory.GetCurrentDirectory()}\xdb.xml"))
            //    Crypt.DecryptFile("finnpro", $@"{Directory.GetCurrentDirectory()}\xdb.xml", $@"{Directory.GetCurrentDirectory()}\DB.sak");
        }
    }
}
